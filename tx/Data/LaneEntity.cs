namespace tx.Data;

public class LaneEntity
{
    public LaneEntity()
    {
        JanCode = "";
    }

    public ulong Number { get; set; }
    public string JanCode { get; set; }
    public uint Quantity { get; set; }
    public int PositionX { get; set; }

    public static implicit operator Lane(LaneEntity e)
    {
        return new Lane
        {
            JanCode = e.JanCode,
            Number = e.Number,
            Quantity = e.Quantity,
            PositionX = e.PositionX
        };
    }
}