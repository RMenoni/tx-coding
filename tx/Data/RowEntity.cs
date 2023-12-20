namespace tx.Data;

public class RowEntity
{
    public RowEntity()
    {
        Lanes = new List<LaneEntity>();
        Size = new RowSizeEntity();
    }

    public ulong Number { get; set; }
    public List<LaneEntity> Lanes { get; set; }
    public float PositionZ { get; set; }
    public RowSizeEntity Size { get; set; }

    public static implicit operator Row(RowEntity e)
    {
        return new Row
        {
            Number = e.Number,
            Lanes = { e.Lanes.Select(r => r.Number) },
            Height = e.Size.Height,
            PositionZ = e.PositionZ
        };
    }
}