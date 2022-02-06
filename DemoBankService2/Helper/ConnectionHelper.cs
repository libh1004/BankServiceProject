using MySqlConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBankService2.Helper
{
    public class ConnectionHelper
    {
        private const string Server = "";
        private const string DbName = "";
        private const string UserName = "root";
        private const string Password = "";

        private static readonly string StringConnection =
            $"Server={Server};database={DbName};UID={UserName};password={Password}";
        private MySqlConnection _connectionBank = null;

    }
}
