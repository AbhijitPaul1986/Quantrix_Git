using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class ConnectionProvider
    {
        public string conStr = "";
        public ConnectionProvider()
        {
            conStr = System.Configuration.ConfigurationManager.ConnectionStrings["QuantrixConnection"].ConnectionString;
        }
    }
}
