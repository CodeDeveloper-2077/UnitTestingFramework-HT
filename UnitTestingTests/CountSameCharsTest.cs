using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTesting;

namespace UnitTestingTests
{
    [TestClass]
    public class CountSameCharsTest
    {
        public static IEnumerable<object[]> SameCharsData
        {
            get
            {
                return new[]
                {
                    new object[] { "asd", 1 },
                    new object[] { "aaaaaasd", 6 },
                    new object[] { "aasedddfjlf", 3 },
                    new object[] { "asdjaaa", 3 },
                    new object[] { "aasjjekdhajshhsjee", 2 }
                };
            }
        }

        [TestMethod()]
        [DynamicData(nameof(SameCharsData))]
        public void CountSameChars_ShouldReturnCorrectNumberOfRepeatedChars(string str, int expected)
        {
            //Arrange
            var charsCounter = this.CharsCountersFactory();

            //Act
            int actual = charsCounter.CountSameChars(str);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        public void CountDifferentChars_ShouldThrowArgumentException(string str)
        {
            //Arrange
            var charsCounter = this.CharsCountersFactory();

            //Act
            Action action = () => charsCounter.CountDifferentChars(str);

            //Assert
            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow(null)]
        public void CountSameChars_ShouldThrowArgumentException(string str)
        {
            //Arrange
            var charsCounter = this.CharsCountersFactory();

            //Act
            Action action = () => charsCounter.CountSameChars(str);

            //Assert
            Assert.ThrowsException<ArgumentException>(action);
        }

        private CharsCounter CharsCountersFactory()
        {
            return new CharsCounter();
        }
    }
}
