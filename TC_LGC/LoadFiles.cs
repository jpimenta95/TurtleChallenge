namespace TC_LGC
{
    using System.IO;
    using System.Text.Json;
    using TC_LGC.Settings;

    public static class LoadFiles
    {
        public static GameSettings LoadGameSettings(string gameSettingsPath)
        {
            return JsonSerializer.Deserialize<GameSettings>(File.ReadAllText(gameSettingsPath));
        }

        public static Moves LoadMovesSettings(string movesSettingsPath)
        {
            return JsonSerializer.Deserialize<Moves>(File.ReadAllText(movesSettingsPath));
        }
    }
}
