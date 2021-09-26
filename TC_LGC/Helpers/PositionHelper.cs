namespace TC_LGC.Helpers
{
    using System;
    using System.Collections.Generic;
    using TC_LGC.Constants;
    using TC_LGC.Models;

    public class PositionHelper
    {
        private static readonly IDictionary<string, int[]> _positionDictionary
            = new Dictionary<string, int[]>()
            {
                        { TurtleChallengeConstants.Directions.North, new int[] { 0, 1 } },
                        { TurtleChallengeConstants.Directions.East, new int[] { 1, 0 } },
                        { TurtleChallengeConstants.Directions.South, new int[] { 0, -1 } },
                        { TurtleChallengeConstants.Directions.West, new int[] { -1, 0 } }
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
                Console.WriteLine(TurtleChallengeConstants.Logs.ExitFound, sequence);
                return false;
            }

            if (gameSettings.Mine.Exists(m => m.PositionX == gameSettings.Turtle.PositionX && m.PositionY == gameSettings.Turtle.PositionY))
            {
                Console.WriteLine(TurtleChallengeConstants.Logs.MineHit, sequence);
                return false;
            }

            try
            {
                board.GetValue(turtlePosition);
            }
            catch (IndexOutOfRangeException)
            {
                Console.WriteLine(TurtleChallengeConstants.Logs.OutOfRange, sequence);
                return false;
            }

            return true;
        }
    }
}
