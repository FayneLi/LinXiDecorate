using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LinXiDecorate.Configuration;

namespace LinXiDecorate.Web.Host.Startup
{
    [DependsOn(
       typeof(LinXiDecorateWebCoreModule))]
    public class LinXiDecorateWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public LinXiDecorateWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LinXiDecorateWebHostModule).GetAssembly());
        }
    }
}
