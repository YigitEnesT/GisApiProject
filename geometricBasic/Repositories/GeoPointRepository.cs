using geometricBasic.Models;
using geometricBasic.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace geometricBasic.Repositories
{
    public class GeoPointRepository : RepositoryBase<GeoPoint>, IGeoPointRepository
    {
        public GeoPointRepository(AppDbContext dbContext) : base(dbContext)
        {
        }

        public void CreateOnePoint(GeoPoint geoPoint) => Create(geoPoint);

        public void DeleteOnePoint(GeoPoint geoPoint) => Delete(geoPoint);

        public async Task<IEnumerable<GeoPoint>> GetAllPointsAsync() => 
            await GetAll()
                .ToListAsync();
  
        public async Task<GeoPoint> GetOnePointByIdAsync(int id) =>
            await FindByCondition(c => c.Id.Equals(id))
                .SingleOrDefaultAsync();

        public void UpdateOnePoint(GeoPoint geoPoint) => Update(geoPoint);
    }
}
