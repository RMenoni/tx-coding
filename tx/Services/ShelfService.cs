using Grpc.Core;
using tx.Interactors;

namespace tx.Services;

public class ShelfService : Shelf.ShelfBase
{
    private readonly GetCabinetsInteractor _getCabinetsInteractor;
    private readonly GetLaneInteractor _getLaneInteractor;
    private readonly GetRowInteractor _getRowInteractor;

    public ShelfService(
        GetCabinetsInteractor getCabinetsInteractor,
        GetRowInteractor getRowInteractor,
        GetLaneInteractor getLaneInteractor
    )
    {
        _getCabinetsInteractor = getCabinetsInteractor;
        _getRowInteractor = getRowInteractor;
        _getLaneInteractor = getLaneInteractor;
    }

    public override Task<GetCabinetReply> GetCabinet(GetCabinetRequest request, ServerCallContext context)
    {
        return Task.FromResult(_getCabinetsInteractor.Process(request));
    }

    public override Task<GetRowReply> GetRow(GetRowRequest request, ServerCallContext context)
    {
        return Task.FromResult(_getRowInteractor.Process(request));
    }

    public override Task<GetLaneReply> GetLane(GetLaneRequest request, ServerCallContext context)
    {
        return Task.FromResult(_getLaneInteractor.Process(request));
    }
}