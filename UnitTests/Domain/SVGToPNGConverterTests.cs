using System;
using System.Drawing;
using Domain;
using Infrastructure.Providers;
using Infrastructure.Wrappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Svg;
using UnitTests.TestUtilities;

namespace UnitTests.Domain
{
    [TestClass]
    public class SVGToPNGConverterTests : Test<SVGToPNGConverter>
    {

        #region Initialization

        private Mock<ISVGWrapper> mockSVGDocumentWrapper;
        private Mock<IBitmapWrapper> mockBitmapWrapper;
        private Mock<IFileSystemProvider> mockFileSystemProvider;

        private SvgDocument svgDocument;
        private string saveLocation;
        private string file;
        private string fileNameWithoutExtension;

        public override void TestInitialize()
        {
            mockSVGDocumentWrapper = new Mock<ISVGWrapper>();
            mockBitmapWrapper = new Mock<IBitmapWrapper>();
            mockFileSystemProvider = new Mock<IFileSystemProvider>();

            saveLocation = @"\\Some\location";
            file = $@"{saveLocation}\file.svg";
            fileNameWithoutExtension = "file";


            svgDocument = new SvgDocument
            {
                Width = new SvgUnit(SvgUnitType.Pixel, 1),
                Height = new SvgUnit(SvgUnitType.Pixel, 1)
            };
        }

        #endregion Initialization

        #region Constructor Tests

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WhenSVGWrapperIsNull_ThrowsException()
        {
            sut = new SVGToPNGConverter(null, mockBitmapWrapper.Object, mockFileSystemProvider.Object);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WhenBitmapWrapperIsNull_ThrowsException()
        {
            sut = new SVGToPNGConverter(mockSVGDocumentWrapper.Object, null, mockFileSystemProvider.Object);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WhenFileSystemProviderIsNull_ThrowsException()
        {
            sut = new SVGToPNGConverter(mockSVGDocumentWrapper.Object, mockBitmapWrapper.Object, null);
        }

        #endregion Constructor Tests

        #region Convert Tests

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ConvertToPNG_WhenCalled_CreatesSaveLocation()
        {
            //Arrange
            mockFileSystemProvider.Setup(x => x.GetDirectoryName(file)).Returns(saveLocation);
            mockFileSystemProvider.Setup(x => x.GetFileNameWithoutExtension(file)).Returns(fileNameWithoutExtension);
            mockSVGDocumentWrapper.Setup(x => x.GetDocument(It.IsAny<string>(), It.IsAny<SvgAspectRatio>())).Returns(svgDocument);

            sut = CreateValidSVGConverter();

            var expected = ReflectionUtilities.ExecutePrivateMethod<SVGToPNGConverter, string>(sut, "GetOutputLocation",
                new object[] { file, saveLocation });

            //Act
            sut.Convert(file, new ImageSize(1, 1), saveLocation);

            //Assert
            mockFileSystemProvider.Verify(x => x.CreateDirectory(expected));
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ConvertToPNG_WhenCalled_GetsDocumentCorrectly()
        {
            //Arrange
            mockFileSystemProvider.Setup(x => x.GetDirectoryName(file)).Returns(saveLocation);
            mockFileSystemProvider.Setup(x => x.GetFileNameWithoutExtension(file)).Returns(fileNameWithoutExtension);
            mockSVGDocumentWrapper.Setup(x => x.GetDocument(It.IsAny<string>(), It.IsAny<SvgAspectRatio>())).Returns(svgDocument);

            sut = CreateValidSVGConverter();

            //Act
            sut.Convert(file, new ImageSize(1, 1), saveLocation);

            //Assert
            mockSVGDocumentWrapper.Verify(x => x.GetDocument(file,
                It.Is<SvgAspectRatio>(y => y.Align == SvgPreserveAspectRatio.none && y.Slice == false)));
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ConvertToPNG_WhenSvgAndSizeDoNotMatch_FlipsSizeDimensions()
        {
            //Arrange
            Size size = new Size(1, 2);

            svgDocument.Width = new SvgUnit(SvgUnitType.Pixel, size.Height);
            svgDocument.Height = new SvgUnit(SvgUnitType.Pixel, size.Width);

            mockFileSystemProvider.Setup(x => x.GetDirectoryName(file)).Returns(saveLocation);
            mockFileSystemProvider.Setup(x => x.GetFileNameWithoutExtension(file)).Returns(fileNameWithoutExtension);
            mockSVGDocumentWrapper.Setup(x => x.GetDocument(It.IsAny<string>(), It.IsAny<SvgAspectRatio>())).Returns(svgDocument);
            

            sut = CreateValidSVGConverter();

            //Act
            sut.Convert(file, new ImageSize(2, 1), saveLocation);

            //Assert
            mockBitmapWrapper.Verify(x => x.CreatePNG(It.IsAny<string>(), It.IsAny<SvgDocument>(), It.Is<Size>(y => y.Height == size.Width && y.Width == size.Height)));
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ConvertToPNG_Called_CreatesPNGCorrectly()
        {
            //Arrange
            ImageSize imageSize = new ImageSize(1, 2);

            svgDocument.Width = new SvgUnit(SvgUnitType.Pixel, imageSize.Width);
            svgDocument.Height = new SvgUnit(SvgUnitType.Pixel, imageSize.Height);

            mockFileSystemProvider.Setup(x => x.GetDirectoryName(file)).Returns(saveLocation);
            mockFileSystemProvider.Setup(x => x.GetFileNameWithoutExtension(file)).Returns(fileNameWithoutExtension);
            mockSVGDocumentWrapper.Setup(x => x.GetDocument(It.IsAny<string>(), It.IsAny<SvgAspectRatio>())).Returns(svgDocument);

            sut = CreateValidSVGConverter();

            var outputLocation = ReflectionUtilities.ExecutePrivateMethod<SVGToPNGConverter, string>(sut, "GetOutputLocation",
                new object[] { file, saveLocation });
            var expectedFileName = ReflectionUtilities.ExecutePrivateMethod<SVGToPNGConverter, string>(sut, "GetFileSaveLocation",
                new object[] {file, outputLocation, imageSize});

            //Act
            sut.Convert(file, imageSize, saveLocation);

            //Assert
            mockBitmapWrapper.Verify(x => x.CreatePNG(expectedFileName, svgDocument, imageSize.ToSize()));
        }

        #endregion Convert Tests

        #region Private Members

        public SVGToPNGConverter CreateValidSVGConverter()
        {
            return new SVGToPNGConverter(
                mockSVGDocumentWrapper.Object,
                mockBitmapWrapper.Object,
                mockFileSystemProvider.Object);
        }

        #endregion Private Members
    }
}
