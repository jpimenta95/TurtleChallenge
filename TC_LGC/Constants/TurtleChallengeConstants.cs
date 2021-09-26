namespace TC_LGC.Constants
{
    public static class TurtleChallengeConstants
    {
        public class Directions
        {
            public const string North = "north";

            public const string East = "east";

            public const string South = "south";

            public const string West = "west";
        }

        public class Moves
        {
            public const string Rotation = "r";

            public const string Move = "m";
        }

        public class Logs
        {
            public const string BaseLog = "Sequence {0}: ";

            public const string Success = BaseLog + "Success!";

            public const string ExitFound = BaseLog + "Exit Found!";

            public const string MineHit = BaseLog + "Mine Hit!";

            public const string OutOfRange = BaseLog + "Turtle out of range!";

            public const string InitialMessage = "Hello! Welcome to Turtle Challenge. Wait until we load the settings.";

            public const string GameStart = "Game started!";

            public const string GameEnd = "End game. Press any key to continue.";
        }
    }
}
