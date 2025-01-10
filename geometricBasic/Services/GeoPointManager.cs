using geometricBasic.Models;
using geometricBasic.Models.Dto;
using geometricBasic.Repositories;
using geometricBasic.Repositories.Contracts;
using geometricBasic.Services.Contracts;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace geometricBasic.Services
{
    public class GeoPointManager : IGeoPointService
    {
        // IRepositoryManager bağlantısı
        private readonly IRepositoryManager _manager;

        // UnitOfWork bağlantısı
        private readonly IUnitOfWork _unitOfWork;

        private const int DefaultSRID = 4326;

        public GeoPointManager(IRepositoryManager manager, IUnitOfWork unitOfWork)
        {
            _manager = manager;
            _unitOfWork = unitOfWork;
        }

        public async Task<GeoPointDto> CreateOnePointAsync(GeoPointDto geoPointDto)
        {
            var geoPoint = new GeoPoint
            {
                Name = geoPointDto.Name,
                Coordinate = new Point(geoPointDto.Longitude, geoPointDto.Latitude) { SRID = DefaultSRID },
            };

            _unitOfWork.GeoPointRepository.CreateOnePoint(geoPoint);
            await _unitOfWork.SaveAsync();

            return new GeoPointDto
            {
                Name = geoPoint.Name,
                Longitude = geoPoint.Coordinate.X,
                Latitude = geoPoint.Coordinate.Y
            };
            
        }

        public async Task DeleteOnePointAsync(int id)
        {
            var point = await _unitOfWork.GeoPointRepository.GetOnePointByIdAsync(id);
            if (point is null)
            {
                throw new Exception($"Point with id: {id} could not be deleted.");
            }
            _unitOfWork.GeoPointRepository.DeleteOnePoint(point);
            await _unitOfWork.SaveAsync();
        }
          

        public async Task<IEnumerable<GeoPointDto>> GetAllPointsAsync()
        {
            var points = await _unitOfWork.GeoPointRepository
                .GetAllPointsAsync();

            var pointsDto = points.Select(p => new GeoPointDto
                {
                    Name = p.Name,
                    Longitude = p.Coordinate.X,
                    Latitude = p.Coordinate.Y
                });
            return pointsDto;
        }

        public async Task<GeoPointDto> GetOnePointByIdAsync(int id)
        {
            var point = await _unitOfWork.GeoPointRepository.GetOnePointByIdAsync(id);
            if (point != null)
            {
                var pointDto = new GeoPointDto
                {
                    Name = point.Name,
                    Longitude = point.Coordinate.X,
                    Latitude = point.Coordinate.Y,
                };
                return pointDto;
            }
            else throw new Exception($"Point with id: {id} could not be found.");

        }

        public async Task<GeoPointDto> UpdateOnePointAsync(int id, GeoPointDto geoPointDto)
        {
            var point = await _unitOfWork.GeoPointRepository.GetOnePointByIdAsync(id);
            if (point is not null)
            {
                point.Name = geoPointDto.Name;
                point.Coordinate = new Point(geoPointDto.Longitude, geoPointDto.Latitude) { SRID = DefaultSRID };

                _unitOfWork.GeoPointRepository.UpdateOnePoint(point);
                await _unitOfWork.SaveAsync();

                return geoPointDto;
            }
            else throw new Exception($"Point with id: {id} could not be found.");
        }
    }
}
