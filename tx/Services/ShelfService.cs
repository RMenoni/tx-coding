using Grpc.Core;
using tx.Interactors;

namespace tx.Services;

public class ShelfService : Shelf.ShelfBase
{
    private readonly GetCabinetsInteractor _getCabinetsInteractor;
    private readonly GetCabinetsInteractor _getRowsInteractor;
    private readonly GetCabinetsInteractor _getLanesInteractor;
    private readonly ILogger<ShelfService> _logger;

    public ShelfService(ILogger<ShelfService> logger, GetCabinetsInteractor getCabinetsInteractor)
    {
        _logger = logger;
        _getCabinetsInteractor = getCabinetsInteractor;
    }

    public override Task<GetCabinetReply> GetCabinet(GetCabinetRequest request, ServerCallContext context)
    {
        return Task.FromResult(_getCabinetsInteractor.Process(request));
    }

    public override Task<GetRowReply> GetRow(GetRowRequest request, ServerCallContext context)
    {
        return Task.FromResult(_getCabinetsInteractor.Process(request));
    }

    public override Task<GetLaneReply> GetLane(GetLaneRequest request, ServerCallContext context)
    {
        return Task.FromResult(_getCabinetsInteractor.Process(request));
    }
}