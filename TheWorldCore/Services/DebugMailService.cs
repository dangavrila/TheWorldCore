using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWorldCore.Services
{
    public class DebugMailService : IMailService
    {
        public void SendMessage(string subject, string to, string from, string body)
        {
            Debug.WriteLine($"Sending mail: To:{to}; From:{from}; Subject:{subject}");
        }
    }
}
