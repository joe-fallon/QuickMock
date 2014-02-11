using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickMock;

namespace QuickMockTests
{
    [TestClass]
    public class OutParameterTests
    {
        [TestMethod]
        public void Test_Empty_MethodName_Throws_ArgumentException()
        {
            try
            {
                OutParameter outParam = new OutParameter("", "param1", 1, 1);
            }
            catch(ArgumentException ex)
            {
                Assert.IsTrue(true);
                return;
            }

            Assert.Fail();
        }

        [TestMethod]
        public void Test_Null_MethodName_Throws_ArgumentException()
        {
            try
            {
                OutParameter outParam = new OutParameter(null, "param1", 1, 1);
            }
            catch(ArgumentException ex)
            {
                Assert.IsTrue(true);
                return;
            }

            Assert.Fail();
        }

        [TestMethod]
        public void Test_Empty_ParamName_Throws_ArgumentException()
        {
            try
            {
                OutParameter outParam = new OutParameter("Method1", "", 1, 1);
            }
            catch(ArgumentException ex)
            {
                Assert.IsTrue(true);
                return;
            }

            Assert.Fail();
        }

        [TestMethod]
        public void Test_Null_ParamName_Throws_ArgumentException()
        {
            try
            {
                OutParameter outParam = new OutParameter("Method1", null, 1, 1);
            }
            catch(ArgumentException ex)
            {
                Assert.IsTrue(true);
                return;
            }

            Assert.Fail();
        }

        [TestMethod]
        public void Test_MethodName_Getter()
        {
            OutParameter outParam = new OutParameter("Method1", "param1", 1, 2);
            Assert.AreEqual("Method1", outParam.MethodName);
        }

        [TestMethod]
        public void Test_ParamName_Getter()
        {
            OutParameter outParam = new OutParameter("Method1", "param1", 3, 4);
            Assert.AreEqual("param1", outParam.ParamName);
        }

        [TestMethod]
        public void Test_OutVal_Getter()
        {
            OutParameter outParam = new OutParameter("Method1", "param1", 3, 4);
            Assert.AreEqual(3, outParam.OutVal);
        }

        [TestMethod]
        public void Test_CallCount_Getter()
        {
            OutParameter outParam = new OutParameter("Method1", "param1", 3, 4);
            Assert.AreEqual(4, outParam.CallCount);
        }
    }
}
