using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuickMock;
using System.Collections;

namespace QuickMockTests
{
    [TestClass]
    public class MethodCallTests
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Empty_Method_Name_Throws_ArgumentException_In_Ctor()
        {
            MethodCall call = new MethodCall("", null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_Null_Method_Name_Throws_ArgumentException_In_Ctor()
        {
            MethodCall call = new MethodCall(null, null);
        }

        [TestMethod]
        public void Test_MethodName_Getter()
        {
            MethodCall call = new MethodCall("TestMethod", null);

            Assert.AreEqual("TestMethod", call.MethodName);
        }

        [TestMethod]
        public void Test_Args_Getter()
        {
            ArrayList args = new ArrayList(); 
            args.Add(4);
            args.Add(5);
            MethodCall call = new MethodCall("TestMethod", args);

            Assert.AreEqual(args, call.Args);
        }
    }
}
