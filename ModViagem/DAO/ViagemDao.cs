using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModViagem.models;
using MySql.Data.MySqlClient;
using ControleDePecas.DAO;
using Pim_ControleFrota;

namespace ModViagem.DAO
{
    public class ViagemDao
    {
        public bool InserirViagem(Viagem v)
        {
            bool sucess = false;
            String query = "INSERT INTO Viagem(Motorista_Cpf, Local, Dt_Saida, Dt_Entrada, km_Saida, km_Entrada, situacao)" +
                "VALUES(@mid, @local, @dtSaida, @dtEntrada, @kmSaida, @kmEntrada, @situacao)";

            MySqlConnection conn = new SqlConnection().Criar();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("mid", v.Motorista.IdMotorista);
            cmd.Parameters.AddWithValue("local", v.Local);
            cmd.Parameters.AddWithValue("dtSaida", v.DataSaida);
            cmd.Parameters.AddWithValue("dtEntrada", v.DataEntrada);
            cmd.Parameters.AddWithValue("kmSaida", v.KmSaida);
            cmd.Parameters.AddWithValue("kmEntrada", v.KmEntrada);
            cmd.Parameters.AddWithValue("situacao", v.Situacao);
            cmd.Prepare();
            try
            {
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
                sucess = true;
            }

            return sucess;

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

        public int PegarIdMotorista(String cpf)
        {
            int idMotorista = 0;
            String query = "select id from motorista where cpf like @cpf";
            MySqlConnection conn = new SqlConnection().Criar();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("cpf", cpf);
            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                idMotorista = Convert.ToInt32(dr["id"]);
            }
            return idMotorista;
        }

        public void InserirViagemVeiculo(string placa)
        {
            String query = "INSERT INTO veiculoviagem (veiculo_id, viagem_id) VALUES (@idveiculo, @idviagem);";

            MySqlConnection conn = new SqlConnection().Criar();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("idveiculo", PegarIdVeiculo(placa));
            cmd.Parameters.AddWithValue("idviagem", PegarUltimoIdInserido());
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

        private int PegarUltimoIdInserido()
        {
            int lastId = 0;
            String query = "select id from viagem order by id desc limit 1";
            MySqlConnection conn = new SqlConnection().Criar();
            MySqlCommand cmd = new MySqlCommand(query, conn);

            MySqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lastId = Convert.ToInt32(dr["id"]);
            }
            return lastId;
        }

        public List<Viagem> ListarTodasViagens()
        {
            List<Viagem> viagens = new List<Viagem>();
            String query = "SELECT v.Id as IdVeiculo,v.Nome as Nome, v.Placa as Placa , via.id as idViagem, via.situacao as Situacao,via.Local as Local, via.Km_Entrada as KmEntrada,via.Dt_Entrada as DataEntrada, via.Dt_Saida as DataSaida,via.Km_Saida as KmSaida, m.Nome as `Nome Motorista`" +
                "FROM VeiculoViagem vv INNER JOIN veiculo v ON vv.veiculo_id = v.id INNER JOIN viagem via ON vv.viagem_id = via.id inner join motorista m on via.Motorista_Cpf = m.id;";

            MySqlConnection conn = new SqlConnection().Criar();
            MySqlCommand cmd = new MySqlCommand(query, conn);

            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();
                viagens = convertDataReaderToList(dr);
            }
            finally
            {
                conn.Close();
            }
            return viagens;
        }

        public List<Viagem> BuscarViagem(String placa)
        {
            List<Viagem> viagens = new List<Viagem>();
            String query = "SELECT v.Id as IdVeiculo,v.Nome as Nome, v.Placa as Placa , via.id as idViagem, via.situacao as Situacao,via.Local as Local, via.Km_Entrada as KmEntrada, via.Dt_Entrada as DataEntrada, via.Dt_Saida as DataSaida,via.Km_Saida as KmSaida,m.Nome as `Nome Motorista` " +
                "FROM VeiculoViagem vv INNER JOIN veiculo v ON vv.veiculo_id = v.id INNER JOIN viagem via ON vv.viagem_id = via.id inner join motorista m on via.Motorista_Cpf = m.id where v.Placa LIKE @placa; ";

            MySqlConnection conn = new SqlConnection().Criar();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@placa", placa);

            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();
                viagens = convertDataReaderToList(dr);
            }
            finally
            {
                conn.Close();
            }
            return viagens;

        }

        public bool AlterarViagem(Viagem v)
        {
            bool sucess = false;
            String query = "UPDATE viagem set Dt_Entrada = @dtentrada, Km_Entrada = @kmEntrada, Situacao = @situacao where id = @id";

            MySqlConnection conn = new SqlConnection().Criar();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("dtentrada", v.DataEntrada);
            cmd.Parameters.AddWithValue("kmEntrada", v.KmEntrada);
            cmd.Parameters.AddWithValue("situacao", "Disponivel");
            cmd.Parameters.AddWithValue("id", v.IdViagem);
            cmd.Prepare();
            try
            {
                cmd.ExecuteNonQuery();
            }
            finally
            {
                conn.Close();
                sucess = true;
            }

            return sucess;
        }

        private List<Viagem> convertDataReaderToList(MySqlDataReader dr)
        {
            List<Viagem> viagens = new List<Viagem>();
            while (dr.Read())
            {
                Viagem v = new Viagem()
                {
                    IdViagem = Convert.ToInt32(dr["idViagem"]),
                    DataEntrada = Convert.ToDateTime(dr["DataEntrada"]),
                    DataSaida = Convert.ToDateTime(dr["DataSaida"]),
                    Local = dr["Local"].ToString(),
                    KmEntrada = Convert.ToDecimal(dr["KmEntrada"]),
                    KmSaida = Convert.ToDecimal(dr["KmSaida"]),
                    Situacao = dr["Situacao"].ToString()
                };
                v.Veiculo = new ClassVeiculos();
                v.Veiculo.Nome = dr["Nome"].ToString();
                v.Veiculo.Placa = dr["Placa"].ToString();
                v.Motorista = new Motorista();
                v.Motorista.Nome = dr["Nome Motorista"].ToString();
                viagens.Add(v);
            }
            return viagens;
        }
    }
}
