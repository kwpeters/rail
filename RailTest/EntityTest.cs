using Microsoft.VisualStudio.TestTools.UnitTesting;
using rail;
using System;

namespace RailTest
{
    class Person : Entity
    {
        private static long _nextId = 0;

        public static Person create(string firstName, string lastName)
        {
            // This instance's ID.
            string id = $"person_{_nextId}";

            // Prepare for the next instance.
            _nextId += 1;

            var person = new Person(id, firstName, lastName);
            return person;
        }


        private readonly string _firstName;
        private readonly string _lastName;

        private Person(string id, string firstName, string lastName): base(id)
        {
            _firstName = firstName;
            _lastName = lastName;
        }
    }



    [TestClass]
    public class EntityTest
    {
        [TestMethod]
        public void TwoObjects_WithEqualValues_AreNotEqual()
        {
            var person1 = Person.create("Fred", "Flintstone");
            var person2 = Person.create("Fred", "Flintstone");

            Console.WriteLine("person1 Id: {0}", person1.Id);
            Console.WriteLine("person2 Id: {0}", person2.Id);

            Assert.IsFalse(person1 == person2);
            Assert.IsFalse(person1.Equals(person2));
            Assert.IsTrue(person1 != person2);
        }
    }

}
