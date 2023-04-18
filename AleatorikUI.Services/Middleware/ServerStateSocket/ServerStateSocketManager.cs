using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Concurrent;
using System.Net.WebSockets;
using System.Text;

namespace AleatorikUI.Services.Middleware.ServerStateSocket;

public class ServerStateSocketManager
{
	private readonly ILogger<ServerStateSocketManager> _logger;
	readonly IConfiguration _configuration;
	private readonly RequestDelegate _next;
	private IServerStateFactory<WebSocket> _factory;
	private IServerStateMessageHandler<WebSocket> _handler;
	private ConcurrentDictionary<string, Task> _tasks;

    const string SERVER_TIME_PATH = "/api/ss/server-time";

	public ServerStateSocketManager(ILogger<ServerStateSocketManager> logger,
		IConfiguration configuration,
		RequestDelegate next,
		IServerStateFactory<WebSocket> wsFactory,
		IServerStateMessageHandler<WebSocket> wsmHandler)
	{
		_logger = logger;
		_configuration = configuration;
		_next = next;
		_factory = wsFactory;
		_handler = wsmHandler;
		_tasks = new ConcurrentDictionary<string, Task>();
	}

    public async Task Invoke(HttpContext context)
    {
        if (context.Request.Path == SERVER_TIME_PATH)
        {
            if (context.WebSockets.IsWebSocketRequest)
            {
                var webSocket = await context.WebSockets.AcceptWebSocketAsync();
                var customWebSocket = new ServerStateChannel<WebSocket>()
                {
                    Channel = webSocket,
                    Key = Guid.NewGuid().ToString().ToUpper(),
                };
                _factory.Add(SERVER_TIME_PATH, customWebSocket);
                if (_factory.Count(SERVER_TIME_PATH) > 0)
                {
                    if (!_tasks.ContainsKey(SERVER_TIME_PATH))
                    {
                        var task = Task.Run(ServerTimeRun);
                        _tasks.TryAdd(SERVER_TIME_PATH, task);
                    }
                }
                await Listen(context, customWebSocket, _factory, _handler, SERVER_TIME_PATH);
            }
            else
            {
                context.Response.StatusCode = 400;
            }
        }
        if (context.Response.StatusCode != 101)
        {
            await _next(context);
        }
    }

    private void ServerTimeRun()
    {
        try
        {
            do
            {
                ServerStateInfo msg = new()
                {
                    Time = DateTime.UtcNow.ToString("yyyy'-'MM'-'dd'T'HH':'mm':'ss'.'fff'Z'"),
                }; ;
                string serialisedMessage = JsonConvert.SerializeObject(msg);
                byte[] bytes = Encoding.UTF8.GetBytes(serialisedMessage);

                _handler.BroadcastAll(bytes, _factory, SERVER_TIME_PATH);

                Thread.Sleep(1000);
            } while (_factory.Count(SERVER_TIME_PATH) > 0);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex);
        }
        finally
        {
            _tasks.TryRemove(SERVER_TIME_PATH, out var task);
        }
    }

    private async Task Listen(HttpContext context, ServerStateChannel<WebSocket> customWebSocket, IServerStateFactory<WebSocket> wsFactory, IServerStateMessageHandler<WebSocket> wsmHandler, string key)
    {
        try
        {
            WebSocket webSocket = customWebSocket.Channel;
            if (webSocket == null) return;
            if (webSocket.CloseStatus.HasValue ||
                webSocket.State == WebSocketState.Aborted ||
                webSocket.State == WebSocketState.Closed)
            {
                if (customWebSocket != null)
                {
                    wsFactory.Remove(key, customWebSocket.Key);
                }
                return;
            }
            var buffer = new byte[1024 * 4];
            WebSocketReceiveResult result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            while (webSocket != null &&
                !result.CloseStatus.HasValue &&
                webSocket.State != WebSocketState.Aborted &&
                webSocket.State != WebSocketState.Closed)
            {
                buffer = new byte[1024 * 4];
                result = await webSocket.ReceiveAsync(new ArraySegment<byte>(buffer), CancellationToken.None);
            }
            if (webSocket != null &&
                !result.CloseStatus.HasValue &&
                webSocket.State != WebSocketState.Aborted &&
                webSocket.State != WebSocketState.Closed)
            {
                await webSocket.CloseAsync(result.CloseStatus.Value, result.CloseStatusDescription, CancellationToken.None);
            }
        }
        finally
        {
            if (customWebSocket != null)
            {
                wsFactory.Remove(key, customWebSocket.Key);
            }
        }
    }
}