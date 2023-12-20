using MongoDB.Driver;
using tx.Data;

namespace tx.Repository;

public class EntityRepository : IEntityRepository
{
    private const string DbName = "tx";
    private readonly MongoClient _client;

    public EntityRepository(IConfiguration configuration)
    {
        _client = new MongoClient(configuration.GetConnectionString("MongoDbConnectionString"));
    }

    public List<CabinetEntity> GetCabinets(List<ulong> numbers)
    {
        var filter = numbers.Count > 0
            ? Builders<CabinetEntity>.Filter.In(c => c.Number, numbers)
            : Builders<CabinetEntity>.Filter.Empty;

        return GetCabinetCollection().Find(filter).ToList();
    }

    public RowEntity? GetRow(ulong cabinetNumber, ulong rowNumber)
    {
        var filter = Builders<CabinetEntity>.Filter.Eq(x => x.Number, cabinetNumber);
        var cabinet = GetCabinetCollection().Find(filter).FirstOrDefault();
        if (cabinet != null) return cabinet.Rows.FirstOrDefault(row => row.Number == rowNumber);

        return null;
    }

    public LaneEntity? GetLane(ulong cabinetNumber, ulong rowNumber, ulong laneNumber)
    {
        var filter = Builders<CabinetEntity>.Filter.Eq(x => x.Number, cabinetNumber);
        var cabinet = GetCabinetCollection().Find(filter).FirstOrDefault();
        if (cabinet != null)
        {
            var row = cabinet.Rows.FirstOrDefault(row => row.Number == rowNumber);
            if (row != null) return row.Lanes.FirstOrDefault(lane => lane.Number == laneNumber);
        }

        return null;
    }

    private IMongoCollection<CabinetEntity> GetCabinetCollection()
    {
        var database = _client.GetDatabase(DbName);
        return database.GetCollection<CabinetEntity>("shelf");
    }

    private IMongoCollection<SKUEntity> GetSkuCollection()
    {
        var database = _client.GetDatabase(DbName);
        return database.GetCollection<SKUEntity>("sku");
    }
}