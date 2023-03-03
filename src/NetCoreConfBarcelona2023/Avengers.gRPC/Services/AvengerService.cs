using Avengers.API.Service;
using Grpc.Core;
using GrpcAvenger;

namespace Avengers.gRPC.Services
{
    public class AvengerGrpcService : Avenger.AvengerBase
    {
        private readonly ILogger<AvengerGrpcService> _logger;
        private IAvengerService _avengerService { get; set; }

        public AvengerGrpcService(ILogger<AvengerGrpcService> logger, IAvengerService service)
        {
            this._logger=logger;
            this._avengerService=service;
        }

        public override async Task<GetAllReply> GetAll(Google.Protobuf.WellKnownTypes.Empty request, ServerCallContext context)
        {
            _logger.LogInformation("Init GetAll");
            var response = new GetAllReply();
            var result = await _avengerService.GetAll();
            foreach (var item in result)
            {
                response.Name.Add(
                    new AvengerCharacter
                    {
                        Id= item.Id,
                        Photo= item.Photo,
                        Name= item.Name
                    });
            }            
            return response;
        }

        public override async Task<GetReply> Get(IdAvenger request, ServerCallContext context)
        {
            _logger.LogInformation("Init GetAll");
            var result = await _avengerService.Get((string)request.Name);
            var response = new GetReply
            {
                Message= new AvengerCharacter
                {
                    Id= result.Id,
                    Photo= result.Photo,
                    Name= result.Name
                }
            };
            return response;
        }
    }
}
