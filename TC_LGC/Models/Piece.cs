namespace TC_LGC.Models
{
    /// <summary>
    /// Piece abstract model class. This class has (x,y) coordinates cross all pieces.
    /// </summary>
    public abstract class Piece
    {
        public int PositionX { get; set; }
        public int PositionY { get; set; }
    }
}
