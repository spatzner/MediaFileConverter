using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UnitTests.TestUtilities;
// ReSharper disable ConvertToConstant.Local

namespace UnitTests.Domain
{
    [TestClass]
    public class ImageSizeTests
    {
        private ImageSize sut;

        #region Float Construtor Tests

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorFloat_WhenWidthIsNotPositive_ThrowsException()
        {
            sut = new ImageSize(0f, 1, 1);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorFloat_WhenHeightIsNotPositive_ThrowsException()
        {
            sut = new ImageSize(1f, 0, 1);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorFloat_WhenDpiIsNotPositive_ThrowsException()
        {
            sut = new ImageSize(1f, 1, 0);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ConstructorFloat_AllArgumentsValid_AssignsWidthCorrectly()
        {
            float expected = 3;

            sut = new ImageSize(expected, 2, 2);

            Assert.AreEqual(expected, sut.Width);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ConstructorFloat_AllArgumentsValid_AssignsHeightCorrectly()
        {
            float expected = 3;

            sut = new ImageSize(2, expected, 2);

            Assert.AreEqual(expected, sut.Height);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ConstructorFloat_AllArgumentsValid_AssignsDpiCorrectly()
        {
            int expected = 3;

            sut = new ImageSize(2, 2, expected);

            Assert.AreEqual(expected, sut.DPI);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ConstructorFloat_AllArgumentsValid_CalculatesPixelWidthCorrectly()
        {
            float width = 2.6f;
            int dpi = 300;
            int expected = Convert.ToInt32(Math.Floor(width * dpi));

            sut = new ImageSize(width, 2, dpi);

            Assert.AreEqual(expected, sut.PixelWidth);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ConstructorFloat_AllArgumentsValid_CalculatesPixelHeightCorrectly()
        {
            float height = 2.6f;
            int dpi = 300;
            int expected = Convert.ToInt32(Math.Floor(height * dpi));

            sut = new ImageSize(2, height, dpi);

            Assert.AreEqual(expected, sut.PixelHeight);
        }


        #endregion Float Constructor Tests

        #region Int Constructor Tests

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorPixel_WhenPixelWidthIsNotPositive_ThrowsException()
        {
            sut = new ImageSize(0, 1, 1);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorPixel_WhenPixelHeightIsNotPositive_ThrowsException()
        {
            sut = new ImageSize((int) 1, 0, 1);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorPixel_WhenDpiIsNotPositive_ThrowsException()
        {
            sut = new ImageSize((int)1, 1, 0);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ConstructorPixel_WhenArgumentsAreValid_AssignsPixelWidthCorrectly()
        {
            //Arrange
            int expected = 3;

            //Act
            sut = new ImageSize(expected, 1, 1);

            //Assert
            Assert.AreEqual(expected, sut.PixelWidth);

        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ConstructorPixel_WhenArgumentsAreValid_AssignsPixelHeightCorrectly()
        {
            //Arrange
            int expected = 3;

            //Act
            sut = new ImageSize(1, expected, 1);

            //Assert
            Assert.AreEqual(expected, sut.PixelHeight);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ConstructorPixel_WhenArgumentsAreValid_AssignsDpiCorrectly()
        {
            //Arrange
            int expected = 3;

            //Act
            sut = new ImageSize(1, 1, expected);

            //Assert
            Assert.AreEqual(expected, sut.DPI);
        }
        
        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ConstructorPixel_WhenArgumentsAreValid_CorrectlyConvertsWidth()
        {
            //Arrange
            int width = 3;
            int dpi = 6;

            float expected = (float) width / dpi;

            //Act
            sut = new ImageSize(width, 1, dpi);

            //Assert
            Assert.AreEqual(expected, sut.Width);
        }


        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ConstructorPixel_WhenArgumentsAreValid_CorrectlyConvertsHeight()
        {
            //Arrange
            int height = 3;
            int dpi = 6;

            float expected = (float)height / dpi;

            //Act
            sut = new ImageSize(1, height, dpi);

            //Assert
            Assert.AreEqual(expected, sut.Height);
        }

        #endregion Int Constructor Tests

        #region Constructor Two Arg Tests

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorTwoArg_WhenWidthIsNotPositive_ThrowsException()
        {
            sut = new ImageSize(0, 1);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [ExpectedException(typeof(ArgumentException))]
        public void ConstructorTwoArg_WhenHeightIsNotPositive_ThrowsException()
        {
            sut = new ImageSize(1, 0);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ConstructorTwoArg_WhenArgumentsAreValid_AssignsPixelWidthCorrectly()
        {
            //Arrange
            int expected = 3;

            //Act
            sut = new ImageSize(expected, 1);

            //Assert
            Assert.AreEqual(expected, sut.PixelWidth);

        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ConstructorTwoArg_WhenArgumentsAreValid_AssignsPixelHeightCorrectly()
        {
            //Arrange
            int expected = 3;

            //Act
            sut = new ImageSize(1, expected);

            //Assert
            Assert.AreEqual(expected, sut.PixelHeight);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ConstructorTwoArg_WhenArgumentsAreValid_AssignsDpiCorrectly()
        {
            //Arrange
            int expected = 300;

            //Act
            sut = new ImageSize(1, 1);

            //Assert
            Assert.AreEqual(expected, sut.DPI);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ConstructorTwoArg_WhenArgumentsAreValid_CorrectlyConvertsWidth()
        {
            //Arrange
            int width = 3;
            int dpi = 300;

            float expected = (float)width / dpi;

            //Act
            sut = new ImageSize(width, 1);
            //Assert
            Assert.AreEqual(expected, sut.Width);
        }


        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ConstructorTwoArg_WhenArgumentsAreValid_CorrectlyConvertsHeight()
        {
            //Arrange
            int height = 3;
            int dpi = 300;

            float expected = (float)height / dpi;

            //Act
            sut = new ImageSize(1, height);

            //Assert
            Assert.AreEqual(expected, sut.Height);
        }

        #endregion Constructor Two Arg Tests

        #region ToSize Tests

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ToSize_WhenCalled_MapsWidthCorrectly()
        {
            //Arrange
            var expected = 2;
            sut = new ImageSize(expected,3);

            //Act
            var result = sut.ToSize();

            //Assert
            Assert.AreEqual(expected, result.Width);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ToSize_WhenCalled_MapsHeightCorrectly()
        {
            //Arrange
            var expected = 2;
            sut = new ImageSize(3, expected);

            //Act
            var result = sut.ToSize();

            //Assert
            Assert.AreEqual(expected, result.Height);
        }

        #endregion ToSize Tests
    }
}
