using ControleDePecas.DAO;
using ControleManutencao.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleManutencao.DAO
{
    public class FinalizarManutencaoDAO
    {
        public void FinalizarManutencao(FinalizarManutencao manutencao)
        {
            MySqlConnection conn = new SqlConnection().Criar();
            MySqlCommand command = new MySqlCommand("INSERT INTO OrdemServico (Manutencao_Id, Dt_Saida, Valor, Observacao) values (@Manutencao_Id, @Dt_Saida, @Valor, @Observacao)", conn);
            command.Parameters.Add(new MySqlParameter("Manutencao_Id", manutencao.Manutencao_Id));
            command.Parameters.Add(new MySqlParameter("Dt_Saida", manutencao.Data));
            command.Parameters.Add(new MySqlParameter("Valor", manutencao.Valor));
            command.Parameters.Add(new MySqlParameter("Observacao", manutencao.Obs));
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
