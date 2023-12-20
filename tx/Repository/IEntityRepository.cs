using tx.Data;

namespace tx.Repository;

public interface IEntityRepository
{
    public List<CabinetEntity> GetCabinets(List<ulong> numbers);
    public RowEntity? GetRow(ulong cabinetNumber, ulong rowNumber);
    public LaneEntity? GetLane(ulong cabinetNumber, ulong rowNumber, ulong laneNumber);
}