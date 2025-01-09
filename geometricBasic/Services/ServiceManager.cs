using geometricBasic.Services.Contracts;

namespace geometricBasic.Services
{
    public class ServiceManager : IServiceManager
    {
        private readonly IGeoPointService _geoPointService;

        public ServiceManager(IGeoPointService geoPointService)
        {
            _geoPointService = geoPointService;
        }

        public IGeoPointService GeoPointService => _geoPointService;
    }
}
