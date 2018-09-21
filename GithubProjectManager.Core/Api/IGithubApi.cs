using System.Threading.Tasks;
using GithubProjectManager.Core.Resources;
using Newtonsoft.Json;
using Refit;

namespace GithubProjectManager.Core.Api
{
    public interface IGithubApi
    {
        [Headers("Accept: application/vnd.github.inertia-preview+json")]
        [Get("/projects/{projectId}/columns")]
        Task<ColumnsResource[]> GetColumns(int projectId);

        [Headers("Accept: application/vnd.github.inertia-preview+json")]
        [Get("/projects/columns/{columnId}/cards")]
        Task<CardResource[]> GetCards(int columnId);

        [Headers("Accept: application/vnd.github.inertia-preview+json")]
        [Patch("/projects/columns/cards/{cardId}")]
        Task<CardResource> UpdateCard(int cardId,[Body] CardPostData cardPostData);

        [Headers("Accept: application/vnd.github.inertia-preview+json")]
        [Get("/repos/{ownerName}/{repoName}/projects")]
        Task<ProjectResource[]> GetProjects(string ownerName, string repoName);
    }

    public class CardPostData
    {
        [JsonProperty("archived")]
        public bool Archived { get; set; }
    } 
}