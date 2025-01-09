namespace geometricBasic.Repositories.Contracts
{
    public interface IRepositoryManager
    {
        IGeoPointRepository GeoPointRepository { get; }
        Task SaveAsync();
    }
}
