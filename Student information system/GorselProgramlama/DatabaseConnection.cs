using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace GorselProgramlama
{
    class DatabaseConnection
    {
        public static MySqlConnection BaglantiyiAl()
        {
            string connectionString = "Server=localhost;" +
                "Database=School;" +
                "Uid=springstudent;" +
                "Pwd=springstudent1;";
            MySqlConnection baglanti = new MySqlConnection(connectionString);
            return baglanti;
        }


    }
}
