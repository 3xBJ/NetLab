using NetLab.Domain.Clients.REST;
using NetLab.Domain.GitLab.Clients;
using NetLab.GitLab;
using NetLab.GitLab.Util.Wrappers.Http.Interfaces;
using NetLab.Infrastructure.GitLab.Wrappers.Http;

namespace NetLab.Infrastructure.Clients
{
    public static class ClientFactory
    {
        private static string HEADER_TOKEN = "private-token";

        public static IGitLabClient ResolveREST(HttpClient httpClient, string gitlabUri, string gitlabToken)
        {
            IHttpClient httpWrapper = new HttpClientWrapper(httpClient, gitlabUri);
            httpWrapper.AddRequestHeader(HEADER_TOKEN, gitlabToken);

            PaginatedHttpClient paginatedHttp = new(httpWrapper);
            IssueClient Issue = new(paginatedHttp);
            MergeRequestClient MergeRequest = new(paginatedHttp);
            MilestoneClient Milestone = new(paginatedHttp);
            LabelClient Labels = new(paginatedHttp);

            return new GitLabClient(Issue, MergeRequest, Milestone, Labels);
        }
    }
}
