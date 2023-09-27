using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using UnitTesting;

namespace UnitTesting.Tests
{
    [TestClass()]
    public class CharsCounterTests
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

        [TestMethod()]
        [DynamicData(nameof(DifferentCharsData))]
        public void CountDifferentChars_ShouldReturnCorrectNumberOfDifferentChars(string str, int expected)
        {
            //Arrange
            var charsCounter = this.CharsCountersFactory();

            //Act
            int actual = charsCounter.CountDifferentChars(str);

            //Assert
            Assert.AreEqual(expected, actual);
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

        [TestMethod()]
        [DynamicData(nameof(SameNumbersData))]
        public void CountSameDigits_ShouldReturnCorrectNumberOfSameDigits(string str, int expected)
        {
            //Arrange
            var charsCounter = this.CharsCountersFactory();

            //Act
            int actual = charsCounter.CountSameDigits(str);

            //Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        [DataRow(null)]
        public void CountDifferentChars_ShouldThrowArgumentNullException(string str)
        {
            //Arrange
            var charsCounter = this.CharsCountersFactory();

            //Act
            Action action = () => charsCounter.CountDifferentChars(str);

            //Assert
            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod()]
        [DataRow(null)]
        public void CountSameChars_ShouldThrowArgumentNullException(string str)
        {
            //Arrange
            var charsCounter = this.CharsCountersFactory();

            //Act
            Action action = () => charsCounter.CountSameChars(str);

            //Assert
            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod()]
        [DataRow(null)]
        public void CountSameDigits_ShouldThrowArgumentNullException(string str)
        {
            //Arrange
            var charsCounter = this.CharsCountersFactory();

            //Act
            Action action = () => charsCounter.CountSameDigits(str);

            //Assert
            Assert.ThrowsException<ArgumentNullException>(action);
        }

        [TestMethod]
        [DataRow("")]
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
        public void CountSameChars_ShouldThrowArgumentException(string str)
        {
            //Arrange
            var charsCounter = this.CharsCountersFactory();

            //Act
            Action action = () => charsCounter.CountSameChars(str);

            //Assert
            Assert.ThrowsException<ArgumentException>(action);
        }

        [TestMethod]
        [DataRow("")]
        [DataRow("aasjjekdhajshhsjee")]
        public void CountSameDigits_ShouldThrowArgumentException(string str)
        {
            //Arrange
            var charsCounter = this.CharsCountersFactory();

            //Act
            Action action = () => charsCounter.CountSameDigits(str);

            //Assert
            Assert.ThrowsException<ArgumentException>(action);
        }

        private CharsCounter CharsCountersFactory()
        {
            return new CharsCounter();
        }
    }
}