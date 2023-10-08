using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTesting;

namespace UnitTestingTests
{
    [TestClass]
    public class CountSameDigitsTest
    {
        public static IEnumerable<object[]> SameNumbersData
        {
            get
            {
                return new[]
                {
                    new object[] { "as12d", 1 },
                    new object[] { "223a42aaaaasd12311123", 3 },
                    new object[] { "aa33s22222ed1111121ddfjlf", 5 },
                    new object[] { "asdjaaa11222223", 5 }
                };
            }
        }
        private CharsCounter _charsCounter;

        [TestInitialize]
        public void TestInitialize()
        {
            _charsCounter = this.CharsCountersFactory();
        }

        [TestMethod()]
        [DynamicData(nameof(SameNumbersData))]
        public void CountSameDigits_ShouldReturnCorrectNumberOfSameDigits(string str, int expected)
        {
            //Act
            int actual = _charsCounter.CountSameDigits(str);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        [DataRow("aasjjekdhajshhsjee")]
        public void CountSameDigits_ShouldThrowArgumentException(string str)
        {
            //Act
            Action action = () => _charsCounter.CountSameDigits(str);

            //Assert
            Assert.ThrowsException<ArgumentException>(action);
        }

        private CharsCounter CharsCountersFactory()
        {
            return new CharsCounter();
        }
    }
}
