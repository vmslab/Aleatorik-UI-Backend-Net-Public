using Microsoft.AspNetCore.Http;
using System.Net;
using tusdotnet.Models;
using tusdotnet.Models.Configuration;
using tusdotnet.Models.Expiration;
using tusdotnet.Stores;

namespace AleatorikUI.Services.Helper;

public static class TusHelper
{
    private static Dictionary<string, DefaultTusConfiguration> _tusConfigurations = new Dictionary<string, DefaultTusConfiguration>();

    public static DefaultTusConfiguration? CreateTusConfiguration(HttpContext httpContext)
    {
        var sessionId = httpContext.Request.Headers["session-id"];
        if (!string.IsNullOrWhiteSpace(sessionId))
        {
            var filePath = WebUtility.UrlDecode(httpContext.Request.Headers["file-path"]);
            if (_tusConfigurations.ContainsKey(sessionId))
            {
                return _tusConfigurations[sessionId];
            }
            else
            {
                var fileName = Path.GetFileName(filePath);

                var tusStore = Path.GetDirectoryName(filePath) ?? string.Empty;

                if (!Directory.Exists(tusStore))
                {
                    Directory.CreateDirectory(tusStore);
                }

                var tusConf = new DefaultTusConfiguration
                {
                    UrlPath = "/api/upload",
                    Store = new TusDiskStore(tusStore),
                    MetadataParsingStrategy = MetadataParsingStrategy.AllowEmptyValues,
                    Expiration = new AbsoluteExpiration(TimeSpan.FromMinutes(5)),
                    Events = new Events
                    {
                        OnFileCompleteAsync = ctx =>
                        {
                            File.Move(Path.Combine(tusStore, ctx.FileId), filePath);
                            var entries = Directory.GetFileSystemEntries(tusStore, $"{ctx.FileId}.*");
                            foreach (var entry in entries)
                            {
                                File.Delete(entry);
                            }
                            return Task.CompletedTask;
                        },
                    }
                };

                if (!_tusConfigurations.ContainsKey(sessionId))
                {
                    _tusConfigurations.Add(sessionId, tusConf);
                }
                return tusConf;
            }
        }

        return null;
    }
}
