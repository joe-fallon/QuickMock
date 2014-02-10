using System;
using System.Collections.Generic;
using System.Text;

namespace QuickMock
{
    public class MethodReturnValue
    {
        private string m_methodName;
        private Object m_returnValue;
        private int m_callCount;


        public MethodReturnValue(string methodName, Object returnValue)
        {
            this.m_methodName  = methodName;
            this.m_returnValue = returnValue;
            this.m_callCount   = 0;
        }


        public MethodReturnValue(string methodName, Object returnValue, int callCount)
        {
            this.m_methodName  = methodName;
            this.m_returnValue = returnValue;
            this.m_callCount   = callCount;
        }

        public string MethodName
        {
            get { return this.m_methodName; }
        }

        public Object ReturnValue
        {
            get { return this.m_returnValue; }
        }

        public int CallCount
        {
            get { return this.m_callCount; }
        }
    }
}
