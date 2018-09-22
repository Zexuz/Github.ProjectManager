namespace GithubProjectManager.Core.Models
{
    public class GithubProject
    {
        public string Name                { get; }
        public string DoneColumnName      { get; }
        public int    MaxDaysInDoneColumn { get; }

        public GithubProject(string name, string doneColumnName, int maxDaysInDoneColumn)
        {
            Name = name;
            DoneColumnName = doneColumnName;
            MaxDaysInDoneColumn = maxDaysInDoneColumn;
        }
    }
}