namespace tx.Data;

public class PositionEntity
{
    public int X { get; set; }
    public int Y { get; set; }
    public int Z { get; set; }

    public static implicit operator Position(PositionEntity e)
    {
        return new Position
        {
            X = e.X,
            Y = e.Y,
            Z = e.Z
        };
    }
}