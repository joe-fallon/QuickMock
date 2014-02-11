using System;
using System.Collections.Generic;
using System.Text;

namespace QuickMock
{
    public class OutParameter
    {
        private string m_methodName;
        private string m_parameterName;
        private object m_outValue;
        private int    m_callCount;


        public OutParameter(string methodName, string paramName, object outVal, int callCount=0)
        {
            if(methodName == null || methodName.Length == 0)
            {
                string msg = "The provided methodName cannot be empty.";
                throw new ArgumentException(msg);
            }

            if(paramName == null || paramName.Length == 0)
            {
                string msg = "The provided paramName cannot be empty.";
                throw new ArgumentException(msg);
            }

            this.m_methodName    = methodName;
            this.m_parameterName = paramName;
            this.m_outValue      = outVal;
            this.m_callCount     = callCount;
        }


        public string MethodName 
        { 
            get
            {
                return this.m_methodName;
            }
        }


        public string ParamName 
        { 
            get
            {
                return this.m_parameterName;
            }
        }


        public object OutVal 
        { 
            get
            {
                return this.m_outValue;
            }
        }


        public int CallCount 
        { 
            get
            {
                return this.m_callCount;
            }
        }
    }
}
