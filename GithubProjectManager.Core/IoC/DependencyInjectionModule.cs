using Autofac;
using GithubProjectManager.Core.Api;
using GithubProjectManager.Core.Services;
using Microsoft.Extensions.Configuration;

namespace GithubProjectManager.Core.IoC
{
    public class DependencyInjectionModule : Module
    {
        private readonly IConfiguration _configuration;

        public DependencyInjectionModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(context => _configuration).AsSelf();
            builder.RegisterType<GithubClientFactory>().AsSelf();
            builder.RegisterType<GithubService>().AsSelf();
        }
    }
}