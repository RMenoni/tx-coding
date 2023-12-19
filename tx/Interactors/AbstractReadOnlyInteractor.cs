namespace tx.Interactors
{
    public abstract class AbstractReadOnlyInteractor<Request, Reply>
    {
        public abstract Reply Process(Request request);
    }
}
