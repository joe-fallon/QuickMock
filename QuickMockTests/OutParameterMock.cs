using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using QuickMock;
using System.Collections;

namespace QuickMockTests
{
    class OutParameterMock
    {
        public Mock m_mock;

        public OutParameterMock()
        {
            this.m_mock = new Mock();
        }

        public void Method1(out int param)
        {
            param = (int)this.m_mock.GetOutParam("Method1", "param");

            ArrayList args = new ArrayList();
            args.Add(param);

            this.m_mock.MethodCalled("Method1", args);
        }

        public void Method2(out int param)
        {
            param = (int)this.m_mock.GetOutParam("Method2", "param");

            ArrayList args = new ArrayList();
            args.Add(param);

            this.m_mock.MethodCalled("Method2", args);
        }
    }
}
