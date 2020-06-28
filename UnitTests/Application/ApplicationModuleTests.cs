using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Applications;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Ninject;
using UI;
using UnitTests.TestUtilities;

namespace UnitTests.Application
{
    [TestClass]
    public class ApplicationModuleTests
    {
        private static IKernel _container;
        private static string _defaultSaveLocation;

        [ClassInitialize]
        public static void ClassInitialize(TestContext _)
        {
            _defaultSaveLocation = @"C:\File\Path";

           _container = new StandardKernel
            (
                new ApplicationModule(_defaultSaveLocation)
            );
        }

        [TestMethod]
        [TestCategory(TestCategories.Integration)]
        public void Load_WhenCalled_InstantiatesIFileConverter()
        {
            var result = _container.Get<IFileConverter>();

            Assert.IsInstanceOfType(result, typeof(IFileConverter));
        }
    }
}
