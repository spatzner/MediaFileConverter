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


        #endregion Int Constructor Tests

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

        

    }
}
