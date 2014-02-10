using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickMock;

namespace QuickMockTests
{
    [TestClass]
    public class MethodReturnValueTests
    {
        [TestMethod]
        public void Test_MethodName_Getter()
        {
            MethodReturnValue mrv = new MethodReturnValue("TestMethod", 3);

            Assert.AreEqual("TestMethod", mrv.MethodName);
        }

        [TestMethod]
        public void Test_ReturnValue_Getter()
        {
            MethodReturnValue mrv = new MethodReturnValue("TestMethod", 3);

            Assert.AreEqual(3, mrv.ReturnValue);
        }

        [TestMethod]
        public void Test_CallCount_Getter()
        {
            MethodReturnValue mrv = new MethodReturnValue("TestMethod", 3, 5);

            Assert.AreEqual(5, mrv.CallCount);
        }
    }
}
