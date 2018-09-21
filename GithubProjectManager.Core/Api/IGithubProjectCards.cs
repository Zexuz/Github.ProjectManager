using System.Threading.Tasks;
using GithubProjectManager.Core.Resources;
using Refit;

namespace GithubProjectManager.Core.Api
{
    public interface IGithubProjectCards
    {
        [Get("/projects/columns/{columnIdd}/cards")]
        Task<CardResource[]> GetColumns(int columnIdd);

        [Post("/projects/columns/cards/{cardId}")]
        Task<CardResource> ArchiveCard(int cardId);
    }
}