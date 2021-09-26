namespace TC_LGC
{
    using System;
    using System.Collections.Generic;
    using TC_LGC.Settings;

    public class Program
    {
        private static readonly IDictionary<string, string> _directionDictionary
            = new Dictionary<string, string>()
            {
                { "north", "east" },
                { "east", "south" },
                { "south", "west" },
                { "west", "north" }
            };

        private static readonly IDictionary<string, int[]> _positionDictionary
            = new Dictionary<string, int[]>()
            {
                { "north", new int[] { 0, 1 } },
                { "east", new int[] { 1, 0 } },
                { "south", new int[] { 0, -1 } },
                { "west", new int[] { -1, 0 } }
            };


        public static void Main(string[] args)
        {
            Console.WriteLine("Hello! Welcome to Turtle Challenge. Wait until we load the settings.");

            GameSettings gameSettings = LoadFiles.LoadGameSettings(args[0]);
            Moves moves = LoadFiles.LoadMovesSettings(args[1]);

            Start(gameSettings, moves);

            Console.WriteLine("End game. Press any key to continue.");
            Console.ReadKey();

        }

        public static void Start(GameSettings gameSettings, Moves moves)
        {
            Console.WriteLine("Game started!");

            int[,] board = SetBoard(gameSettings);

            int sequences = moves.Sequences.Count;

            for (int i = 0; i < sequences; i++)
            {
                MoveTurtle(gameSettings, moves.Sequences[i].Move);

                if (!ContinueInGame(gameSettings, board, i)) break;

                Console.WriteLine($"Sequence {i}: Success!");
            }
        }

        #region privates
        private static int[,] SetBoard(GameSettings gameSettings)
        {
            int[,] board = new int[gameSettings.Board.Columns, gameSettings.Board.Rows];

            return board;
        }

        private static void MoveTurtle(GameSettings gameSettings, string move)
        {
            switch (move)
            {
                case "r":
                    gameSettings.Turtle.Direction = SetNewDirection(gameSettings.Turtle.Direction);
                    break;
                case "m":
                    SetNewPosition(gameSettings);
                    break;
                default:
                    break;
            }
        }

        private static string SetNewDirection(string direction)
        {
            return _directionDictionary[direction];
        }

        private static GameSettings SetNewPosition(GameSettings gameSettings)
        {
            int[] changesInPosition = _positionDictionary[gameSettings.Turtle.Direction];

            gameSettings.Turtle.PositionX += changesInPosition[0];

            gameSettings.Turtle.PositionY += changesInPosition[1];

            return gameSettings;
        }

        private static bool ContinueInGame(GameSettings gameSettings, int[,] board, int sequence)
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
        #endregion
    }
}
