namespace TC_LGC.Helpers
{
    using System.IO;
    using System.Text.Json;
    using TC_LGC.Models;

    public static class LoadFilesHelper
    {
        public static GameSettings LoadGameSettings(string gameSettingsPath)
        {
            return JsonSerializer.Deserialize<GameSettings>(
                File.ReadAllText(
                    Path.Combine(
                    Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, 
                    gameSettingsPath)));
        }

        public static Moves LoadMovesSettings(string movesSettingsPath)
        {
            return JsonSerializer.Deserialize<Moves>(
                File.ReadAllText(
                    Path.Combine(
                    Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName,
                    movesSettingsPath)));
        }
    }
}
