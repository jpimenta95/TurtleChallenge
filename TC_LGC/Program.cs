namespace TC_LGC
{
    using System;
    using TC_LGC.Helpers;
    using TC_LGC.Models;

    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello! Welcome to Turtle Challenge. Wait until we load the settings.");

            GameSettings gameSettings = LoadFilesHelper.LoadGameSettings(args[0]);
            Moves moves = LoadFilesHelper.LoadMovesSettings(args[1]);

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

                if (!PositionHelper.PositionValidation(gameSettings, board, i)) break;

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
                    gameSettings.Turtle.Direction = DirectionHelper.SetNewDirection(gameSettings.Turtle.Direction);
                    break;
                case "m":
                    PositionHelper.SetNewPosition(gameSettings);
                    break;
                default:
                    break;
            }
        }
        #endregion
    }
}
