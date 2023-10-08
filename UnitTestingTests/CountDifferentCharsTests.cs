using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTesting;

namespace UnitTestingTests
{
    [TestClass]
    public class CountDifferentCharsTests
    {
        public static IEnumerable<object[]> DifferentCharsData
        {
            get
            {
                return new[]
                {
                    new object[] { "asd", 3 },
                    new object[] { "aaaaaasd", 3 },
                    new object[] { "aasedddfjlf", 5 },
                    new object[] { "asdjaaa", 5 },
                    new object[] { "aasjjekdhajshhsjee", 9 }
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
        [DynamicData(nameof(DifferentCharsData))]
        public void CountDifferentChars_ShouldReturnCorrectNumberOfDifferentChars(string str, int expected)
        {
            //Act
            int actual = _charsCounter.CountDifferentChars(str);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        public void CountDifferentChars_ShouldThrowArgumentException(string str)
        {
            //Act
            Action action = () => _charsCounter.CountDifferentChars(str);

            //Assert
            Assert.ThrowsException<ArgumentException>(action);
        }

        private CharsCounter CharsCountersFactory()
        {
            return new CharsCounter();
        }
    }
}
