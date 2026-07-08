using System.IO.Compression;

public interface IFileStrategy
{
    void Process(string filePath);
}

public class ZipFileStrategy : IFileStrategy
{
    public void Process(string filePath)
    {
        string backupDir = Path.Combine(Path.GetDirectoryName(filePath)!, "backup");

        if (!Directory.Exists(backupDir))
        {
            Directory.CreateDirectory(backupDir);
        }
        
        ZipFile.ExtractToDirectory(filePath, backupDir);
        Console.WriteLine($"[ZIP] {filePath} successfully unzipped");
    }
}

public class JsonFileStrategy : IFileStrategy
{
    public void Process(string filePath)
    {
        string content = File.ReadAllText(filePath);
        Console.WriteLine($"[JSON Content of {filePath}]:\n{content}");
    }
}

public class TxtFileStrategy : IFileStrategy
{
    public void Process(string filePath)
    {
        File.Delete(filePath);
        Console.WriteLine($"[TXT] {filePath} successfully deleted.");
    }
}

public class FileProcessorContext
{
    private readonly Dictionary<string, IFileStrategy> _strategies = new()
    {
        { ".zip", new ZipFileStrategy() },
        { ".json", new JsonFileStrategy() },
        { ".txt", new TxtFileStrategy() }
    };

    public void ProcessFile(string filePath)
    {
        string extension = Path.GetExtension(filePath).ToLower();
        if (_strategies.TryGetValue(extension, out var strategy))
        {
            strategy.Process(filePath);
        }
        else
        {
            Console.WriteLine($"[ERROR] {filePath} is not a valid file extension.");
        }
    }  
}