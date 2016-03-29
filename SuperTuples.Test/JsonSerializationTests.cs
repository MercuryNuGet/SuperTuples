using Mercury;
using Newtonsoft.Json;
using NUnit.Framework;

namespace SuperTuples.Test
{
    public sealed class JsonSerializationTests : MercurySuite
    {
        protected override void Specifications()
        {
            Specs += "When serializing #1 to json"
                .ArrangeNull()
                .With(new Person("Alan", "Evans", 35), "{\"FirstName\":\"Alan\",\"LastName\":\"Evans\",\"Age\":35}")
                .With(new Person("John", "Doe", 45), "{\"FirstName\":\"John\",\"LastName\":\"Doe\",\"Age\":45}")
                .Act((_, p, e) => JsonConvert.SerializeObject(p))
                .Assert("expect json to not include protected members", (r, expected) => Assert.AreEqual(expected, r));
        }

        public class Person : Suple<string, string, int>
        {
            public Person(string firstName, string lastName, int age)
                : base(firstName, lastName, age)
            {
            }

            public string FirstName => Item1;
            public string LastName => Item2;
            public int Age => Item3;
        }
    }
}
