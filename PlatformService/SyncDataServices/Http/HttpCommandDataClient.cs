using PlatformService.Dtos;
using System.Net.Http;
using System.Threading.Tasks;

namespace PlatformService.SyncDataServices.Http
{
    public class HttpCommandDataClient : ICommandDataClient
    {
        private readonly HttpClient _httpClient;

        public HttpCommandDataClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public Task SendPlatformToCommand(PlatformReadDto plat)
        {
            throw new System.NotImplementedException();
        }
    }
}
