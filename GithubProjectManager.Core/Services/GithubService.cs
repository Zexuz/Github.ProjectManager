using System;
using System.Linq;
using System.Threading.Tasks;
using GithubProjectManager.Core.Api;
using GithubProjectManager.Core.Models;
using GithubProjectManager.Core.Resources;

namespace GithubProjectManager.Core.Services
{
    public class GithubService
    {
        private readonly GithubClientFactory _githubClientFactory;
        private readonly GithubConfiguration _configuration;

        public GithubService(GithubClientFactory githubClientFactory, GithubConfiguration configuration)
        {
            _githubClientFactory = githubClientFactory;
            _configuration = configuration;
        }

        public async Task ArchiveOldCards()
        {
            var githubClient = _githubClientFactory.Create();

            foreach (var githubRepository in _configuration.Repositories)
            {
                var projects = await githubClient.GetProjects(githubRepository.Owner, githubRepository.Name);

                foreach (var project in githubRepository.Projects)
                {
                    var projectId = GetProjectId(projects, project);

                    var column = await GetColumn(githubClient, projectId, project);

                    var cards = await githubClient.GetCards(column.Id);

                    foreach (var card in cards)
                    {
                        if (!ShouldArchiveCard(card, project)) continue;

                        await githubClient.UpdateCard(card.Id, new CardPostData {Archived = true});
                    }
                }
            }
        }

        private static bool ShouldArchiveCard(CardResource card, GithubProject project)
        {
            var lastUpdated = card.UpdatedAt.ToUniversalTime();
            if (card.Archived) return false;
            if (DateTimeOffset.Now.ToUniversalTime() - lastUpdated < TimeSpan.FromDays(project.MaxDaysInDoneColumn)) return false;
            return true;
        }

        private static int GetProjectId(ProjectResource[] projects, GithubProject project)
        {
            var projectId = projects.First(resource => resource.Name.Trim() == project.Name).Id;
            return projectId;
        }

        private static async Task<ColumnsResource> GetColumn(IGithubApi githubClient, int projectId, GithubProject project)
        {
            var columns = await githubClient.GetColumns(projectId);

            var doneColumn = columns.First(column => column.Name == project.DoneColumnName);
            return doneColumn;
        }
    }
}