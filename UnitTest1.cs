using System.Collections.Generic;
using Xunit;

namespace UtilitiesDemo.Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Floor_ReturnsFloorOfNumber()
        {
            // Arrange
            double num = 3.14159;

            // Act
            var result = Utilities.Floor(num);

            // Assert
            Assert.Equal(3, result);
        }

        [Fact]
        public void JoinNames_JoinsFirstAndLastNameWithComma()
        {
            // Arrange
            string firstName = "John";
            string lastName = "Doe";

            // Act
            var result = Utilities.JoinNames(firstName, lastName);

            // Assert
            Assert.Equal("Doe, John", result);
        }

        [Fact]
        public void HashPassword_ReturnsHashOfPassword()
        {
            // Arrange
            string password = "password123";

            // Act
            var result = Utilities.HashPassword(password);

            // Assert
            Assert.Equal("6a94c6ed1de44d084c6b11cf8d046cfc0a6aef9e9c6540c8e4ee3f1e4afcd08d", result);
        }

        [Theory]
        [InlineData(1, false)]
        [InlineData(2, true)]
        [InlineData(3, true)]
        [InlineData(4, false)]
        [InlineData(5, true)]
        [InlineData(6, false)]
        [InlineData(7, true)]
        [InlineData(8, false)]
        [InlineData(9, false)]
        [InlineData(10, false)]
        public void IsPrime_ReturnsCorrectValue(int num, bool expected)
        {
            // Arrange, Act and Assert
            Assert.Equal(expected, Utilities.IsPrime(num));
        }

        [Theory]
        [InlineData(1, new int[] { })]
        [InlineData(2, new int[] { })]
        [InlineData(3, new int[] { })]
        [InlineData(4, new int[] { 2 })]
        [InlineData(5, new int[] { })]
        [InlineData(6, new int[] { 2, 3 })]
        [InlineData(7, new int[] { })]
        [InlineData(8, new int[] { 2, 4 })]
        [InlineData(9, new int[] { 3 })]
        [InlineData(10, new int[] { 2, 5 })]
        public void NonPrimeDivisors_ReturnsListOfNonPrimeDivisors(int num, int[] expected)
        {
            // Arrange
            var expectedList = new List<int>(expected);

            // Act
            var result = Utilities.NonPrimeDivisors(num);

            // Assert
            Assert.Equal(expectedList, result);
        }

        [Theory]
        [InlineData(2, 5, 2)]
        [InlineData(10, 3, 3)]
        [InlineData(6, 9, 1)]
        public void DivideAndFloor_ReturnsFloorOfDivision(int num1, int num2, int expected)
        {
            // Arrange, Act and Assert
            Assert.Equal(expected, Utilities.DivideAndFloor(num1, num2));
        }

        [Theory]
        [InlineData(1, new int[] { })]
        [InlineData(2, new int[] { })]
        [InlineData(3, new int[] { })]
        [InlineData(4, new int[] { 2 })]
        [InlineData(5, new int[] { })]
        [InlineData(6, new int[] { 2, 3 })]
        [InlineData(7, new int[] { })]
        [InlineData(8, new int[] { 2, 4 })]
        [InlineData(9, new int[] { 3 })]
        [InlineData(10, new int[] { 2, 5 })]
        public void NonPrimeDivisorsDictionary_ReturnsDictionaryOfNonPrimeDivisors(int num, int[] expected)
        {
            // Arrange
            var expectedDictionary = new Dictionary<int, int>();
            foreach (int key in expected)
            {
                expectedDictionary.Add(key, num / key);
            }

            // Act
            var result = Utilities.NonPrimeDivisorsDictionary(num);

            // Assert
            Assert.Equal(expectedDictionary, result);
        }
    }
}