using System;
using System.Drawing;
using Domain;
using Domain.Converters;
using Infrastructure.Providers;
using Infrastructure.Wrappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Svg;
using UnitTests.TestUtilities;

namespace UnitTests.Domain
{
    [TestClass]
    public class SVGConverterTests : Test<SVGConverter>
    {

        #region Initialization

        private Mock<ISVGWrapper> mockSVGDocumentWrapper;
        private Mock<IBitmapWrapper> mockBitmapWrapper;
        private Mock<IFileSystemProvider> mockFileSystemProvider;

        private SvgDocument svgDocument;
        private string saveLocation;
        private string file;

        public override void TestInitialize()
        {
            mockSVGDocumentWrapper = new Mock<ISVGWrapper>();
            mockBitmapWrapper = new Mock<IBitmapWrapper>();
            mockFileSystemProvider = new Mock<IFileSystemProvider>();

            saveLocation = "//Some/location";
            file = $"{saveLocation}/file.svg";

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
            sut = new SVGConverter(null, mockBitmapWrapper.Object, mockFileSystemProvider.Object);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WhenBitmapWrapperIsNull_ThrowsException()
        {
            sut = new SVGConverter(mockSVGDocumentWrapper.Object, null, mockFileSystemProvider.Object);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WhenFileSystemProviderIsNull_ThrowsException()
        {
            sut = new SVGConverter(mockSVGDocumentWrapper.Object, mockBitmapWrapper.Object, null);
        }

        #endregion Constructor Tests

        #region ConvertToPNG Tests

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ConvertToPNG_WhenCalled_CreatesSaveLocation()
        {
            //Arrange
            mockFileSystemProvider.Setup(x => x.GetDirectoryName(file)).Returns(saveLocation);
            mockSVGDocumentWrapper.Setup(x => x.GetDocument(It.IsAny<string>(), It.IsAny<SvgAspectRatio>())).Returns(svgDocument);

            sut = CreateValidSVGConverter();

            //Act
            sut.ConvertToPNG(file, new Size(1, 1), saveLocation);

            //Assert
            mockFileSystemProvider.Verify(x => x.CreateDirectory(saveLocation));
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ConvertToPNG_WhenCalled_GetsDocumentCorrectly()
        {
            //Arrange
            mockFileSystemProvider.Setup(x => x.GetDirectoryName(file)).Returns(saveLocation);
            mockSVGDocumentWrapper.Setup(x => x.GetDocument(It.IsAny<string>(), It.IsAny<SvgAspectRatio>())).Returns(svgDocument);

            sut = CreateValidSVGConverter();

            //Act
            sut.ConvertToPNG(file, new Size(1, 1), saveLocation);

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
            mockSVGDocumentWrapper.Setup(x => x.GetDocument(It.IsAny<string>(), It.IsAny<SvgAspectRatio>())).Returns(svgDocument);
            

            sut = CreateValidSVGConverter();

            //Act
            sut.ConvertToPNG(file, new Size(2, 1), saveLocation);

            //Assert
            mockBitmapWrapper.Verify(x => x.CreatePNG(It.IsAny<string>(),
                It.Is<Size>(y => y.Height == size.Width && y.Width == size.Height), It.IsAny<SvgDocument>()));
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ConvertToPNG_Called_CreatesPNGCorrectly()
        {
            //Arrange
            Size size = new Size(1, 2);

            svgDocument.Width = new SvgUnit(SvgUnitType.Pixel, size.Width);
            svgDocument.Height = new SvgUnit(SvgUnitType.Pixel, size.Height);

            mockFileSystemProvider.Setup(x => x.GetDirectoryName(file)).Returns(saveLocation);
            mockSVGDocumentWrapper.Setup(x => x.GetDocument(It.IsAny<string>(), It.IsAny<SvgAspectRatio>())).Returns(svgDocument);


            sut = CreateValidSVGConverter();

            //Act
            sut.ConvertToPNG(file, size, saveLocation);

            //Assert
            mockBitmapWrapper.Verify(x => x.CreatePNG(saveLocation, size, svgDocument));
        }

        #endregion ConvertToPNG Tests

        #region Private Members

        public SVGConverter CreateValidSVGConverter()
        {
            return new SVGConverter(
                mockSVGDocumentWrapper.Object,
                mockBitmapWrapper.Object,
                mockFileSystemProvider.Object);
        }

        #endregion Private Members
    }
}
