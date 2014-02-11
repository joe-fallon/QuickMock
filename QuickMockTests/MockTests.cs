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
    public class MockTests
    {
        [TestMethod]
        public void Test_SetMethodReturnValue_Properly_Overwrites_Previous_Sets()
        {
            Mock mock = new Mock();
            mock.SetMethodReturnValue("TestMethod", "a", 1);
            mock.SetMethodReturnValue("TestMethod", "b", 2);
            mock.SetMethodReturnValue("TestMethod", "c", 1);

            ArrayList args = new ArrayList();
            args.Add(1);
            args.Add(2);

            string retval = (string)mock.MethodCalled("TestMethod", args);

            Assert.AreEqual("c", retval, "with call count");

            mock = new Mock();
            mock.SetMethodReturnValue("TestMethod", "a");
            mock.SetMethodReturnValue("TestMethod", "b");

            args = new ArrayList();
            args.Add(1);
            args.Add(2);

            retval = (string)mock.MethodCalled("TestMethod", args);

            Assert.AreEqual("b", retval, "without call count");
        }

        [TestMethod]
        public void Test_MethodReturnValue_Getter_And_Setter()
        {
            Mock mock = new Mock();
            mock.SetMethodReturnValue("TestMethod", "a", 1);
            mock.SetMethodReturnValue("TestMethod", "b", 2);
            mock.SetMethodReturnValue("TestMethod", "c", 3);
            mock.SetMethodReturnValue("TestMethod", "d", 4);

            ArrayList args = new ArrayList();
            args.Add(1);
            args.Add(2);

            Assert.AreEqual("a", mock.MethodCalled("TestMethod", args));
            Assert.AreEqual("b", mock.MethodCalled("TestMethod", args));
            Assert.AreEqual("c", mock.MethodCalled("TestMethod", args));
            Assert.AreEqual("d", mock.MethodCalled("TestMethod", args));

            mock.SetMethodReturnValue("OtherMethod", "z");
            Assert.AreEqual("z", mock.MethodCalled("OtherMethod", args));
            Assert.AreEqual("z", mock.MethodCalled("OtherMethod", args));
            Assert.AreEqual("z", mock.MethodCalled("OtherMethod", args));
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_MethodCalled_Throws_ArgumentException_On_Empty_MethodName()
        {
            Mock mock = new Mock();
            mock.MethodCalled("", null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_MethodCalled_Throws_ArgumentException_On_Null_MethodName()
        {
            Mock mock = new Mock();
            mock.MethodCalled(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_SetMethodReturnValue_Throws_ArgumentException_On_Empty_Name()
        {
            Mock mock = new Mock();
            mock.SetMethodReturnValue("", 1, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_SetMethodReturnValue_Throws_ArgumentException_On_Null_Name()
        {
            Mock mock = new Mock();
            mock.SetMethodReturnValue(null, 1, 1);
        }

        [TestMethod]
        public void Test_GetMethodArgs_Returns_Correct_Args()
        {
            ArrayList args = new ArrayList();
            args.Add(1);
            args.Add(2);

            Mock mock = new Mock();
            mock.MethodCalled("TestMethod", args);
            ArrayList argsOut = mock.GetMethodArgs("TestMethod", 1);

            Assert.AreEqual(1, argsOut[0]);
            Assert.AreEqual(2, argsOut[1]);

            args = new ArrayList();
            args.Add(3);
            args.Add(4);

            mock.MethodCalled("TestMethod", args);
            argsOut = mock.GetMethodArgs("TestMethod", 2);

            Assert.AreEqual(3, argsOut[0]);
            Assert.AreEqual(4, argsOut[1]);

            args = new ArrayList();
            args.Add(5);
            args.Add(6);

            mock.MethodCalled("TestMethod", args);
            argsOut = mock.GetMethodArgs("TestMethod", 3);

            Assert.AreEqual(5, argsOut[0]);
            Assert.AreEqual(6, argsOut[1]);
        }

        [TestMethod]
        [ExpectedException(typeof(Exception))]
        public void Test_GetMethodArgs_Throws_Exception_If_CallCount_Too_High()
        {
            Mock mock = new Mock();
            mock.MethodCalled("TestMethod", null);
            mock.GetMethodArgs("TestMethod", 2);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_GetMethodArgs_Throws_ArgumentException_On_Empty_Name()
        {
            Mock mock = new Mock();
            mock.GetMethodArgs("", 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_GetMethodArgs_Throws_ArgumentException_On_Null_Name()
        {
            Mock mock = new Mock();
            mock.GetMethodArgs(null, 1);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_GetMethodArgs_Throws_ArgumentException_On_CallCount_Less_Than_One()
        {
            Mock mock = new Mock();
            mock.GetMethodArgs("TestName", 0);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_GetMethodCallCount_Throws_ArgumentException_On_Empty_Name()
        {
            Mock mock = new Mock();
            mock.GetMethodCallCount("");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Test_GetMethodCallCount_Throws_ArgumentException_On_Null_Name()
        {
            Mock mock = new Mock();
            mock.GetMethodCallCount(null);
        }

        [TestMethod]
        public void Test_GetMethodCallCount_Returns_Correct_Count()
        {
            Mock mock = new Mock();
            int count = mock.GetMethodCallCount("TestMethod");

            Assert.AreEqual(0, count);

            mock.MethodCalled("TestMethod", null);
            count = mock.GetMethodCallCount("TestMethod");

            Assert.AreEqual(1, count);

            mock.MethodCalled("TestMethod", null);
            count = mock.GetMethodCallCount("TestMethod");

            Assert.AreEqual(2, count);

            ArrayList args = new ArrayList();
            args.Add(1);
            args.Add(2);

            mock.MethodCalled("OtherMethod", args);
            count = mock.GetMethodCallCount("TestMethod");
            int otherCount = mock.GetMethodCallCount("OtherMethod");

            Assert.AreEqual(2, count);
            Assert.AreEqual(1, otherCount);
            
            mock.MethodCalled("ThirdMethod", null);
            count = mock.GetMethodCallCount("TestMethod");
            otherCount = mock.GetMethodCallCount("OtherMethod");
            int thirdCount = mock.GetMethodCallCount("ThirdMethod"); 

            Assert.AreEqual(2, count);
            Assert.AreEqual(1, otherCount);
            Assert.AreEqual(1, thirdCount);
        }

        [TestMethod]
        public void Test_SetOutParameter_Properly_Sets_Out_Parameters()
        {
            int param1 = 0;
            OutParameterMock outParameterMock = new OutParameterMock();
            outParameterMock.m_mock.SetOutParam("Method1", "param", 5);
            outParameterMock.Method1(out param1);
            Assert.AreEqual(5, param1);
            outParameterMock.Method1(out param1);
            Assert.AreEqual(5, param1);

            int param2 = 0;
            int param3 = 0;
            outParameterMock.m_mock.SetOutParam("Method2", "param", 6, 1);
            outParameterMock.m_mock.SetOutParam("Method2", "param", 7, 2);
            outParameterMock.Method2(out param2);
            outParameterMock.Method2(out param3);
            Assert.AreEqual(6, param2);
            Assert.AreEqual(7, param3);
        }
    }
}
