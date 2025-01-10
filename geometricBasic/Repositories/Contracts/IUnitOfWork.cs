namespace geometricBasic.Repositories.Contracts
{
    public interface IUnitOfWork : IDisposable
    {
        IGeoPointRepository GeoPointRepository { get; }
        Task SaveAsync();
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}
