using tx.Repository;

namespace tx.Interactors;

public class GetRowInteractor : AbstractReadOnlyInteractor<GetRowRequest, GetRowReply>
{
    private readonly IEntityRepository _repository;

    public GetRowInteractor(IEntityRepository repository)
    {
        _repository = repository;
    }

    public override GetRowReply Process(GetRowRequest request)
    {
        var row = _repository.GetRow(request.CabinetNumber, request.RowNumber);

        var reply = new GetRowReply();
        if (row != null) reply.Row = row;

        return reply;
    }
}