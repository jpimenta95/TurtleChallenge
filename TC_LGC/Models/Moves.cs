namespace TC_LGC.Models
{
    using System.Collections.Generic;

    public class Moves
    {
        public List<Sequence> Sequences { get; set; }

        public class Sequence
        {
            public string Move { get; set; }
        }
    }
}
