using System.ComponentModel;

namespace NetLab.GitLab.Modelos.GitLab
{
    public enum StatusIssue
    {
        [Description("opened")]
        Aberta,

        [Description("closed")]
        Fechada,

        [Description("all")]
        Todas
    }
}
