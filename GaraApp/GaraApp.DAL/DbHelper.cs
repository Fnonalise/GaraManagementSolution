using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace GaraApp.DAL
{
    internal static class DbHelper
    {
        public static string ConnectionString => ConfigurationManager.ConnectionStrings["GaraDb"].ConnectionString;
    }
}
