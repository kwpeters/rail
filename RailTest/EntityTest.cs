using Microsoft.VisualStudio.TestTools.UnitTesting;
using rail;
using System;

namespace RailTest
{
    class Person : Entity
    {
        #region Static Data Members
        private static long _nextId = 0;
        #endregion

        public static Person create(string firstName, string lastName)
        {
            // This instance's ID.
            string id = $"person_{_nextId}";

            // Prepare for the next instance.
            _nextId += 1;

            var person = new Person(id, firstName, lastName);
            return person;
        }

        #region Instance Data Members
        private readonly string _firstName;
        private readonly string _lastName;
        #endregion

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
            // Entities use identifier equality.  Even through they may be
            // structurally identical, their identifiers will never be equal.
            var person1 = Person.create("Fred", "Flintstone");
            var person2 = Person.create("Fred", "Flintstone");
            Assert.IsFalse(person1 == person2);
            Assert.IsFalse(person1.Equals(person2));
            Assert.IsTrue(person1 != person2);
        }
    }

}
