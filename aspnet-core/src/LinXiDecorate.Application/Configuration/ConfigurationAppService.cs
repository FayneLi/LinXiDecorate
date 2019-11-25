using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using LinXiDecorate.Configuration.Dto;

namespace LinXiDecorate.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : LinXiDecorateAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
