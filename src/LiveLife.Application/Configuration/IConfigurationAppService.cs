using System.Threading.Tasks;
using LiveLife.Configuration.Dto;

namespace LiveLife.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
