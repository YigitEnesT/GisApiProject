using geometricBasic.Repositories.Contracts;

namespace geometricBasic.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _context;
        private IGeoPointRepository _geoPointRepository;

        public UnitOfWork(IGeoPointRepository geoPointRepository, AppDbContext context)
        {
            _geoPointRepository = geoPointRepository;
            _context = context;
        }

        public IGeoPointRepository GeoPointRepository => _geoPointRepository;

        public void BeginTransaction()
        {
            _context.Database.BeginTransaction();
        }

        public void CommitTransaction()
        {
            _context.Database.CommitTransaction();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public void RollbackTransaction()
        {
            _context.Database.RollbackTransaction();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
