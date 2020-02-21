using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace PatientMonitoringSystem
{
    class SubscriptionLogger
    {
        private StreamWriter file;

        public SubscriptionLogger()
        {
            var fileName = Path.GetTempPath() + "PatientMonitoringSystemSubSelection.log";
            file = new StreamWriter(fileName, true);
        }

        public void LogSubscriptionSelection(string username, bool pager, bool sms, bool email)
        {
            file.WriteLine(string.Format("User {0} is subscribled to:", username));
            file.WriteLine(string.Format("Pager notifications: {0}", pager.ToString()));
            file.WriteLine(string.Format("SMS notifications: {0}", sms.ToString()));
            file.WriteLine(string.Format("Email notifications: {0}", email.ToString()));
            file.WriteLine("");

            file.Close();
        }
    }
}
