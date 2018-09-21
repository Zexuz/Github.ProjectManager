using System;
using System.Linq;
using System.Threading.Tasks;
using GithubProjectManager.Core.Api;
using Microsoft.Extensions.Configuration;

namespace GithubProjectManager.Core.Services
{
    public class GithubService
    {
        private readonly GithubClientFactory _githubClientFactory;
        private readonly IConfiguration      _configuration;

        public GithubService(GithubClientFactory githubClientFactory, IConfiguration configuration)
        {
            _githubClientFactory = githubClientFactory;
            _configuration = configuration;
        }

        public async Task RemoveOldCards()
        {
            var ownerName = _configuration[ConfigurationConstants.RepoOwner];
            var repoName = _configuration[ConfigurationConstants.RepoName];

            var projectName = _configuration[ConfigurationConstants.ProjectName];

            var doneColumnName = _configuration[ConfigurationConstants.DoneColumnName];

            var maxTimeInDoneColumn = TimeSpan.FromDays(int.Parse(_configuration[ConfigurationConstants.MaxDaysInDoneColumn]));


            var githubClient = _githubClientFactory.Create();

            var projects = await githubClient.GetProjects(ownerName, repoName);

            var project = projects.First(p => p.Name.Trim() == projectName.Trim());

            var columns = await githubClient.GetColumns(project.Id);

            var doneColumn = columns.First(column => column.Name == doneColumnName);

            var cards = await githubClient.GetCards(doneColumn.Id);

            foreach (var card in cards)
            {
                var lastUpdated = card.UpdatedAt.ToUniversalTime();
                if (card.Archived) continue;
                if (DateTimeOffset.Now.ToUniversalTime() - lastUpdated < maxTimeInDoneColumn) continue;

               var response  = await githubClient.UpdateCard(card.Id,new CardPostData{Archived= true});
                Console.WriteLine($"Archived card: \n{card.Note}" );
            }
        }
    }
}