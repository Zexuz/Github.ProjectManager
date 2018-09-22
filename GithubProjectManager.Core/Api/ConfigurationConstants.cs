namespace GithubProjectManager.Core.Api
{
    internal static class ConfigurationConstants
    {
        public const string Root = "Github";

        public static readonly string TokenPath = $"{Root}:Token";
        public static readonly string BaseUrl   = $"{Root}:BaseUrl";

        public static readonly string RepositoriesRoot = $"{Root}:Repositories";

        public static readonly string RepoOwner = $"{RepositoriesRoot}:Owner";
        public static readonly string RepoName  = $"{RepositoriesRoot}:Name";

        public static readonly string ProjectName = $"{Root}:ProjectName";

        public static readonly string DoneColumnName      = $"{Root}:DoneColumnName";
        public static readonly string MaxDaysInDoneColumn = $"{Root}:MaxDaysInDoneColumn";
    }
}