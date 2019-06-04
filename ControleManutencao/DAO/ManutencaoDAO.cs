using ControleDePecas.DAO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleManutencao
{
    public class ManutencaoDAO
    {
        public void CadastrarManutencao(Manutencao manutencao)
        {
            MySqlConnection conn = new SqlConnection().Criar();
            MySqlCommand command = new MySqlCommand("INSERT INTO Manutencao (Veiculo_Id, Descricao, Data, DataPrevista) values (@Veiculo_Id, @Descricao, @Data, @DataPrevista)", conn);
            command.Parameters.Add(new MySqlParameter("Veiculo_Id", manutencao.Veiculo_Id));
            command.Parameters.Add(new MySqlParameter("Descricao", manutencao.Descricao));
            command.Parameters.Add(new MySqlParameter("Data", manutencao.Data));
            command.Parameters.Add(new MySqlParameter("DataPrevista", manutencao.DataPrevista));
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

        public int RetornoID(string nome)
        {
            MySqlConnection conn = new SqlConnection().Criar();
            MySqlCommand cmd = new MySqlCommand();
            int valor = 0;
            try
            {
                cmd = new MySqlCommand("select Id from veiculo where placa = ?", conn);
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@nome", MySqlDbType.VarChar, 50).Value = nome;

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
