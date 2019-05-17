using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModViagem.models;
using MySql.Data.MySqlClient;
using ControleDePecas.DAO;

namespace ModViagem.DAO
{
    public class ViagemDao
    {
        public bool InserirViagem(Viagem v)
        {
            bool sucess = false;
            String query = "INSERT INTO Viagem(Motorista_Id, Local, Dt_Saida, Dt_Entrada, km_Saida, km_Entrada)" +
                "VALUES(@mid, @local, @dtSaida, @dtEntrada, @kmSaida, @kmEntrada)";

            MySqlConnection conn = new SqlConnection().CriarConexao();
            MySqlCommand cmd = new MySqlCommand(query,conn);
            cmd.Parameters.AddWithValue("mid", 1);
            cmd.Parameters.AddWithValue("local", v.Local);
            cmd.Parameters.AddWithValue("dtSaida", v.DataSaida);
            cmd.Parameters.AddWithValue("dtEntrada", v.DataEntrada);
            cmd.Parameters.AddWithValue("kmSaida", v.KmSaida);
            cmd.Parameters.AddWithValue("kmEntrada", v.KmEntrada);
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

        public List<Viagem> ListarTodasViagens()
        {
            List<Viagem> viagens = new List<Viagem>();
            String query = "SELECT v.Id as IdVeiculo,v.Nome as Nome, v.Placa as Placa , via.Local as Local, via.Km_Entrada as KmEntrada,via.Dt_Entrada as DataEntrada, via.Dt_Saida as DataSaida,via.Km_Saida as KmSaida " +
                "FROM VeiculoViagem vv INNER JOIN veiculo v ON vv.veiculo_id = v.id INNER JOIN viagem via ON vv.viagem_id = via.id; ";

            MySqlConnection conn = new SqlConnection().CriarConexao();
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
            String query = "SELECT v.Id as IdVeiculo,v.Nome as Nome, v.Placa as Placa , via.Local as Local, via.Km_Entrada as KmEntrada,via.Dt_Entrada as DataEntrada, via.Dt_Saida as DataSaida,via.Km_Saida as KmSaida " +
                "FROM VeiculoViagem vv INNER JOIN veiculo v ON vv.veiculo_id = v.id INNER JOIN viagem via ON vv.viagem_id = via.id where v.Placa LIKE @placa; ";

            MySqlConnection conn = new SqlConnection().CriarConexao();
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

        private List<Viagem> convertDataReaderToList(MySqlDataReader dr)
        {
            List<Viagem> viagens = new List<Viagem>();
            while (dr.Read()) {
                Viagem v = new Viagem()
                {
                    DataEntrada = Convert.ToDateTime(dr["DataEntrada"]),
                    IdVeiculo = Convert.ToInt32(dr["IdVeiculo"]),
                    NomeVeiculo = dr["Nome"].ToString(),
                    PlacaVeiculo = dr["Placa"].ToString(),
                    DataSaida = Convert.ToDateTime(dr["DataSaida"]),
                    Local = dr["Local"].ToString(),
                    KmEntrada = Convert.ToDecimal(dr["KmEntrada"]),
                    KmSaida = Convert.ToDecimal(dr["KmSaida"])

                };
                viagens.Add(v);
            }
            return viagens;
        }
    }
}
