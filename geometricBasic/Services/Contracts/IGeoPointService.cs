using geometricBasic.Models.Dto;

namespace geometricBasic.Services.Contracts
{
    public interface IGeoPointService
    {
        public Task<IEnumerable<GeoPointDto>> GetAllPointsAsync();
        public Task<GeoPointDto> GetOnePointByIdAsync(int id);
        public Task<GeoPointDtoForInsertion> CreateOnePointAsync(GeoPointDtoForInsertion geoPointDto);
        public Task<GeoPointDtoForInsertion> UpdateOnePointAsync(int id, GeoPointDtoForInsertion geoPointDto);
        public Task DeleteOnePointAsync(int id);
    }
}
