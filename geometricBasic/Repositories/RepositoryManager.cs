using geometricBasic.Repositories.Contracts;

namespace geometricBasic.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly AppDbContext _context;
        private readonly IGeoPointRepository _geoPointRepository;

        public RepositoryManager(IGeoPointRepository geoPointRepository, AppDbContext context)
        {
            _geoPointRepository = geoPointRepository;
            _context = context;
        }

        public IGeoPointRepository GeoPointRepository => _geoPointRepository;

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }

        // Unit of work için yeni bir interface ve class oluştur buna benzer yapıları oraya ekle.

    }
}
