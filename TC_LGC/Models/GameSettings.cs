namespace TC_LGC.Models
{
    using System.Collections.Generic;

    /// <summary>
    /// Game Settings model class.
    /// </summary>
    public class GameSettings
    {
        public BoardSettings Board { get; set; }

        public List<Mine> Mine { get; set; }

        public Turtle Turtle { get; set; }

        public class BoardSettings
        {
            public int Columns { get; set; }
            public int Rows { get; set; }
            public Exit Exit { get; set; }
        }
    }
}
