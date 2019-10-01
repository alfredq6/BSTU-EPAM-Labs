using NUnit.Framework;
using TriangleProj;

namespace Tests
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }
        //data provider
        [TestCase(0)]
        [TestCase(-5)]
        public void SideACannotGetZeroAndLess(int value)
        {
            Assert.IsFalse(Triangle.CheckIsPossibleToCreate(value, 1, 2));
        }

        [TestCase(0)]
        [TestCase(-5)]
        public void SideBCannotGetZeroAndLess(int value)
        {
            Assert.IsFalse(Triangle.CheckIsPossibleToCreate(1, value, 2));
        }

        [TestCase(0)]
        [TestCase(-5)]
        public void SideCCannotGetZeroAndLess(int value)
        {
            Assert.IsFalse(Triangle.CheckIsPossibleToCreate(3, 1, value));
        }

        [Test]
        public void SideANotLessBAndCSum()
        {
            Assert.IsFalse(Triangle.CheckIsPossibleToCreate(4, 1, 3));
        }

        [Test]
        public void SideBNotLessCAndASum()
        {
            Assert.IsFalse(Triangle.CheckIsPossibleToCreate(1, 4, 3));
        }

        [Test]
        public void SideCNotLessBAndASum()
        {
            Assert.IsFalse(Triangle.CheckIsPossibleToCreate(3, 4, 1));
        }

        [Test]
        public void TrueSides()
        {
            Assert.IsTrue(Triangle.CheckIsPossibleToCreate(1, 1, 1));
        }
    }
}