namespace TC_LGC.Settings
{
    using System.Collections.Generic;

    public class GameSettings
    {
        public BoardSettings Board { get; set; }

        public List<MineSettings> Mine { get; set; }

        public TurtleSettings Turtle { get; set; }

        public class BoardSettings
        {
            public int Columns { get; set; }
            public int Rows { get; set; }
            public Exit Exit { get; set; }
        }

        public class Exit
        {
            public int PositionX { get; set; }
            public int PositionY { get; set; }
        }

        public class MineSettings
        {
            public int PositionX { get; set; }
            public int PositionY { get; set; }
        }

        public class TurtleSettings
        {
            public int PositionX { get; set; }
            public int PositionY { get; set; }
            public string Direction { get; set; }
        }
    }
}
