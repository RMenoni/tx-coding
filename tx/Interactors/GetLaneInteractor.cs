using tx.Repository;

namespace tx.Interactors;

public class GetLaneInteractor : AbstractReadOnlyInteractor<GetLaneRequest, GetLaneReply>
{
    private readonly IEntityRepository _repository;

    public GetLaneInteractor(IEntityRepository repository)
    {
        _repository = repository;
    }

    public override GetLaneReply Process(GetLaneRequest request)
    {
        var lane = _repository.GetLane(request.CabinetNumber, request.RowNumber, request.LaneNumber);

        var reply = new GetLaneReply();
        reply.Lane = lane;

        return reply;
    }
}