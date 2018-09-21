using System.Threading.Tasks;
using Autofac;
using GithubProjectManager.Core;
using Microsoft.Extensions.Configuration;

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
//            var jobManager = Container.Resolve<JobManager>();
//            await jobManager.StartJobs();
        }
    }
}