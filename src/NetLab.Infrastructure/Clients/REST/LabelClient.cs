using NetLab.Domain.GitLab.Clients.Labels;
using NetLab.GitLab.Modelos.GitLab;
using NetLab.GitLab.Util.Wrappers.Http.Interfaces;
using NetLab.Infrastructure.Clients.REST;

namespace NetLab.Domain.Clients.REST
{
    /// <inheritdoc/>
    internal class LabelClient : BaseClient<Label, SelectLabelRequest>, ILabelClient
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="LabelClient"/> class.
        /// </summary>
        /// <param name="httpClient">An instance of the paginated HTTP client.</param>
        internal LabelClient(IPaginatedHttpClient httpClient) : base(httpClient) { }

        /// <inheritdoc/>
        protected override string GetUrl(int projectId, string parameters) => URLs.GetLabelsUrl(projectId, parameters);
    }
}