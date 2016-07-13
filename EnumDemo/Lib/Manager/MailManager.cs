using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using ClrWeb.Lib.Events;

namespace ClrWeb.Lib.Manager
{
    public class MailManager
    {
        public event EventHandler<NewMailEventArgs> NewMail;

        protected virtual void OnNewMail(NewMailEventArgs e)
        {
            e.Raise(this, ref NewMail);
        }

        public void SimulateNewMail(string from,string to,string subject)
        {
            NewMailEventArgs e = new NewMailEventArgs(from, to, subject);
            OnNewMail(e);
        }
    }
}