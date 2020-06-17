using System;
using Applications;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.TestUtilities;

namespace UnitTests.Application
{
    [TestClass]
    public class ResolutionTests
    {

        #region Constructor Tests

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_IfWidthInchesNotPositive_ThrowsArgumentException()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new Resolution(0, 1, 1);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_IfHeightInchesNotPositive_ThrowsArgumentException()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new Resolution(1, 0, 1);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [ExpectedException(typeof(ArgumentException))]
        public void Constructor_IfDpiNotPositive_ThrowsArgumentException()
        {
            // ReSharper disable once ObjectCreationAsStatement
            new Resolution(1, 1, 0);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void Constructor_WhenSuccessful_MapsWidthCorrectly()
        {
            float expectedWidth = 10;

            var result = new Resolution(expectedWidth, 1, 1);   

            Assert.AreEqual(expectedWidth, result.Width);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void Constructor_WhenSuccessful_MapsHeightCorrectly()
        {
            float expectedHeight = 10;

            var result = new Resolution(1, expectedHeight, 1);

            Assert.AreEqual(expectedHeight, result.Height);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void Constructor_WhenSuccessful_MapsDPICorrectly()
        {
            int expectedDPI = 10;

            var result = new Resolution(1, 1, expectedDPI);

            Assert.AreEqual(expectedDPI, result.DPI);
        }

        #endregion Constructor Tests

        #region ToString Tests

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ToString_WhenCalled_ReturnsCorrectFormat()
        {
            Resolution resolution = new Resolution(4, 6, 300);

            var expectedString = "4in x 6in";

            Assert.AreEqual(expectedString, resolution.ToString());
        }

        #endregion ToString Tests

        #region ConvertToImageSize Tests

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ConvertToImageSize_WhenCalled_MapsCorrectly()
        {
            Resolution resolution = new Resolution(4, 6, 300);

            var result = resolution.ConvertToImageSize();

            Assert.AreEqual(resolution.Width, result.Width);
            Assert.AreEqual(resolution.Height, result.Height);
            Assert.AreEqual(resolution.DPI, result.DPI);
        }

        #endregion ConvertToImageSize Tests
    }
}
