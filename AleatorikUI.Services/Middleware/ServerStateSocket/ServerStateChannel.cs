namespace AleatorikUI.Services.Middleware.ServerStateSocket;

public class ServerStateChannel<T>
{
    public T? Channel { get; set; }
    public string? Key { get; set; }
}
