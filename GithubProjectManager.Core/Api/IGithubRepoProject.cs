using System.Threading.Tasks;
using GithubProjectManager.Core.Resources;
using Refit;

namespace GithubProjectManager.Core.Api
{
    public interface IGithubRepoProject
    {
        [Headers("Accept: application/vnd.github.inertia-preview+json")]
        [Get("/repos/{ownerName}/{repoName}/projects")]
        Task<ProjectResource[]> GetProjects(string ownerName, string repoName);
    }
}