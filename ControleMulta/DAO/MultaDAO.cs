using ControleDePecas.DAO;
using ControleMulta.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMulta.DAO
{
   public class MultaDAO
    {
        public void CadastrarMulta(Multa multa)
        {
            MySqlConnection conn = new SqlConnection().Criar();
            MySqlCommand command = new MySqlCommand("INSERT INTO Multa (veiculo_Id, Cep, Cidade, Estado, Endereco, Gravidade , Data) values (@veiculo_Id, @Cep, @Cidade, @Estado, @Endereco, @Gravidade, @Data)", conn);
            command.Parameters.Add(new MySqlParameter("Veiculo_Id", multa.Veiculoid));
            command.Parameters.Add(new MySqlParameter("Cep", multa.Cep));
            command.Parameters.Add(new MySqlParameter("Cidade", multa.Cidade));
            command.Parameters.Add(new MySqlParameter("Estado", multa.Estado));
            command.Parameters.Add(new MySqlParameter("Endereco", multa.Endereco));
            command.Parameters.Add(new MySqlParameter("Gravidade", multa.Gravidade));
            command.Parameters.Add(new MySqlParameter("Data", multa.Data));
            command.Prepare();
            try
            {
                command.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }
        }

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
