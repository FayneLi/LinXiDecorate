using System.Threading.Tasks;
using Abp.Application.Services;
using LinXiDecorate.Authorization.Accounts.Dto;

namespace LinXiDecorate.Authorization.Accounts
{
    public interface IAccountAppService : IApplicationService
    {
        Task<IsTenantAvailableOutput> IsTenantAvailable(IsTenantAvailableInput input);

        Task<RegisterOutput> Register(RegisterInput input);
    }
}
