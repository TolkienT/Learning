using Grpc.Core;
using Mapservice.AreaInfo;

namespace GrpcDemo.Service.Services
{
    public class AreaFenceInfoService : AreaFenceInfo.AreaFenceInfoBase
    {

        private readonly ILogger<AreaFenceInfoService> _logger;
        public AreaFenceInfoService(ILogger<AreaFenceInfoService> logger)
        {
            _logger = logger;
        }

        public override Task<GetAreaBoundaryPointsResp> GetAreaBoundaryPoints(GetAreaBoundaryPointsReq request, ServerCallContext context)
        {
            return Task.FromResult(new GetAreaBoundaryPointsResp());
        }
    }
}
