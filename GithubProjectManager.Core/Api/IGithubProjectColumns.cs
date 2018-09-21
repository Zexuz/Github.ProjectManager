using System.Threading.Tasks;
using GithubProjectManager.Core.Resources;
using Refit;

namespace GithubProjectManager.Core.Api
{
    public interface IGithubProjectColumns
    {
        [Get("/projects/{projectId}/columns")]
        Task<ColumnsResource> GetColumns(int projectId);
    }
}