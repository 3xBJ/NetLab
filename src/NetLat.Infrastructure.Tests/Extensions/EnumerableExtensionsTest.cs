using NetLab.Infrastructure.Extensions;
using DescriptionAttribute = System.ComponentModel.DescriptionAttribute;

namespace NetLab.Infrastructure.Tests.Extensions
{
    [TestFixture]
    public class EnumerableExtensionsTest
    {
        [Test]
        public void GetDescription_EnumWithDescriptionAttribute_ShouldReturnDescription()
        {
            string result = EnumerableExtensions.GetDescription(TestEnum.EnumValueWithDescription);

            Assert.That(result, Is.EqualTo("DescriptionValue"));
        }

        [Test]
        public void GetDescription_EnumWithoutDescriptionAttribute_ShouldReturnStringValue()
        {
            string result = EnumerableExtensions.GetDescription(TestEnum.EnumValueWithoutDescription);

            Assert.That(result, Is.EqualTo("EnumValueWithoutDescription"));
        }
    }

    public enum TestEnum
    {
        [Description("DescriptionValue")]
        EnumValueWithDescription,

        EnumValueWithoutDescription
    }
}
