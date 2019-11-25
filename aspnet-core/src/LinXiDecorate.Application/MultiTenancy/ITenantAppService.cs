using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LinXiDecorate.MultiTenancy.Dto;

namespace LinXiDecorate.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedTenantResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}

