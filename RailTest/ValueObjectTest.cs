using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using rail;


namespace RailTest
{

    class Money : ValueObject<Money>
    {
        private readonly long _numCents;

        public Money(long numCents)
        {
            _numCents = numCents;
        }

        protected override bool EqualsImpl(Money other)
        {
            return _numCents == other._numCents;
        }

        protected override int GetHashCodeImpl()
        {
            return _numCents.GetHashCode();
        }
    }


    [TestClass]
    public class ValueObjectTest
    {
        [TestMethod]
        public void TwoInstances_WithEqualValues_AreEqual()
        {
            var moneyA = new Money(500);
            var moneyB = new Money(500);
            Assert.IsTrue(moneyA == moneyB);
            Assert.IsFalse(moneyA != moneyB);
            Assert.IsTrue(moneyA.Equals(moneyB));
        }


        [TestMethod]
        public void TwoInstances_WithDifferentValues_AreNotEqual()
        {
            var moneyA = new Money(500);
            var moneyB = new Money(501);
            Assert.IsFalse(moneyA == moneyB);
            Assert.IsTrue(moneyA != moneyB);
            Assert.IsFalse(moneyA.Equals(moneyB));

        }


        [TestMethod]
        public void TwoInstances_WithEqualValues_HaveSameHashCodes()
        {
            var moneyA = new Money(500);
            var moneyB = new Money(500);
            Assert.IsTrue(moneyA.GetHashCode() == moneyB.GetHashCode());
        }


        [TestMethod]
        public void TwoInstances_WithDifferentValues_HaveDifferentHashCodes()
        {
            var moneyA = new Money(500);
            var moneyB = new Money(501);
            Assert.IsTrue(moneyA.GetHashCode() != moneyB.GetHashCode());
        }

    }
}


