namespace GithubProjectManager.Core.Api
{
    internal static class ConfigurationConstants
    {
        private const           string Root     = "Github";
        private static readonly string RepoRoot = $"{Root}:Repo";

        public static readonly string TokenPath   = $"{Root}:Token";
        public static readonly string ProjectName = $"{Root}:ProjectName";

        public static readonly string RepoOwner = $"{RepoRoot}:Owner";
        public static readonly string RepoName  = $"{RepoRoot}:Name";

        public static readonly string BaseUrl             = $"{Root}:BaseUrl";
        public static readonly string DoneColumnName      = $"{Root}:DoneColumnName";
        public static readonly string MaxDaysInDoneColumn = $"{Root}:MaxDaysInDoneColumn";
    }
}