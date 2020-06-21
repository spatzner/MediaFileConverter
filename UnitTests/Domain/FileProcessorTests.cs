using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitTests.TestUtilities;

namespace UnitTests.Domain
{
    [TestClass]
    public class FileProcessorTests : Test<FileProcessor>
    {
        private Mock<ISVGConverter> mockSVGConverter;
        private Mock<IAIConverter> mockAIConverter;


        public override void TestInitialize()
        {
            mockSVGConverter = new Mock<ISVGConverter>();
            mockAIConverter= new Mock<IAIConverter>();
        }

        #region Constructor Tests

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WhenSVGConverterIsNull_ThrowsException()
        {
            sut = new FileProcessor(null, mockAIConverter.Object);
        }

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WhenAIConverterIsNull_ThrowsException()
        {
            sut = new FileProcessor(mockSVGConverter.Object, null);
        }

        #endregion Constructor Tests

        #region ConvertAIToPNG Tests


        #endregion ConvertAIToPNG Tests
    }
}
