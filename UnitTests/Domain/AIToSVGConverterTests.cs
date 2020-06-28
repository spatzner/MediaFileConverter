using System;
using Domain;
using Illustrator;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Ninject.Activation.Strategies;
using UnitTests.TestUtilities;

namespace UnitTests.Domain
{
    [TestClass]
    public class AIToSVGConverterTests : Test<AIToSVGConverter>
    {
        #region Initialization


        private Mock<IIllustratorProvider> mockIllustratorProvider;

        public override void TestInitialize()
        {
            mockIllustratorProvider = new Mock<IIllustratorProvider>();
        }

        #endregion Initialization

        #region Constructor Tests

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Constructor_WhenIllustratorProviderIsNull_ThrowsException()
        {
            sut = new AIToSVGConverter(null);
        }

        #endregion Constructor Tests

        #region Convert Tests

        [TestMethod]
        [TestCategory(TestCategories.Unit)]
        public void ConvertToSVG_WhenCalled_PassesParametersCorrectly()
        {
            //Arrange
            string file = "file";
            string saveDirectory = "save directory";

            sut = new AIToSVGConverter(mockIllustratorProvider.Object);
            
            //Act
            sut.Convert(file,null, saveDirectory);

            //Assert
            mockIllustratorProvider.Verify(x => x.ExportToSVG(file, saveDirectory));
        }

        #endregion Convert Tests
    }
}
