using System.Threading.Tasks;
using GithubProjectManager.Core.Resources;
using Refit;

namespace GithubProjectManager.Core.Api
{
    public interface IGithubProjectCards
    {
        [Headers("Accept: application/vnd.github.inertia-preview+json")]
        [Get("/projects/columns/{columnId}/cards")]
        Task<CardResource[]> GetCards(int columnId);

        [Headers("Accept: application/vnd.github.inertia-preview+json")]
        [Post("/projects/columns/cards/{cardId}")]
        Task<CardResource> ArchiveCard(int cardId);
    }
}