using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleDePecas.DAO;
using ControllerMotorista.models;
using MySql.Data.MySqlClient;

namespace ControllerMotorista.dao
{
    public class MotoristaDao
    {
        public void InserirMotorista(Motorista m)
        {
            String query = "INSERT INTO Motorista (Cpf, Nome, Cnh,Categoria_Cnh, Dt_Nascimento,Exame_Medico, Email, Endereco, Numero, Cidade, Bairro, Cep)" +
                "VALUES (@cpf, @nome, @cnh, @categoriaCnh, @dtNascimento, @exame, @email, @endereco, @numero,@cidade,@bairro, @cep)";
            MySqlConnection conn = new SqlConnection().Criar();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("cpf", m.Cpf);
            cmd.Parameters.AddWithValue("nome", m.Nome);
            cmd.Parameters.AddWithValue("cnh", m.Cnh);
            cmd.Parameters.AddWithValue("categoriaCnh", m.CategoriaCnh);
            cmd.Parameters.AddWithValue("dtNascimento", m.DataNascimento);
            cmd.Parameters.AddWithValue("exame", m.ExameMedico);
            cmd.Parameters.AddWithValue("email", m.Email);
            cmd.Parameters.AddWithValue("endereco", m.Endereco.Rua);
            cmd.Parameters.AddWithValue("numero", m.Endereco.Numero);
            cmd.Parameters.AddWithValue("cidade", m.Endereco.Cidade);
            cmd.Parameters.AddWithValue("bairro", m.Endereco.Bairro);
            cmd.Parameters.AddWithValue("cep", m.Endereco.Cep);
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

        public List<Motorista> ListarMotorista()
        {
            List<Motorista> motorista = new List<Motorista>();
            String query = "select * from motorista";

            MySqlConnection conn = new SqlConnection().Criar();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();
                motorista = convertDataReaderToList(dr);
            }
            finally
            {
                conn.Close();
            }
            return motorista;
        }

        public List<Motorista> BuscarMotorista(String nome)
        {
            List<Motorista> motorista = new List<Motorista>();
            String query = "select * from motorista where nome LIKE @nome;";

            MySqlConnection conn = new SqlConnection().Criar();
            MySqlCommand cmd = new MySqlCommand(query, conn);
            cmd.Parameters.AddWithValue("nome", nome);
            try
            {
                MySqlDataReader dr = cmd.ExecuteReader();
                motorista = convertDataReaderToList(dr);
            }
            finally
            {
                conn.Close();
            }
            return motorista;
        }

        private List<Motorista> convertDataReaderToList(MySqlDataReader dr)
        {
            List<Motorista> motorista = new List<Motorista>();

            while (dr.Read())
            {
                Motorista m = new Motorista()
                {
                    IdMotorista = Convert.ToInt32(dr["Id"]),
                    Cpf = dr["Cpf"].ToString(),
                    Nome = dr["Nome"].ToString(),
                    Cnh = dr["Cnh"].ToString(),
                    CategoriaCnh = dr["Categoria_Cnh"].ToString(),
                    DataNascimento = Convert.ToDateTime(dr["Dt_Nascimento"]),
                    ExameMedico = dr["Exame_Medico"].ToString(),
                    Email = dr["Email"].ToString(),
                };
                m.Endereco = new Endereco();
                m.Endereco.Rua = dr["Endereco"].ToString();
                m.Endereco.Numero = dr["Numero"].ToString();
                m.Endereco.Cidade = dr["Cidade"].ToString();
                m.Endereco.Bairro = dr["Bairro"].ToString();
                m.Endereco.Cep = dr["Cep"].ToString();
                motorista.Add(m);
            }
            return motorista;
        }

    }
}
