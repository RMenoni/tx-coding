using MongoDB.Bson;

namespace tx.Data;

public class CabinetEntity
{
    public CabinetEntity()
    {
        Rows = new List<RowEntity>();
        Position = new PositionEntity();
        Size = new SizeEntity();
    }

    public ObjectId _id { get; set; }
    public ulong Number { get; set; }
    public List<RowEntity> Rows { get; set; }
    public PositionEntity Position { get; set; }
    public SizeEntity Size { get; set; }
}