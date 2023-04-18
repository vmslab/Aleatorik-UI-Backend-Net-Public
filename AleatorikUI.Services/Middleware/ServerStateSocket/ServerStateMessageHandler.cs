using System.Net.WebSockets;

namespace AleatorikUI.Services.Middleware.ServerStateSocket;

public class ServerStateMessageHandler : IServerStateMessageHandler<WebSocket>
{

    public async Task BroadcastAll(object message, IServerStateFactory<WebSocket> wsFactory, string key)
    {
        if (message != null && message is byte[])
        {
            var all = wsFactory.All(key);
            foreach (var channel in all)
            {
                try
                {
                    if (channel == null) return;
                    if (channel.Channel.CloseStatus.HasValue ||
                        channel.Channel.State == WebSocketState.Aborted ||
                        channel.Channel.State == WebSocketState.Closed)
                    {
                        wsFactory.Remove(key, channel.Key);
                        return;
                    }
                    await channel.Channel.SendAsync(new ArraySegment<byte>(message as byte[], 0, (message as byte[]).Length), WebSocketMessageType.Binary, true, CancellationToken.None);
                }
                catch (Exception ex)
                {
                    if (channel != null)
                    {
                        wsFactory.Remove(key, channel.Key);
                    }
                    System.Console.WriteLine(ex.ToString());
                }
            }
        }
    }
}
