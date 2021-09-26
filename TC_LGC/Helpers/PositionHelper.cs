namespace TC_LGC.Helpers
{
    using System;
    using System.Collections.Generic;
    using TC_LGC.Constants;
    using TC_LGC.Models;

    /// <summary>
    /// Helper in position purpose.
    /// </summary>
    public class PositionHelper
    {
        /// <summary>
        /// Dictionary to get new position base on current position of the Turtle.
        /// </summary>
        private static readonly IDictionary<string, int[]> _positionDictionary
            = new Dictionary<string, int[]>()
            {
                        { TurtleChallengeConstants.Directions.North, new int[] { 0, 1 } },
                        { TurtleChallengeConstants.Directions.East, new int[] { 1, 0 } },
                        { TurtleChallengeConstants.Directions.South, new int[] { 0, -1 } },
                        { TurtleChallengeConstants.Directions.West, new int[] { -1, 0 } }
            };

        /// <summary>
        /// This method set new position for Turtle based on move input.
        /// </summary>
        /// <param name="gameSettings"></param>
        /// <returns>Game settings with new position of the Turtle</returns>
        public static GameSettings SetNewPosition(GameSettings gameSettings)
        {
            int[] changesInPosition = _positionDictionary[gameSettings.Turtle.Direction];

            gameSettings.Turtle.PositionX += changesInPosition[0];

            gameSettings.Turtle.PositionY += changesInPosition[1];

            return gameSettings;
        }

        /// <summary>
        /// This method validate every position steped by Turtle.
        /// </summary>
        /// <param name="gameSettings"></param>
        /// <param name="board"></param>
        /// <param name="sequence"></param>
        /// <returns>False if Turtle can't walk anymore, tru if its can</returns>
        public static bool PositionValidation(GameSettings gameSettings, int[,] board, int sequence)
        {
            int[] turtlePosition = new int[] { gameSettings.Turtle.PositionX, gameSettings.Turtle.PositionY };

            if (gameSettings.Board.Exit.PositionX == gameSettings.Turtle.PositionX && gameSettings.Board.Exit.PositionY == gameSettings.Turtle.PositionY)
            {
                Console.WriteLine(string.Format(TurtleChallengeConstants.Logs.ExitFound, sequence));
                return false;
            }

            if (gameSettings.Mine.Exists(m => m.PositionX == gameSettings.Turtle.PositionX && m.PositionY == gameSettings.Turtle.PositionY))
            {
                Console.WriteLine(string.Format(TurtleChallengeConstants.Logs.MineHit, sequence));
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
