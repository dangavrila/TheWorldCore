using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheWorldCore.Services
{
    public interface IMailService
    {
        void SendMessage(string subject, string to, string from, string body);
    }
}
