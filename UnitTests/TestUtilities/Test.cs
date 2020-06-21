using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTests.TestUtilities
{
    [TestClass]
    public abstract class Test<T> where T : class
    {
        protected T sut;

        [TestInitialize]
        public void _()
        {
            sut = null;

            TestInitialize();
        }

        public abstract void TestInitialize();

    }
}
