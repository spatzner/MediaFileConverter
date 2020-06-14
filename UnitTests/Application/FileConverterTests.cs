using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Applications;
using Domain;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace UnitTests.Application
{
    [TestClass]
    public class FileConverterTests
    {
        #region Initialization

        private Mock<IFileProcessor> mockFileProcessor;

        private FileConverter sut;

        [TestInitialize]
        public void TestInitialize()
        {

            sut = new FileConverter(mockFileProcessor.Object);
        }

        #endregion Initialization

        #region Constructor Tests




        #endregion Constructor Tests
    }
}
