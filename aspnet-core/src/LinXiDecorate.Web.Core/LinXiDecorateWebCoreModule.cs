﻿using System;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Abp.AspNetCore;
using Abp.AspNetCore.Configuration;
using Abp.AspNetCore.SignalR;
using Abp.Modules;
using Abp.Reflection.Extensions;
using Abp.Zero.Configuration;
using LinXiDecorate.Authentication.JwtBearer;
using LinXiDecorate.Configuration;
using LinXiDecorate.EntityFrameworkCore;
using LinXiDecorate.Authentication.External;

namespace LinXiDecorate
{
    [DependsOn(
         typeof(LinXiDecorateApplicationModule),
         typeof(LinXiDecorateEntityFrameworkModule),
         typeof(AbpAspNetCoreModule)
        ,typeof(AbpAspNetCoreSignalRModule)
     )]
    public class LinXiDecorateWebCoreModule : AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public LinXiDecorateWebCoreModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                LinXiDecorateConsts.ConnectionStringName
            );

            // Use database for language management
            Configuration.Modules.Zero().LanguageManagement.EnableDbLocalization();

            Configuration.Modules.AbpAspNetCore()
                 .CreateControllersForAppServices(
                     typeof(LinXiDecorateApplicationModule).GetAssembly()
                 );

            ConfigureTokenAuth();

            ConfigureExternalAuthProviders();
        }

        public void ConfigureExternalAuthProviders()
        {
            IocManager.Register<ExternalLoginProviderInfo>();
            IocManager.Register<IExternalAuthConfiguration, ExternalAuthConfiguration>();
            var externalAuthConfiguration = IocManager.Resolve<ExternalAuthConfiguration>();
            if (bool.Parse(_appConfiguration["Authentication:WeChatMiniProgram:IsEnabled"]))
            {
                externalAuthConfiguration.Providers.Add(
                    new ExternalLoginProviderInfo(
                       WechatMiniProgramAuthProviderApi.ProviderName,
                       _appConfiguration["Authentication:WeChatMiniProgram:AppId"],
                       _appConfiguration["Authentication:WeChatMiniProgram:Secret"],
                       typeof(WechatMiniProgramAuthProviderApi)
                    )
                );
            }
        }

        private void ConfigureTokenAuth()
        {
            IocManager.Register<TokenAuthConfiguration>();
            var tokenAuthConfig = IocManager.Resolve<TokenAuthConfiguration>();

            tokenAuthConfig.SecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_appConfiguration["Authentication:JwtBearer:SecurityKey"]));
            tokenAuthConfig.Issuer = _appConfiguration["Authentication:JwtBearer:Issuer"];
            tokenAuthConfig.Audience = _appConfiguration["Authentication:JwtBearer:Audience"];
            tokenAuthConfig.SigningCredentials = new SigningCredentials(tokenAuthConfig.SecurityKey, SecurityAlgorithms.HmacSha256);
            tokenAuthConfig.Expiration = TimeSpan.FromDays(1);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(LinXiDecorateWebCoreModule).GetAssembly());
        }
    }
}
