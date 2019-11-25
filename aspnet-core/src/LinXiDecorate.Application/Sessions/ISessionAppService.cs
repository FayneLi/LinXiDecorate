using System.Threading.Tasks;
using Abp.Application.Services;
using LinXiDecorate.Sessions.Dto;

namespace LinXiDecorate.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
