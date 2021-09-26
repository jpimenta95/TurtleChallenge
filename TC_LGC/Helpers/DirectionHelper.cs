namespace TC_LGC.Helpers
{
    using System.Collections.Generic;
    using TC_LGC.Constants;

    /// <summary>
    /// Helper in direction purpose.
    /// </summary>
    public class DirectionHelper
    {
        /// <summary>
        /// Dictionary to get new direction base on current direction of the Turtle.
        /// </summary>
        private static readonly IDictionary<string, string> _directionDictionary
            = new Dictionary<string, string>()
            {
                        { TurtleChallengeConstants.Directions.North, TurtleChallengeConstants.Directions.East },
                        { TurtleChallengeConstants.Directions.East, TurtleChallengeConstants.Directions.South },
                        { TurtleChallengeConstants.Directions.South, TurtleChallengeConstants.Directions.West },
                        { TurtleChallengeConstants.Directions.West, TurtleChallengeConstants.Directions.North }
            };

        /// <summary>
        /// This method set new direction for Turtle based on rotation move input.
        /// </summary>
        /// <param name="direction"></param>
        /// <returns>New direction</returns>
        public static string SetNewDirection(string direction)
        {
            return _directionDictionary[direction];
        }
    }
}
