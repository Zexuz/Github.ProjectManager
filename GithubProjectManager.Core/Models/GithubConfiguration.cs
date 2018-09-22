using System.Collections.Generic;

namespace GithubProjectManager.Core.Models
{
    public class GithubConfiguration
    {
        public string                 Token        { get; }
        public string                 BaseUrl      { get; }
        public List<GithubRepository> Repositories { get; }

        public GithubConfiguration(string token, string baseUrl, List<GithubRepository> repositories)
        {
            Token = token;
            BaseUrl = baseUrl;
            Repositories = repositories;
        }
    }
}