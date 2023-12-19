using MongoDB.Driver;
using tx.Data;

namespace tx.Repository;

public class EntityRepository : IEntityRepository
{
    private readonly MongoClient _client;

    public EntityRepository()
    {
        _client = new MongoClient("mongodb://localhost:27017");
    }

    public List<CabinetEntity> GetCabinets(List<ulong> numbers)
    {
        var database = _client.GetDatabase("tx");
        var collection = database.GetCollection<CabinetEntity>("shelf");
        var filter = numbers.Count > 0
            ? Builders<CabinetEntity>.Filter.In(c => c.Number, numbers)
            : Builders<CabinetEntity>.Filter.Empty;

        return collection.Find(filter).ToList();
    }

    public List<RowEntity> GetRows(List<ulong> Numbers)
    {
    }

    public List<LaneEntity> GetLanes(List<ulong> Numbers)
    {
    }
}