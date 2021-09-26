namespace TC_LGC.Helpers
{
    using System.IO;
    using System.Text.Json;
    using TC_LGC.Models;

    /// <summary>
    /// Helper in load files purpose.
    /// </summary>
    public static class LoadFilesHelper
    {
        /// <summary>
        /// Method to read game settings inside "game-settings.json" file.
        /// </summary>
        /// <param name="gameSettingsPath"></param>
        /// <returns>GameSettings model class</returns>
        public static GameSettings LoadGameSettings(string gameSettingsPath)
        {
            return JsonSerializer.Deserialize<GameSettings>(
                File.ReadAllText(
                    Path.Combine(
                    Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.Parent.FullName, 
                    gameSettingsPath)));
        }

        /// <summary>
        /// Method to read moves inside "moves.json" file.
        /// </summary>
        /// <param name="movesSettingsPath"></param>
        /// <returns>Moves model class</returns>
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
