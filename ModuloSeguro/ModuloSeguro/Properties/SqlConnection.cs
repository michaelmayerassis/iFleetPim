using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ControleDePecas.DAO
{
    public class SqlConnection
    {
        private String connectionString;

        public SqlConnection()
        {
            connectionString = "server=localhost;database=pim;userid=root;password=2303;";
        }

        public MySqlConnection Criar()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            return conn;
        }

        //DEIXA ESSE CODIGO AQUI, DEU ERRO NO ASSEMBLY, E PARA O MODULO VIAGEMs
        public MySqlConnection CriarConexao()
        {
            MySqlConnection conn = new MySqlConnection(connectionString);
            conn.Open();
            return conn;
        }
    }
}
