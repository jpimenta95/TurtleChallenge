namespace TC_LGC.Helpers
{
    using System;
    using System.Collections.Generic;
    using TC_LGC.Models;

    public class PositionHelper
    {
        private static readonly IDictionary<string, int[]> _positionDictionary
            = new Dictionary<string, int[]>()
            {
                        { "north", new int[] { 0, 1 } },
                        { "east", new int[] { 1, 0 } },
                        { "south", new int[] { 0, -1 } },
                        { "west", new int[] { -1, 0 } }
            };

        public static GameSettings SetNewPosition(GameSettings gameSettings)
        {
            int[] changesInPosition = _positionDictionary[gameSettings.Turtle.Direction];

            gameSettings.Turtle.PositionX += changesInPosition[0];

            gameSettings.Turtle.PositionY += changesInPosition[1];

            return gameSettings;
        }

        public static bool PositionValidation(GameSettings gameSettings, int[,] board, int sequence)
        {
            int[] turtlePosition = new int[] { gameSettings.Turtle.PositionX, gameSettings.Turtle.PositionY };

            if (gameSettings.Board.Exit.PositionX == gameSettings.Turtle.PositionX && gameSettings.Board.Exit.PositionY == gameSettings.Turtle.PositionY)
            {
                Console.WriteLine($"Sequence {sequence}: Exit found!");
                return false;
            }

            if (gameSettings.Mine.Exists(m => m.PositionX == gameSettings.Turtle.PositionX && m.PositionY == gameSettings.Turtle.PositionY))
            {
                Console.WriteLine($"Sequence {sequence}: Mine hit!");
                return false;
            }

            try
            {
                board.GetValue(turtlePosition);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine($"Sequence {sequence}: Turtle out of range.");
                return false;
            }

            return true;
        }
    }
}
