using System.Threading.Tasks;
using Abp.Application.Services;
using Abp.Application.Services.Dto;
using LinXiDecorate.Roles.Dto;
using LinXiDecorate.Users.Dto;

namespace LinXiDecorate.Users
{
    public interface IUserAppService : IAsyncCrudAppService<UserDto, long, PagedUserResultRequestDto, CreateUserDto, UserDto>
    {
        Task<ListResultDto<RoleDto>> GetRoles();

        Task ChangeLanguage(ChangeUserLanguageDto input);
    }
}
