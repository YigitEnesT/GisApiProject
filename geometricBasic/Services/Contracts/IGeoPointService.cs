using geometricBasic.Models.Dto;

namespace geometricBasic.Services.Contracts
{
    public interface IGeoPointService
    {
        public Task<IEnumerable<GeoPointDto>> GetAllPointsAsync();
        public Task<GeoPointDto> GetOnePointByIdAsync(int id);
        public Task<GeoPointDto> CreateOnePointAsync(GeoPointDto geoPointDto);
        public Task<GeoPointDto> UpdateOnePointAsync(int id, GeoPointDto geoPointDto);
        public Task DeleteOnePointAsync(int id);
    }
}
