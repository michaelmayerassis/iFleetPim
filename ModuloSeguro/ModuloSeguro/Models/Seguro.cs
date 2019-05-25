using ControleDePecas.DAO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloSeguro.Models
{
   public class Seguro
    {
        public int Veiculo_id { get; set; }
        public string Seguradora { get; set; }
        public string Plano { get; set; }
        public string Apolice { get; set; }
        public DateTime Validade { get; set; }

        public int RetornoID(string placa)
        {
            MySqlConnection conn = new SqlConnection().Criar();
            MySqlCommand cmd = new MySqlCommand();
            int valor = 0;
            try
            {
                cmd = new MySqlCommand("select Id from Veiculo where Placa = ?", conn);
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@placa", MySqlDbType.VarChar, 50).Value = placa;

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                MySqlDataReader dreader = cmd.ExecuteReader();
                while (dreader.Read())
                {
                    valor = Convert.ToInt32(dreader["Id"]);
                }

                conn.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Erro {0}", e);
            }
            return valor;
        }
    }


}
