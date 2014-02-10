using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;

namespace QuickMock
{
    public class MethodCall
    {
        private string m_methodName;
        private ArrayList m_args;

        public MethodCall(string methodName, ArrayList args)
        {
            if(methodName == null || methodName.Length == 0)
            {
                string msg = "The provided methodName cannot be empty.";
                throw new ArgumentException(msg);
            }

            this.m_methodName = methodName;
            this.m_args       = args;
        }

        public string MethodName
        {
            get { return this.m_methodName; }
        }

        public ArrayList Args
        {
            get { return this.m_args; }
        }
    }
}
