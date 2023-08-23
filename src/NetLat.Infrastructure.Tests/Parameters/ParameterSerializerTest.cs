using NetLab.Domain.Parameters;

namespace NetLab.Infrastructure.Parameters.Tests
{
    [TestFixture]
    public class ParameterSerializerTests
    {
        [Test]
        public void Serialize_ConfiguredObject_ReturnsQueryString()
        {
            SampleObject configuredObject = new()
            {
                Name = "John",
                Age = 30
            };

            string queryString = ParameterSerializer.Serialize(configuredObject);

            Assert.That(queryString, Is.EqualTo("?Name=John&Age=30"));
        }

        [Test]
        public void Serialize_EnumerableProperty_ReturnsConcatenatedValues()
        {
            SampleObject configuredObject = new()
            {
                Name = "John",
                Age = 30,
                Interests = new List<string> { "Music", "Sports", "Reading" }
            };

            string queryString = ParameterSerializer.Serialize(configuredObject);

            Assert.That(queryString, Is.EqualTo("?Name=John&Age=30&Interests=Music,Sports,Reading"));
        }

        // Add more tests as needed for the remaining functionality

        private class SampleObject
        {
            [Parameter("Name")]
            public string? Name { get; set; }

            [Parameter("Age")]
            public int Age { get; set; }

            [Parameter("Interests")]
            public IEnumerable<string>? Interests { get; set; }
        }
    }
}
