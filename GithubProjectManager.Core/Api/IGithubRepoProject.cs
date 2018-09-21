using System.Threading.Tasks;
using GithubProjectManager.Core.Resources;
using Refit;

namespace GithubProjectManager.Core
{
    public interface IGithubRepoProject
    {
        [Get("/repos/{ownerName}/{repoName}/projects")]
        Task<ProjectResource[]> GetProjects(string ownerName, string repoName);
    }
}