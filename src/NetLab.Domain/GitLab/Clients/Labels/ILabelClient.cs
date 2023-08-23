using NetLab.GitLab.Modelos.GitLab;

namespace NetLab.Domain.GitLab.Clients.Labels
{
    /// <summary>
    /// Represents a client for working with labels in a GitLab project.
    /// </summary>
    public interface ILabelClient : IBaseClient<Label, SelectLabelRequest> { }
}
