using AleatorikUI.Services.Middleware.ServerStateSocket;
using System.Net.WebSockets;

namespace AleatorikUI.Services.Configuration;

public static class SocketServiceConfiguration
{
    public static void AddServerStateSocketService(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddSingleton<IServerStateFactory<WebSocket>, ServerStateFactory<WebSocket>>();
        services.AddSingleton<IServerStateMessageHandler<WebSocket>, ServerStateMessageHandler>();
    }

}