using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnumDemo.Lib.Events
{
    public class FooEventArgs : EventArgs { }
    public class TypeWithLotsOfEvents
    {
        private readonly EventSet m_eventSet = new EventSet();

        protected EventSet EventSet { get { return m_eventSet; } }

        protected static readonly EventKey s_fooEventKey = new EventKey();

        public event EventHandler<FooEventArgs> Foo
        {
            add { m_eventSet.Add(s_fooEventKey, value); }
            remove { m_eventSet.Remove(s_fooEventKey, value); }
        }

        protected virtual void OnFoo(FooEventArgs e)
        {
            m_eventSet.Raise(s_fooEventKey, this, e);
        }

        public void SimulateFoo()
        {
            OnFoo(new FooEventArgs());
        }
    }
}
