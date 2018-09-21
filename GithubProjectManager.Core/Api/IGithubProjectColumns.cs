using System.Threading.Tasks;
using GithubProjectManager.Core.Resources;
using Refit;

namespace GithubProjectManager.Core.Api
{
    public interface IGithubProjectColumns
    {
        [Headers("Accept: application/vnd.github.inertia-preview+json")]
        [Get("/projects/{projectId}/columns")]
        Task<ColumnsResource[]> GetColumns(int projectId);
    }
}