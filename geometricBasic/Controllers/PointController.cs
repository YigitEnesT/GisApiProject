using geometricBasic.Models;
using geometricBasic.Models.Dto;
using geometricBasic.Repositories;
using geometricBasic.Services.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NetTopologySuite.Geometries;

namespace geometricBasic.Controllers
{
    [ApiController]
    [Route("api/geopoint")]
    public class PointController : ControllerBase
    {
        private readonly IServiceManager _manager;

        public PointController(IServiceManager manager)
        {
            _manager = manager;
        }

        [HttpPost]
        public async Task<Response<GeoPointDto>> CreateOnePoint([FromBody] GeoPointDto geoPointDto)
        {
            try
            {
                var point = await _manager.GeoPointService.CreateOnePointAsync(geoPointDto);
                return new Response<GeoPointDto>
                {
                    Value = point,
                    StatusCode = 201,
                    Message = "Point Created."
                };
            }
            catch (Exception ex)
            {
                return new Response<GeoPointDto>
                {
                    Value = geoPointDto,
                    StatusCode = 500,
                    Message = ex.Message
                };
            }
        }

        [HttpGet]
        public async Task<Response<IEnumerable<GeoPointDto>>> GetAllPoints()
        {
            try
            {
                var points = await _manager.GeoPointService.GetAllPointsAsync();

                return new Response<IEnumerable<GeoPointDto>>
                {
                    Value = points,
                    StatusCode = 200,
                    Message = "Successfull"
                };
            }
            catch (Exception ex)
            {
                return new Response<IEnumerable<GeoPointDto>>
                {
                    Value = null,
                    StatusCode = 500,
                    Message = ex.Message
                };
            }
            
        }

        [HttpGet("{id:int}")]
        public async Task<Response<GeoPointDto>> GetOnePoint(int id)
        {
            try
            {
                var point = await _manager.GeoPointService.GetOnePointByIdAsync(id);
                return new Response<GeoPointDto>
                {
                    Value = point,
                    StatusCode = 200,
                    Message = $"Point with id: {id} "
                };
            }
            catch (Exception ex)
            {
                return new Response<GeoPointDto>
                {
                    Value = null,
                    StatusCode = 500,
                    Message = ex.Message
                };
            }
        }

        [HttpDelete("{id:int}")]
        public async Task<Response<GeoPointDto>> DeleteOnePoint(int id)
        {
            try
            {
                await _manager.GeoPointService.DeleteOnePointAsync(id);

                return new Response<GeoPointDto>
                {
                    Value = null,
                    StatusCode = 200,
                    Message = $"Point with id : {id} deleted."
                };
            }
            catch (Exception ex)
            {
                return new Response<GeoPointDto>
                {
                    Value = null,
                    StatusCode = 500,
                    Message = ex.Message
                };
            }
            

        }

        [HttpPut("{id:int}")]
        public async Task<Response<GeoPointDto>> UpdateOnePoint(int id, [FromBody] GeoPointDto pointDto)
        {
            try
            {
                await _manager.GeoPointService.UpdateOnePointAsync(id, pointDto);
                return new Response<GeoPointDto>
                {
                    Value = pointDto,
                    StatusCode = 200,
                    Message = "Successfull"
                };
            }
            catch (Exception ex)
            {
                return new Response<GeoPointDto>
                {
                    Value = null,
                    StatusCode = 500,
                    Message = ex.Message
                };
            }
            
        }
    }
}
