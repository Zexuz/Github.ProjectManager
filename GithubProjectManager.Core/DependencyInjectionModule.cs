using Autofac.Core;
using Microsoft.Extensions.Configuration;
using Autofac.Features;

namespace GithubProjectManager.Core.Random
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