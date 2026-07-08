public interface IActor
{
    void PerfomScene(string sceneName, bool isDangerous);
}

public class MainActor : IActor
{
    public void PerfomScene(string sceneName, bool isDangerous)
    {
        Console.WriteLine($"MainActor is playing in the '{sceneName}' scene.");

    }
}

public class StuntmanProxy : IActor
{
    private readonly MainActor _mainActor = new MainActor();

    public void PerfomScene(string sceneName, bool isDangerous)
    {
        if (isDangerous)
        {
            Console.WriteLine($"Stuntman '{sceneName}' is dangerous!");
        }
        else
        {
            Console.WriteLine($"Stuntman '{sceneName}' is safe.");
            _mainActor.PerfomScene(sceneName, isDangerous);
        }
    }
}
