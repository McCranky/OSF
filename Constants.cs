using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OSF {
    class Constants {
        public static string VERZIA = "1.0 beta";
        public static string AUTOR = "Marek Smatana";
        public static string ROK = "2019";
        public static string CONNECTIONSTRING = ConfigurationManager.ConnectionStrings["OSF.Properties.Settings.OSF_DatabaseConnectionString"].ConnectionString;
    }
}
