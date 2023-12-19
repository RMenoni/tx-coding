using tx.Data;

namespace tx.Repository
{
    public interface IEntityRepository
    {
        public List<CabinetEntity> GetCabinets(List<UInt64> Numbers);
        public List<RowEntity> GetRows(List<UInt64> Numbers);
        public List<LaneEntity> GetLanes(List<UInt64> Numbers);
    }
}
