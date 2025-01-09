using geometricBasic.Models;
using geometricBasic.Models.Dto;

namespace geometricBasic.Repositories.Contracts
{
    public interface IGeoPointRepository : IRepositoryBase<GeoPoint>
    {
        public Task<IEnumerable<GeoPoint>> GetAllPointsAsync();
        public Task<GeoPoint> GetOnePointByIdAsync(int id);
        public void CreateOnePoint(GeoPoint geoPoint);
        public void UpdateOnePoint(GeoPoint geoPoint);
        public void DeleteOnePoint(GeoPoint geoPoint);
    }
}
