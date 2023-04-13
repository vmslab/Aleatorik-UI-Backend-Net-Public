namespace AleatorikUI.Services.Helper;

public class FileHelper
{
    public static List<object> GetFileList(string dirPath)
    {
        var files = new List<object>();

        string[] entries = Directory.GetFileSystemEntries(dirPath, "*", SearchOption.AllDirectories);

        foreach (var entry in entries)
        {
            if (File.Exists(entry))
            {
                var fi = new FileInfo(entry);
                files.Add(new
                {
                    name = entry.Replace(dirPath + @"\", string.Empty),
                    size = fi.Length,
                    latestUpdateTime = fi.LastAccessTime.ToString("yyyy-MM-dd HH:mm:ss"),
                });
            }
        }

        return files;
    }
}
