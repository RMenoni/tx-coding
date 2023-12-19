using MongoDB.Bson;

namespace tx.Data;

public class SKUEntity
{
    public ObjectId _id { get; set; }
    public ulong JanCode { get; set; }
    public string Name { get; set; }
    public float X { get; set; }
    public float Y { get; set; }
    public float Z { get; set; }
    public string ImageURL { get; set; }
    public uint Size { get; set; }
    public uint TimeStamp { get; set; }
    public string Shape { get; set; }
}