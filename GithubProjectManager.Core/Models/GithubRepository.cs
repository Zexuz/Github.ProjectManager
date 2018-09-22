using System.Collections.Generic;

namespace GithubProjectManager.Core.Models
{
    public class GithubRepository
    {
        public string              Owner    { get; }
        public string              Name     { get; }
        public List<GithubProject> Projects { get; }

        public GithubRepository(string owner, string name, List<GithubProject> projects)
        {
            Owner = owner;
            Name = name;
            Projects = projects;
        }
    }
}