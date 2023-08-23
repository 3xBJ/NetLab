namespace NetLab.Domain.Parameters
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ParameterAttribute : Attribute
    {
        public ParameterAttribute(string name) => Name = name;

        public string Name {get;}
    }
}
