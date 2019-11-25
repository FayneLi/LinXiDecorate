using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LinXiDecorate.Authorization;

namespace LinXiDecorate
{
    [DependsOn(
        typeof(LinXiDecorateCoreModule), 
        typeof(AbpAutoMapperModule))]
    public class LinXiDecorateApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<LinXiDecorateAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(LinXiDecorateApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddMaps(thisAssembly)
            );
        }
    }
}
