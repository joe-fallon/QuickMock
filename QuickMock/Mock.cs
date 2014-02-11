using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace QuickMock
{
    public class Mock
    {
        private List<MethodCall> m_methodCalls;
        private List<MethodReturnValue> m_methodReturns;
        private List<OutParameter> m_outParams;

        public Mock()
        {
            this.m_methodCalls   = new List<MethodCall>();
            this.m_methodReturns = new List<MethodReturnValue>();
            this.m_outParams     = new List<OutParameter>();
        }


        /// <summary>
        /// This method is used to replace the body of the method being mocked.
        /// </summary>
        /// <param name="methodName">Name of the method that was called.</param>
        /// <param name="args">ArrayList containing the arguments of the method.</param>
        /// <returns>Returns the value specified to be returned by SetMethodReturnValue.</returns>
        public Object MethodCalled(string methodName, ArrayList args)
        {
            if(methodName == null || methodName.Length == 0)
            {
                string msg = "The provided methodName cannot be empty.";
                throw new ArgumentException(msg);
            }

            MethodCall methodCall = new MethodCall(methodName, args);
            this.m_methodCalls.Add(methodCall);

            int callCount = this.GetMethodCallCount(methodName);
            Object returnValue = this.GetMethodReturnValue(methodName, callCount);

            return returnValue;
        }


        /// <summary>
        /// This method returns the number of times that a particular method was called.
        /// </summary>
        /// <param name="methodName">Name of the method.</param>
        /// <returns>Returns the number of times the specified method was called.</returns>
        public int GetMethodCallCount(string methodName)
        {
            if(methodName == null || methodName.Length == 0)
            {
                string msg = "Method name cannot be empty.";
                throw new ArgumentException(msg);
            }

            int count = 0;

            foreach(MethodCall methodCall in this.m_methodCalls)
            {
                if(methodCall.MethodName == methodName)
                {
                    count++;
                }
            }

            return count;
        }


        /// <summary>
        /// This method returns the arguments that were used to call a method for the specified
        /// call count.
        /// </summary>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="callCount">Call count to retrieve the method args for.</param>
        /// <returns></returns>
        public ArrayList GetMethodArgs(string methodName, int callCount = 1)
        {
            string msg;

            if(methodName == null || methodName.Length == 0)
            {
                msg = "The provided methodName cannot be empty.";
                throw new ArgumentException(msg);
            }

            if(callCount < 1)
            {
                msg = "The provided callCount must be greater than zero.";
                throw new ArgumentException(msg);
            }

            int count = 0;
            List<MethodCall> methodCalls = this.m_methodCalls;

            foreach(MethodCall methodCall in methodCalls)
            {
                if(methodCall.MethodName == methodName)
                {
                    count++;
                }

                if(count == callCount)
                {
                    return methodCall.Args;
                }
            }

            msg = "There were no matching method calls given the provided "
                + "methodName and callCount. "
                + "methodName = " + methodName + ", "
                + "callCount = " + callCount;
            throw new Exception(msg);
        }


        /// <summary>
        /// This method is used to specify the particular value to return from a method
        /// when it is called on the specified call count.
        /// </summary>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="returnVal">Value to return.</param>
        /// <param name="callCount">Call count to return the given value.</param>
        public void SetMethodReturnValue(string methodName, Object returnVal, int callCount = 0)
        {
            if(methodName == null || methodName.Length == 0)
            {
                string msg = "The provided methodName cannot be empty.";
                throw new ArgumentException(msg);
            }

            MethodReturnValue methodReturn = null;

            if(callCount == 0)
            {
                methodReturn = new MethodReturnValue(methodName, returnVal);
            }
            else
            {
                methodReturn = new MethodReturnValue(methodName, returnVal, callCount);
            }

            for(int i = 0; i < this.m_methodReturns.Count; i++)
            {
                MethodReturnValue mrv = this.m_methodReturns[i];

                if(mrv.MethodName == methodName && mrv.CallCount == callCount)
                {
                    this.m_methodReturns[i] = methodReturn;
                    return;
                }
            }

            this.m_methodReturns.Add(methodReturn);
        }


        public void SetOutParam(string methodName, string paramName, object outVal, int callCount=0)
        {
            OutParameter outParam = new OutParameter(methodName, paramName, outVal, callCount);
            this.m_outParams.Add(outParam);
        }


        public object GetOutParam(string methodName, string paramName)
        {
            // callCount is set to n+1 due to GetOutParam being always called before
            // MethodCalled is called.
            int callCount = GetMethodCallCount(methodName) + 1;
            
            foreach(OutParameter outParam in this.m_outParams)
            {
                if(outParam.MethodName == methodName && outParam.ParamName == paramName)
                {
                    if(outParam.CallCount == callCount || outParam.CallCount == 0)
                    {
                        return outParam.OutVal;
                    }
                }
            }

            return null;
        }


        private object GetMethodReturnValue(string methodName, int callCount)
        {
            List<MethodReturnValue> methodReturns = this.m_methodReturns;

            foreach(MethodReturnValue mrv in methodReturns)
            {
                if(mrv.MethodName == methodName && mrv.CallCount == callCount)
                {
                    return mrv.ReturnValue;
                }
                else if(mrv.MethodName == methodName && mrv.CallCount == 0)
                {
                    return mrv.ReturnValue;
                }
            }
            
            return null;
        }
    }
}
