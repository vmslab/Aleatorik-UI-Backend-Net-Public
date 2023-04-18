namespace AleatorikUI.Services.Middleware.ServerStateSocket;

public interface IServerStateMessageHandler<T>
{
    Task BroadcastAll(object message, IServerStateFactory<T> wsFactory, string key);
}
