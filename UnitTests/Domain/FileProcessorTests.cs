using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitTests.TestUtilities;

namespace UnitTests.Domain
{
    [TestClass]
    public class FileProcessorTests : Test<FileProcessor>
    {
        private Mock<IImageConverter> mockSVGToPNGConverter;
        private Mock<IImageConverter> mockAIToSVGConverter;

        private List<string> files;
        private string file1Name;
        
        private List<ImageSize> imageSizes;
        private string saveLocation;

        public override void TestInitialize()
        {
            mockSVGToPNGConverter = new Mock<IImageConverter>();
            mockAIToSVGConverter= new Mock<IImageConverter>();

            file1Name = "file1";
            files = new List<string>{file1Name};
            imageSizes = new List<ImageSize>{new ImageSize(1,1)};
            saveLocation = "saveLocation";
        }

        #region Constructor Tests

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WhenAIToSVGConverterIsNull_ThrowsException()
        {
            sut = new FileProcessor(null, mockAIToSVGConverter.Object);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WhenSVGToPNGConverterIsNull_ThrowsException()
        {
            sut = new FileProcessor(mockSVGToPNGConverter.Object, null);
        }
        #endregion Constructor Tests

        #region ConvertAIToPNG Tests

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ConvertAIToPNG_WhenCalled_ConvertsToSVGThenPNG()
        {
            //Arrange
            var expectedValue = "svgFile";

            mockAIToSVGConverter.Setup(x => x.Convert(It.IsAny<string>(), It.IsAny<ImageSize>(), It.IsAny<string>())).Returns(expectedValue);

            sut = CreateValidFileProcessor();

            //Act
            // ReSharper disable once UnusedVariable
            var result = sut.ConvertAIToPNG(files, imageSizes, saveLocation).ToList();

            //Assert
            mockAIToSVGConverter.Verify(x => x.Convert(files.First(), It.IsAny<ImageSize>(), It.IsAny<string>()));
            mockSVGToPNGConverter.Verify(x => x.Convert(expectedValue, It.IsAny<ImageSize>(), It.IsAny<string>()));
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ConvertAIToPNG_WhenCalled_IteratesAllFilesAndSizes()
        {
            //Arrange
            string svgFormat = "Svg{0}";
            files.Add("file2");
            imageSizes.Add(new ImageSize(2, 2));

            mockAIToSVGConverter.Setup(x => x.Convert(It.IsAny<string>(), It.IsAny<ImageSize>(), It.IsAny<string>()))
                .Returns((string file, ImageSize b, string c) => string.Format(svgFormat, file));

            sut = CreateValidFileProcessor();

            //Act
            var result = sut.ConvertAIToPNG(files, imageSizes, saveLocation).ToList();

            //Assert

            foreach (var file in files)
            {
                mockAIToSVGConverter.Verify(x => x.Convert(file, It.IsAny<ImageSize>(), It.IsAny<string>()), Times.Once);
                foreach (var imageSize in imageSizes)
                    mockSVGToPNGConverter.Verify(
                        x => x.Convert(string.Format(svgFormat, file), imageSize, It.IsAny<string>()), Times.Once);
            }
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ConvertAIToPNG_WhenCalled_ReturnsConvertedFileNames()
        {
            //Arrange
            string svgFormat = "Svg{0}";
            string pngFormat = "Png{0}";
            files.Add("file2");
            imageSizes.Add(new ImageSize(2, 2));

            mockAIToSVGConverter.Setup(x => x.Convert(It.IsAny<string>(), It.IsAny<ImageSize>(), It.IsAny<string>()))
                .Returns((string file, ImageSize b, string c) => string.Format(svgFormat, file));
            mockSVGToPNGConverter.Setup(x => x.Convert(It.IsAny<string>(), It.IsAny<ImageSize>(), It.IsAny<string>()))
                .Returns((string file, ImageSize b, string c) => file.Replace("Svg","Png"));

            sut = CreateValidFileProcessor();

            //Act
            var result = sut.ConvertAIToPNG(files, imageSizes, saveLocation).ToList();

            //Assert
            Assert.AreEqual(files.Count * imageSizes.Count, result.Count);
            foreach (var file in files)
                Assert.IsTrue(result.Contains(string.Format(pngFormat, file)));

        }

        #endregion ConvertAIToPNG Tests


        #region ConvertSVGToPNG Tests

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ConvertSVGToPNG_WhenCalled_ConvertsToPNG()
        {
            //Arrange
            sut = CreateValidFileProcessor();

            //Act
            var result = sut.ConvertSVGToPNG(files, imageSizes, saveLocation).ToList();

            //Assert
            mockSVGToPNGConverter.Verify(x => x.Convert(files.First(), It.IsAny<ImageSize>(), It.IsAny<string>()));
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ConvertSVGToPNG_WhenCalled_IteratesAllFilesAndSizes()
        {
            //Arrange
            files.Add("file2");
            imageSizes.Add(new ImageSize(2, 2));

            sut = CreateValidFileProcessor();

            //Act
            var result = sut.ConvertSVGToPNG(files, imageSizes, saveLocation).ToList();

            //Assert
            foreach (var file in files)
            foreach (var imageSize in imageSizes)
                mockSVGToPNGConverter.Verify(x => x.Convert(file, imageSize, It.IsAny<string>()), Times.Once);


        }

        #endregion ConvertSVGToPNG Tests

        #region Shared Methods

        public FileProcessor CreateValidFileProcessor()
        {
            return new FileProcessor(mockSVGToPNGConverter.Object, mockAIToSVGConverter.Object);
        }

        #endregion Shared Methods

    }
}
