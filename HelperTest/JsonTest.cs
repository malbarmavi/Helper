using Helper;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace HelperTest
{
    [TestClass]
    public class JsonTest
    {
        [TestMethod]
        public void StringifyParse()
        {
            Person creater = new Person
            {
                Name = "mhd",
                Age = 26,
                BirthDay = new DateTime(1990, 1, 9),
                StateAddress = new Address
                {
                    Country = "Turkey",
                    City = "Istanbul",
                    ZipCode = 220542
                }
            };

            var newCreater = Json.parse<Person>(Json.Stringify(creater));
            Assert.AreEqual(newCreater, creater);
        }

#pragma warning disable CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()

        private class Person
#pragma warning restore CS0659 // Type overrides Object.Equals(object o) but does not override Object.GetHashCode()
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public DateTime BirthDay { get; set; }
            public Address StateAddress { get; set; }

            public override bool Equals(object obj)
            {
                Person anotherObj = obj as Person;
                if (obj == null)
                {
                    return false;
                }

                return (Name == anotherObj.Name)
                        && (Age == anotherObj.Age)
                        && (BirthDay.Day == anotherObj.BirthDay.Day)
                        && (BirthDay.Year == anotherObj.BirthDay.Year)
                        && (BirthDay.Month == anotherObj.BirthDay.Month)
                        && (StateAddress.City == anotherObj.StateAddress.City)
                        && (StateAddress.Country == anotherObj.StateAddress.Country)
                        && (StateAddress.ZipCode == anotherObj.StateAddress.ZipCode);
            }
        }

        private class Address
        {
            public string Country { get; set; }
            public string City { get; set; }
            public int ZipCode { get; set; }
        }
    }
}