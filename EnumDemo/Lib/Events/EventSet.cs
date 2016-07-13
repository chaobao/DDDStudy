using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace EnumDemo.Lib.Events
{
    public sealed class EventSet
    {
        private readonly Dictionary<EventKey, Delegate> m_events = new Dictionary<EventKey, Delegate>();

        public void Add(EventKey eventKey, Delegate handler)
        {
            Monitor.Enter(m_events);
            Delegate d;
            m_events.TryGetValue(eventKey, out d);
            m_events[eventKey] = Delegate.Combine(d, handler);
            Monitor.Exit(m_events);
        }

        public void Remove(EventKey eventKey, Delegate handler)
        {
            Delegate d;
            Monitor.Enter(m_events);
            if (m_events.TryGetValue(eventKey, out d))
            {
                d = Delegate.Remove(d, handler);

                if (d != null)
                {
                    m_events[eventKey] = d;
                }
                else
                {
                    m_events.Remove(eventKey);
                }
            }
            Monitor.Exit(m_events);
        }

        //为指定的EventKey引发事件
        public void Raise(EventKey eventKey, Object sender, EventArgs e)
        {
            Delegate d;
            Monitor.Enter(m_events);
            m_events.TryGetValue(eventKey, out d);
            Monitor.Exit(m_events);
            if (d != null)

                /*由于字典可能包含几个不同的委托类型
                // 所以无法在编译时构造一个类型安全的委托调用。
                // 因此，我调用System.Delegate类型的DynamicInvoke方法，
                //以一个对象数组的形式向他传递回调方法的参数。
                //在内部，DynamicInvoke会向调用的回调方法查证参数类型的安全性，并调用方法的参数。
                    如果存在类型不匹配的方法，DynamicInvoke会抛出异常。
                */
                d.DynamicInvoke(new object[] { sender, e });
        }
    }
}

