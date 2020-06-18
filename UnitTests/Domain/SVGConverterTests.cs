using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Domain.Converters;
using Infrastructure.Providers;
using Infrastructure.Wrappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitTests.TestUtilities;

namespace UnitTests.Domain
{
    [TestClass]
    public class SVGConverterTests
    {

        #region Initialization

        private SVGConverter sut;

        private Mock<ISVGWrapper> mockSVGDocumentWrapper;
        private Mock<IBitmapWrapper> mockBitmapWrapper;
        private Mock<IFileSystemProvider> mockFileSystemProvider;

        [TestInitialize]
        public void TestInitialize()
        {
            mockSVGDocumentWrapper = new Mock<ISVGWrapper>();
            mockBitmapWrapper = new Mock<IBitmapWrapper>();
            mockFileSystemProvider = new Mock<IFileSystemProvider>();
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
            sut = CreateValidSVGConverter();

            throw new NotImplementedException();

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
