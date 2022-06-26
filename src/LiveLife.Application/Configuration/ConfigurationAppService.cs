using System.Threading.Tasks;
using Abp.Authorization;
using Abp.Runtime.Session;
using LiveLife.Configuration.Dto;

namespace LiveLife.Configuration
{
    [AbpAuthorize]
    public class ConfigurationAppService : LiveLifeAppServiceBase, IConfigurationAppService
    {
        public async Task ChangeUiTheme(ChangeUiThemeInput input)
        {
            await SettingManager.ChangeSettingForUserAsync(AbpSession.ToUserIdentifier(), AppSettingNames.UiTheme, input.Theme);
        }
    }
}
