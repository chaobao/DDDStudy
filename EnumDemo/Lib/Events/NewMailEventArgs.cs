using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClrWeb.Lib.Events
{
    public class NewMailEventArgs:EventArgs
    {
        private readonly string m_from, n_to, m_subject;

        public NewMailEventArgs(string from,string to,string subject)
        {
            m_from = from;
            m_subject = subject;
            n_to = to;
        }

        public string From
        {
            get { return m_from; }
        }

        public string To
        {
            get { return n_to; }
        }

        public string Subject
        {
            get { return m_subject; }
        }
    }
}