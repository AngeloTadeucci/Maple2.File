
namespace Maple2.File.Tests.helpers;

public static class DotEnv {
    public static readonly string SOLUTION_DIR = Path.GetFullPath(Path.Combine(AppContext.BaseDirectory, "../../../.."));

    public static void Load() {
        string dotenv = Path.Combine(SOLUTION_DIR, ".env");

        if (!System.IO.File.Exists(dotenv)) {
            throw new FileNotFoundException(".env file not found!");
        }

        foreach (string line in System.IO.File.ReadAllLines(dotenv)) {
            if (string.IsNullOrWhiteSpace(line) || line.StartsWith("#")) {
                continue;
            }

            string[] parts = line.Split('=', StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);

            if (parts.Length != 2) {
                continue;
            }

            Environment.SetEnvironmentVariable(parts[0], parts[1]);
        }
    }
}
