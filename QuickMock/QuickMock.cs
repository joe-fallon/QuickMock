using System;
using System.Collections.Generic;
using System.Text;

namespace QuickMock
{
    class QuickMock
    {
        /// <summary>
        /// This method is used to replace the body of the method being mocked.
        /// </summary>
        /// <param name="methodName">Name of the method that was called.</param>
        /// <param name="args">Array containing the arguments of the method.</param>
        /// <returns>Returns the value specified to be returned by SetMethodReturnValue.</returns>
        public Object MethodCalled(string methodName, Array args)
        {
            return null;
        }


        /// <summary>
        /// This method returns the number of times that a particular method was called.
        /// </summary>
        /// <param name="methodName">Name of the method.</param>
        /// <returns>Returns the number of times the specified method was called.</returns>
        public int GetMethodCallCount(string methodName)
        {
            return 0;
        }


        /// <summary>
        /// This method returns the arguments that were used to call a method for the specified
        /// call count.
        /// </summary>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="callCount">Call count to retrieve the method args for.</param>
        /// <returns></returns>
        public Array GetMethodArgs(string methodName, int callCount)
        {
            return null;
        }


        /// <summary>
        /// This method is used to specify the particular value to return from a method
        /// when it is called on the specified call count.
        /// </summary>
        /// <param name="methodName">Name of the method.</param>
        /// <param name="returnVal">Value to return.</param>
        /// <param name="callCount">Call count to return the given value.</param>
        public void SetMethodReturnValue(string methodName, Object returnVal, int callCount)
        {
        }
    }
}
