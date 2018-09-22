using System.Threading.Tasks;
using Autofac;
using GithubProjectManager.Core.Api;
using GithubProjectManager.Core.IoC;
using GithubProjectManager.Core.Services;
using Microsoft.Extensions.Configuration;
using Refit;

namespace Github.ProjectManager.Application
{
    public class Application
    {
        public IContainer Container { get; private set; }

        public Application(IConfigurationRoot config)
        {
            BuildIoC(config);
        }

        private void BuildIoC(IConfiguration configuration)
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule(new DependencyInjectionModule(configuration));
            Container = builder.Build();
        }

        public async Task Start()
        {
            var githubService = Container.Resolve<GithubService>();
            await githubService.ArchiveOldCards();
        }
    }
}