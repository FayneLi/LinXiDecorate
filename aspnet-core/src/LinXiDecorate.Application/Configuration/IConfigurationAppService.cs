using System.Threading.Tasks;
using LinXiDecorate.Configuration.Dto;

namespace LinXiDecorate.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
