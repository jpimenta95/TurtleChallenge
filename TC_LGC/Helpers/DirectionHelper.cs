namespace TC_LGC.Helpers
{
    using System.Collections.Generic;
    using TC_LGC.Constants;

    public class DirectionHelper
    {
        private static readonly IDictionary<string, string> _directionDictionary
            = new Dictionary<string, string>()
            {
                        { TurtleChallengeConstants.Directions.North, TurtleChallengeConstants.Directions.East },
                        { TurtleChallengeConstants.Directions.East, TurtleChallengeConstants.Directions.South },
                        { TurtleChallengeConstants.Directions.South, TurtleChallengeConstants.Directions.West },
                        { TurtleChallengeConstants.Directions.West, TurtleChallengeConstants.Directions.North }
            };

        public static string SetNewDirection(string direction)
        {
            return _directionDictionary[direction];
        }
    }
}
