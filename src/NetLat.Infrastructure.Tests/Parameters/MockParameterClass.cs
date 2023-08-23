using NetLab.Domain.Parameters;
using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace NetLab.Infrastructure.Tests.Parameters
{
    public class MockParameterClass
    {
        public string? NoParameter { get; set; }

        [Parameter("parametroString")]
        public string? WithString { get; set; }

        [Parameter("parametroDateTime")]
        public DateTime? WithDateTime { get; set; }

        [Parameter("parametroArray")]
        public IEnumerable<string>? WithEnumerableParameter { get; set; }

        [Parameter("parametroEnum")]
        public Tipos? WithEnumParameter { get; set; }

        [Parameter("parametroArrayNString")]
        public IEnumerable<int>? WithEnumerableParameter2 { get; set; }
    }

    public enum Tipos
    {
        [Description("Beetle")]
        Besouro
    }
}
