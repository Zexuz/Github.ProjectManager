using System.Linq;
using Autofac;
using GithubProjectManager.Core.Api;
using GithubProjectManager.Core.Models;
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
            builder.Register(context => BuildGithubConfiguration()).AsSelf();
        }

        private GithubConfiguration BuildGithubConfiguration()
        {
            var repository = _configuration.GetSection(ConfigurationConstants.RepositoriesRoot);

            var repois = repository.GetChildren()
                .Select(section => new GithubRepository
                    (
                        section["Owner"],
                        section["Name"],
                        section
                            .GetSection("Projects")
                            .GetChildren()
                            .Select(
                                configurationSection => new GithubProject
                                (
                                    configurationSection["name"],
                                    configurationSection["DoneColumnName"],
                                    configurationSection.GetSection("MaxDaysInDoneColumn").Get<int>()
                                )
                            ).ToList()
                    )
                )
                .ToList();


//            Console.WriteLine(_configuration["Github:Repositories:0:Owner"]);

            var token = _configuration[ConfigurationConstants.TokenPath];
            var baseUrl = _configuration[ConfigurationConstants.BaseUrl];

            return new GithubConfiguration(token, baseUrl, repois);
        }
    }
}