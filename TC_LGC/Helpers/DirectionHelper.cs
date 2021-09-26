namespace TC_LGC.Helpers
{
    using System.Collections.Generic;

    public class DirectionHelper
    {
        private static readonly IDictionary<string, string> _directionDictionary
            = new Dictionary<string, string>()
            {
                        { "north", "east" },
                        { "east", "south" },
                        { "south", "west" },
                        { "west", "north" }
            };

        public static string SetNewDirection(string direction)
        {
            return _directionDictionary[direction];
        }
    }
}
