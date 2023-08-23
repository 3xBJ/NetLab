using System.ComponentModel;

namespace NetLab.GitLab.Modelos.GitLab
{
    public enum MilestoneState
    {
        [Description("active")]
        Ativa,

        [Description("closed")]
        Fechada
    }
}
