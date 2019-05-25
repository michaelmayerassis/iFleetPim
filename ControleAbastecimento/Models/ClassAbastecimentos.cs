using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using ControleDePecas.DAO;

namespace Pim_ControleFrota
{
    public class ClassAbastecimentos
    {
        public Int32 Codigo { get; set; }
        //public decimal Valor_Unit { get; set; }
        public Double Valor_Total { get; set; }
        //DateTime Data { get; set; }
        public Double KM { get; set; }
        public Double Quant { get; set; }
        public Int32 Codigo_Veiculo { get; set; }
        public String Combustivel { get; set; }

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

