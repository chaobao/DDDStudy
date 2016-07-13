using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;

namespace ClrWeb.Lib.Events
{
    /// <summary>
    /// 封装线程安全
    /// </summary>
    public static class EventArgExtensions
    { 
        
        public static void Raise<TEventArgs>(this TEventArgs e,Object sender,ref EventHandler<TEventArgs>eventDelegate) where TEventArgs:EventArgs
        {
            EventHandler<TEventArgs> temp = Interlocked.CompareExchange(ref eventDelegate, null, null);
            if (temp!=null)
            {
                temp(sender, e);
            }
        }
    }
}