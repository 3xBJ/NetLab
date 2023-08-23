namespace NetLab.Infrastructure.Clients.REST
{
    internal static class URLs
    {
        private const string ISSUE_URL = "projects/{0}/issues{1}";
        private const string MR_URL = "projects/{0}/merge_requests{1}";
        private const string ISSUE_RELATED_MR = "projects/{0}/issues/{1}/related_merge_requests{2}";
        private const string ISSUE_STATISTICS = "projects/{0}/issues_statistics{1}";
        private const string LABEL_URL = "/projects/{0}/labels/{1}";
        private const string MILESTONES_URL = "projects/{0}/milestones{1}";

        internal static string GetIssueUrl(int projectId, string parameters) => string.Format(ISSUE_URL, projectId, parameters);
        internal static string GetIssueStatisticsUrl(int projectId, string parameters) => string.Format(ISSUE_STATISTICS, projectId, parameters);

        internal static string GetRelatedMRUrl(int projectID, long issueID, string parameters) => string.Format(ISSUE_RELATED_MR, projectID, issueID, parameters);
        internal static string GetMergeRequestUrl(int projectID, string parameters) => string.Format(MR_URL, projectID, parameters);

        internal static string GetLabelsUrl(int projectID, string parameters) => string.Format(LABEL_URL, projectID, parameters);
        internal static string GetMilestonesUrl(int projectID, string parameters) => string.Format(MILESTONES_URL, projectID, parameters);
    }
}
