using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using LinXiDecorate.Configuration;
using LinXiDecorate.EntityFrameworkCore;
using LinXiDecorate.Migrator.DependencyInjection;

namespace LinXiDecorate.Migrator
{
    [DependsOn(typeof(LinXiDecorateEntityFrameworkModule))]
    public class LinXiDecorateMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public LinXiDecorateMigratorModule(LinXiDecorateEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(LinXiDecorateMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                LinXiDecorateConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LinXiDecorateMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
