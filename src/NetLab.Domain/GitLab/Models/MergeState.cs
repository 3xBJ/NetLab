using System.ComponentModel;

namespace NetLab.GitLab.Modelos.GitLab
{
    public enum MergeState
    {
        [Description("opened")]
        Aberto,

        [Description("closed")]
        Fechado,

        [Description("locked")]
        Travado,

        [Description("merged")]
        Mergeado,
    }
}
