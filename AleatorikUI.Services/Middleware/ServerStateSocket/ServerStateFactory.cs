using System.Collections.Concurrent;

namespace AleatorikUI.Services.Middleware.ServerStateSocket;

public class ServerStateFactory<T> : IServerStateFactory<T>
{
    ConcurrentDictionary<string, List<ServerStateChannel<T>>> _dict;

    public int Count(string key)
    {
        if (_dict.TryGetValue(key, out List<ServerStateChannel<T>>? list))
        {
            return list.Count;
        }

        return 0;
    }

    public ServerStateFactory()
    {
        _dict = new ConcurrentDictionary<string, List<ServerStateChannel<T>>>();
    }

    public void Add(string key, ServerStateChannel<T> channel)
    {
        List<ServerStateChannel<T>>? list;
        if (_dict.TryGetValue(key, out list) == false)
        {
            list = new List<ServerStateChannel<T>>();
            _dict[key] = list;
        }
        if (channel != null)
        {
            list.Add(channel);
        }
    }

    //when disconnect
    public void Remove(string key, string channelKey)
    {
        if (_dict.TryGetValue(key, out List<ServerStateChannel<T>>? list))
        {
            var channel = Client(key, channelKey);
            if (channel != null)
            {
                list.Remove(channel);
            }
        }
    }

    public List<ServerStateChannel<T>> All(string key)
    {
        if (_dict.TryGetValue(key, out List<ServerStateChannel<T>>? list))
        {
            return list;
        }
        else
        {
            return new List<ServerStateChannel<T>>();
        }
    }

    public List<ServerStateChannel<T>> Others(string key, ServerStateChannel<T> channel)
    {
        if (_dict.TryGetValue(key, out List<ServerStateChannel<T>>? list))
        {
            return list.Where(c => c.Key != channel.Key).ToList();
        }
        else
        {
            return new List<ServerStateChannel<T>>();
        }
    }

    public ServerStateChannel<T>? Client(string key, string channelKey)
    {
        if (_dict.TryGetValue(key, out List<ServerStateChannel<T>>? list))
        {
            return list.Where(c => c != null).FirstOrDefault(c => c.Key == channelKey);
        }
        return null;
    }
}