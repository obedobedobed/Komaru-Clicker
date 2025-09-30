using System;
using System.IO;
using System.Text.Json;

namespace KomaruClicker;

public static class GameData
{
    private static readonly string savePath = Path.Combine(
        Environment.GetFolderPath(Environment.SpecialFolder.UserProfile),
        ".ObedGaming", "KomaruClicker", "data.json");

    public static void Save()
    {
        string directory = Path.GetDirectoryName(savePath);
        Directory.CreateDirectory(directory);
        string json = JsonSerializer.Serialize(Program.clicks, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(savePath, json);
    }

    public static int Load()
    {
        int data = 0;
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            data = JsonSerializer.Deserialize<int>(json);
        }
        return data;
    }
}