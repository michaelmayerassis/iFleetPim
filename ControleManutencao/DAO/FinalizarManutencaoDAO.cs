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
            command.Parameters.Add(new MySqlParameter("Manutencao_Id", manutencao.Manutencao.Id));
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

        private int PegarIdVeiculo(string placa)
        {
            int idVeiculo = 0;
            String query = "select id from veiculo where placa like @placa";
            MySqlConnection conn = new SqlConnection().Criar();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("placa", placa);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                idVeiculo = Convert.ToInt32(dr["id"]);
            }
            return idVeiculo;
        }

        public int PegarIdMamutencao(string placa)
        {
            int idManutencao = 0;
            String query = "select id from manutencao where veiculo_id like @idveiculo";
            MySqlConnection conn = new SqlConnection().Criar();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("idveiculo", PegarIdVeiculo(placa));
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                idManutencao = Convert.ToInt32(dr["id"]);
            }
            return idManutencao;
        }

        public int PegarUltimoIdInserido()
        {
            int lastId = 0;
            String query = "select id from ordemservico order by id desc limit 1";
            MySqlConnection conn = new SqlConnection().Criar();
            MySqlCommand cmd = new MySqlCommand(query, conn);

            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lastId = Convert.ToInt32(dr["id"]);
            }
            return lastId;
        }

        public void AlterarSituacao(int id)
        {
            MySqlConnection conn = new SqlConnection().Criar();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                    cmd = new MySqlCommand("update manutencao set Situacao = 'Manutencao realizada' where id = ?", conn);
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@id", id);

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();

                conn.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Erro {0}", e);
            }
        }

         public List<object> Listarbox()
        {
            List<object> listabox = new List<object>();
            MySqlConnection conn = new SqlConnection().Criar();

            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT v.Placa as Placa FROM VeiculoManutencao vm INNER JOIN veiculo v ON vm.veiculo_id = v.id INNER JOIN manutencao m ON vm.manutencao_id = m.id where m.situacao = 'Em manutencao'", conn);
                cmd.Prepare();

                MySqlDataReader dreader = cmd.ExecuteReader();

                while (dreader.Read())
                {
                    listabox.Add(dreader.GetString(0));
                }

                conn.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Erro {0}", e);
            }

            return listabox;
        }
    }
}
