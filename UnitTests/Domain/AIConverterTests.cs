using System;
using Domain;
using Domain.Converters;
using Illustrator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using UnitTests.TestUtilities;

namespace UnitTests.Domain
{
    [TestClass]
    public class AIConverterTests
    {
        private AIConverter sut;

        private Mock<IIllustratorProvider> mockIllustratorProvider;

        [TestInitialize]
        public void TestInitialize()
        {
            mockIllustratorProvider = new Mock<IIllustratorProvider>();
        }

        #region Constructor Tests

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WhenIllustratorProviderIsNull_ThrowsException()
        {
            sut = new AIConverter(null);
        }

        #endregion Constructor Tests

        #region ConvertToSVG Tests

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ConvertToSVG_WhenCalled_PassesParametersCorrectly()
        {
            //Arrange
            string file = "file";
            string saveDirectory = "save directory";

            sut = new AIConverter(mockIllustratorProvider.Object);
            
            //Act
            sut.ConvertToSVG(file, saveDirectory);

            //Assert
            mockIllustratorProvider.Verify(x => x.ExportToSVG(file, saveDirectory));
        }

        #endregion ConvertToSVG Tests
    }
}
