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
        private readonly IRepositoryManager _manager;

        public GeoPointManager(IRepositoryManager manager)
        {
            _manager = manager;
        }

        public async Task<GeoPointDto> CreateOnePointAsync(GeoPointDto geoPointDto)
        {
            var geoPoint = new GeoPoint
            {
                Name = geoPointDto.Name,
                Coordinate = new Point(geoPointDto.Longitude, geoPointDto.Latitude) { SRID = 4326 },
            };

            _manager.GeoPointRepository.CreateOnePoint(geoPoint);
            await _manager.SaveAsync();

            return new GeoPointDto
            {
                Name = geoPoint.Name,
                Longitude = geoPoint.Coordinate.X,
                Latitude = geoPoint.Coordinate.Y
            };
        }

        public async Task DeleteOnePointAsync(int id)
        {
            var point = await _manager.GeoPointRepository.GetOnePointByIdAsync(id);
            if (point != null)
            {
                _manager.GeoPointRepository.DeleteOnePoint(point);
                await _manager.SaveAsync();
            }
            else throw new Exception($"Point with id: {id} could not be found.");
        }

        public async Task<IEnumerable<GeoPointDto>> GetAllPointsAsync()
        {
            var points = await _manager.GeoPointRepository
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
            var point = await _manager.GeoPointRepository.GetOnePointByIdAsync(id);
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
            var point = await _manager.GeoPointRepository.GetOnePointByIdAsync(id);
            if(point != null)
            {
                point.Name = geoPointDto.Name;
                point.Coordinate = new Point(geoPointDto.Longitude, geoPointDto.Latitude) { SRID = 4326 };

                _manager.GeoPointRepository.UpdateOnePoint(point);
                await _manager.SaveAsync();

                return geoPointDto;
            }
            else throw new Exception($"Point with id: {id} could not be found.");

        }
    }
}
