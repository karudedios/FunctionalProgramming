using FunctionalProgramming.Basics;
using FunctionalProgramming.Monad;
using NUnit.Framework;
using BF = FunctionalProgramming.Basics.BasicFunctions;

namespace FunctionalProgramming.Tests
{
    [TestFixture]
    public sealed class BasicFunctionsTests
    {
        [Test]
        public void TestEIf()
        {
            const string Abc = "abc";
            var randomInt = new System.Random().Next(3, 19);

            var test1 = BF.EIf(false, () => Abc, () => randomInt);
            Assert.AreEqual(Abc, test1.Match(left: n => n.ToString(), right: BF.Identity));

            var test2 = BF.EIf(false, () => test1, () => randomInt);
            Assert.AreEqual(Abc, test2.Match(left: n => n.ToString(), right: BF.Identity));

            var test3 = BF.EIf(false, () => Abc, () => test1);
            Assert.AreEqual(Abc, test3.Match(left: n => n.ToString(), right: BF.Identity));

            var test4 = BF.EIf(false, () => test1, () => test2);
            Assert.AreEqual(Abc, test4.Match(left: n => n.ToString(), right: BF.Identity));
        }

        [Test]
        public void TestTraverse()
        {
            var expected = new[] {1, 2, 3};
            var actual = expected.Traverse(n => Io.Apply(() => n)).UnsafePerformIo();

            Assert.AreEqual(expected, actual);
        }
    }
}
