using tx.Repository;

namespace tx.Interactors;

public class GetCabinetsInteractor : AbstractReadOnlyInteractor<GetCabinetRequest, GetCabinetReply>
{
    private readonly IEntityRepository _repository;

    public GetCabinetsInteractor(IEntityRepository repository)
    {
        _repository = repository;
    }

    public override GetCabinetReply Process(GetCabinetRequest request)
    {
        var cabinets = _repository.GetCabinets(request.Numbers.ToList())
            .Select(entity => new Cabinet
            {
                Number = entity.Number,
                Rows = { entity.Rows.Select(r => r.Number) },
                Position = entity.Position,
                Size = entity.Size
            }).ToList();

        var reply = new GetCabinetReply();
        reply.Cabinets.AddRange(cabinets);

        return reply;
    }
}