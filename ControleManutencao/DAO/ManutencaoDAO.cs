using ControleDePecas.DAO;
using MySql.Data.MySqlClient;
using Pim_ControleFrota;
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
            MySqlCommand command = new MySqlCommand("INSERT INTO Manutencao (Veiculo_Id, Descricao, Data, Situacao, DataPrevista) values (@Veiculo_Id, @Descricao, @Data, @Situacao, @DataPrevista)", conn);
            command.Parameters.Add(new MySqlParameter("Veiculo_Id", manutencao.Veiculo.Id));
            command.Parameters.Add(new MySqlParameter("Descricao", manutencao.Descricao));
            command.Parameters.Add(new MySqlParameter("Data", manutencao.Data));
            command.Parameters.Add(new MySqlParameter("DataPrevista", manutencao.DataPrevista));
            command.Parameters.Add(new MySqlParameter("Situacao", "Em manutencao"));
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

        public List<Manutencao> ListarTodasManutencao()
        {
            List<Manutencao> manutencaos = new List<Manutencao>();
            String query = "SELECT v.Id as IdVeiculo, v.Nome as Nome, v.Placa as Placa , m.id as idManutenção, m.situacao as Situacao, m.Descricao as Descricao, m.Data as Data, m.DataPrevista as DataPrevista FROM VeiculoManutencao vm INNER JOIN veiculo v ON vm.veiculo_id = v.id INNER JOIN manutencao m ON vm.manutencao_id = m.id where m.situacao = 'Em manutencao';";

            MySqlConnection conn = new SqlConnection().Criar();
            MySqlCommand cmd = new MySqlCommand(query, conn);

            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();
                manutencaos = convertDataReaderToList(dr);
            }
            finally
            {
                conn.Close();
            }
            return manutencaos;
        }

        public List<Manutencao> BuscarManutencao(String placa)
        {
            List<Manutencao> manutencaos = new List<Manutencao>();
            String query = "SELECT v.Id as IdVeiculo, v.Nome as Nome, v.Placa as Placa , m.id as idManutenção, m.situacao as Situacao, m.Descricao as Descricao, m.Data as Data, m.DataPrevista as DataPrevista FROM VeiculoManutencao vm INNER JOIN veiculo v ON vm.veiculo_id = v.id INNER JOIN manutencao m ON vm.manutencao_id = m.id where m.situacao = 'Em manutencao' and v.placa like @placa;";
            MySqlConnection conn = new SqlConnection().Criar();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@placa", placa);

            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();
                manutencaos = convertDataReaderToList(dr);
            }
            finally
            {
                conn.Close();
            }
            return manutencaos;

        }

        private List<Manutencao> convertDataReaderToList(MySqlDataReader dr)
        {
            List<Manutencao> manutencaos = new List<Manutencao>();
            while (dr.Read())
            {
                Manutencao m = new Manutencao()
                {
                    Data = Convert.ToDateTime(dr["Data"]),
                    DataPrevista = Convert.ToDateTime(dr["DataPrevista"]),
                    Descricao = dr["Descricao"].ToString(),
                    Situacao = dr["Situacao"].ToString()
                };
                m.Veiculo = new ClassVeiculos();
                m.Veiculo.Nome = dr["Nome"].ToString();
                m.Veiculo.Placa = dr["Placa"].ToString();
                manutencaos.Add(m);
            }
            return manutencaos;
        }

        private int PegarUltimoIdInserido()
        {
            int lastId = 0;
            String query = "select id from manutencao order by id desc limit 1";
            MySqlConnection conn = new SqlConnection().Criar();
            MySqlCommand cmd = new MySqlCommand(query, conn);

            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lastId = Convert.ToInt32(dr["id"]);
            }
            return lastId;
        }

        public bool RetornarPlacasEmManutencao(String placa)
        {
            List<String> placas = new List<String>();
            int registroExiste = 0;
            foreach (Manutencao viagem in ListarTodasManutencao())
            {
                if (viagem.Veiculo.Placa == placa)
                {
                    registroExiste = 1;
                }
            }

            return registroExiste == 1;
        }

        public void InserirManutencaoVeiculo(string placa)
        {
            MySqlConnection conn = new SqlConnection().Criar();
            MySqlCommand cmd = new MySqlCommand("INSERT INTO veiculoManutencao (veiculo_id, Manutencao_id) VALUES (@Veiculo_Id, @idmanutencao)", conn);
            cmd.Parameters.Add(new MySqlParameter("Veiculo_Id", RetornoID(placa)));
            cmd.Parameters.Add(new MySqlParameter("idmanutencao", PegarUltimoIdInserido()));
            cmd.Prepare();
            try
            {
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
            }

        }
    }
}
