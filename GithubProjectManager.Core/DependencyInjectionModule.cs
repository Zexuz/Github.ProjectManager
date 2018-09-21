using Autofac.Core;
using Microsoft.Extensions.Configuration;

namespace GithubProjectManager.Core
{
    public class DependencyInjectionModule : IModule
    {
        private readonly IConfiguration _configuration;

        public DependencyInjectionModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void Configure(IComponentRegistry componentRegistry)
        {
        }
    } //"https://api.github.com/"
}