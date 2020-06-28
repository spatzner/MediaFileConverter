using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;
using Infrastructure;
using Infrastructure.Wrappers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using Ninject.Modules;
using UnitTests.TestUtilities;

namespace UnitTests.Domain
{
    [TestClass]
    public class DomainModuleTests
    {
        private static IKernel _kernel;

        [ClassInitialize]
        public static void ClassInitialize(TestContext _)
        {
            _kernel = new StandardKernel
            (
                new DomainModule()
            );

        }

        [TestMethod]
        [TestCategory(TestCategories.Integration)]
        public void Kernel_WhenCalled_ReturnsInstanceOfAIConverter()
        {
            var result = _kernel.Get<IImageConverter>(ConverterType.AIToSVG);

            Assert.IsInstanceOfType(result, typeof(AIToSVGConverter));
        }

        [TestMethod]
        [TestCategory(TestCategories.Integration)]
        public void Kernel_WhenCalled_ReturnsInstanceOfSVGToPNGConverter()
        {
            var result = _kernel.Get<IImageConverter>(ConverterType.SVGToPNG);

            Assert.IsInstanceOfType(result, typeof(SVGToPNGConverter));
        }

        [TestMethod]
        [TestCategory(TestCategories.Integration)]
        public void Kernel_WhenCalled_ReturnsInstanceOfFileProcessor()
        {
            var result = _kernel.Get<IFileProcessor>();

            Assert.IsInstanceOfType(result, typeof(FileProcessor));
        }
    }

}
