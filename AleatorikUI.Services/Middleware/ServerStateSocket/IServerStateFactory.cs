namespace AleatorikUI.Services.Middleware.ServerStateSocket;

public interface IServerStateFactory<T>
{
    int Count(string key);
    void Add(string key, ServerStateChannel<T> chennel);
    void Remove(string key, string chennelKey);
    List<ServerStateChannel<T>> All(string key);
    List<ServerStateChannel<T>> Others(string key, ServerStateChannel<T> chennel);
    ServerStateChannel<T>? Client(string key, string chennelKey);
}