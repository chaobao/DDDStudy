using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClrWeb.Lib.Manager
{
    public sealed class Fax
    {
        public Fax(MailManager mm)
        {
            mm.NewMail += FaxMsg;
        }

        private void FaxMsg(object sender, Events.NewMailEventArgs e)
        {
            Console.WriteLine("Faxing mail message:");
            Console.WriteLine($"From={e.From},Subject={e.Subject},To={e.To}");
        }

        public void Unregister(MailManager mm)
        {
            mm.NewMail -= FaxMsg;
        }
    }
}