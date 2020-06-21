using System;
using Applications;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.TestUtilities;

namespace UnitTests.Application
{
    [TestClass]
    public class ResolutionTests : Test<Resolution>
    {
        #region TestInitialize

        public override void TestInitialize()
        {

        }

        #endregion TestInitialize

        #region Constructor Tests

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_IfWidthInchesNotPositive_ThrowsArgumentException()
        {
            sut = new Resolution(0, 1, 1);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_IfHeightInchesNotPositive_ThrowsArgumentException()
        {
            sut = new Resolution(1, 0, 1);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_IfDpiNotPositive_ThrowsArgumentException()
        {
            sut = new Resolution(1, 1, 0);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void Constructor_WhenSuccessful_MapsWidthCorrectly()
        {
            //Arrange
            float expectedWidth = 10;

            //Act
            var result = new Resolution(expectedWidth, 1, 1);   

            //Assert
            Assert.AreEqual(expectedWidth, result.Width);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void Constructor_WhenSuccessful_MapsHeightCorrectly()
        {
            //Arrange
            float expectedHeight = 10;

            //Act
            var result = new Resolution(1, expectedHeight, 1);

            //Assert
            Assert.AreEqual(expectedHeight, result.Height);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void Constructor_WhenSuccessful_MapsDPICorrectly()
        {
            //Arrange
            int expectedDPI = 10;

            //Act
            var result = new Resolution(1, 1, expectedDPI);

            //Assert
            Assert.AreEqual(expectedDPI, result.DPI);
        }

        #endregion Constructor Tests

        #region ToString Tests

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ToString_WhenCalled_ReturnsCorrectFormat()
        {
            //Arrange
            Resolution resolution = new Resolution(4, 6, 300);

            //Act
            var expectedString = "4in x 6in";

            //Assert
            Assert.AreEqual(expectedString, resolution.ToString());
        }

        #endregion ToString Tests

        #region ConvertToImageSize Tests

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ConvertToImageSize_WhenCalled_MapsWidthCorrectly()
        {
            //Arrange
            Resolution resolution = new Resolution(4, 6, 300);

            //Act
            var result = resolution.ConvertToImageSize();

            //Assert
            Assert.AreEqual(resolution.Width, result.Width);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ConvertToImageSize_WhenCalled_MapsHeightCorrectly()
        {
            //Arrange
            Resolution resolution = new Resolution(4, 6, 300);

            //Act
            var result = resolution.ConvertToImageSize();

            //Assert
            Assert.AreEqual(resolution.Height, result.Height);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ConvertToImageSize_WhenCalled_MapsDPICorrectly()
        {
            //Arrange
            Resolution resolution = new Resolution(4, 6, 300);

            //Act
            var result = resolution.ConvertToImageSize();

            //Assert
            Assert.AreEqual(resolution.DPI, result.DPI);
        }

        #endregion ConvertToImageSize Tests
    }
}
