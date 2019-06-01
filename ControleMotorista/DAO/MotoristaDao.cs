using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ControleMotorista.Models;
using MySql.Data.MySqlClient;
using System.Windows;
using ControleDePecas.DAO;

namespace ControleMotorista.DAO
{
    public class MotoristaDao
    {
        public void CadastrarMotorista(Motorista motorista)
        {
            MySqlConnection con = new SqlConnection().Criar();


            String Query = "INSERT INTO Motorista (Nome,Cnh,Categoria_Cnh,Dt_Nascimento,Exame_Medico,Email,Endereco,Numero,Cidade,Bairro,Cep) values (@Nome,@Cnh,@Categoria_Cnh,@Dt_Nascimento,@Email,@Endereco,@Numero,@Cidade,@Bairro,@Cep)";
            MySqlCommand cmd = new MySqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@Nome", motorista.Nome);
            cmd.Parameters.AddWithValue("@Cnh", motorista.CNH);
            cmd.Parameters.AddWithValue("@Categoria_Cnh", motorista.Categoria_CNH);
            cmd.Parameters.AddWithValue("@Dt_Nascimento", motorista.DataNasc);
            cmd.Parameters.AddWithValue("@Exame_Medico", motorista.Realizou_Exame);
            cmd.Parameters.AddWithValue("@Email", motorista.Email);
            motorista.Endereco = new Endereco();
            cmd.Parameters.AddWithValue("@Endereco", motorista.Endereco.Rua);
            cmd.Parameters.AddWithValue("@Numero", motorista.Endereco.Numero);
            cmd.Parameters.AddWithValue("@Cidade", motorista.Endereco.Cidade);
            cmd.Parameters.AddWithValue("@Bairro", motorista.Endereco.Bairro);
            cmd.Parameters.AddWithValue("@Cep", motorista.Endereco.CEP);

            cmd.Prepare();
            try
            {
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
            MessageBox.Show("Cadastro realizado com sucesso!");
        }

        public void AlterarMotorista(Motorista motorista)
        {
            MySqlConnection con = new SqlConnection().Criar();


            String Query = "UPDATE SET Motorista (Nome,Cnh,Categoria_Cnh,Dt_Nascimento,Exame_Medico,Email,Endereco,Numero,Cidade,Bairro,Cep) values (@Nome,@Cnh,@Categoria_Cnh,@Dt_Nascimento,@Email,@Endereco,@Numero,@Cidade,@Bairro,@Cep)";
            MySqlCommand cmd = new MySqlCommand(Query, con);

            cmd.Parameters.AddWithValue("@Nome", motorista.Nome);
            cmd.Parameters.AddWithValue("@Cnh", motorista.CNH);
            cmd.Parameters.AddWithValue("@Categoria_Cnh", motorista.Categoria_CNH);
            cmd.Parameters.AddWithValue("@Dt_Nascimento", motorista.DataNasc);
            cmd.Parameters.AddWithValue("@Exame_Medico", motorista.Realizou_Exame);
            cmd.Parameters.AddWithValue("@Email", motorista.Email);
            motorista.Endereco = new Endereco();
            cmd.Parameters.AddWithValue("@Endereco", motorista.Endereco.Rua);
            cmd.Parameters.AddWithValue("@Numero", motorista.Endereco.Numero);
            cmd.Parameters.AddWithValue("@Cidade", motorista.Endereco.Cidade);
            cmd.Parameters.AddWithValue("@Bairro", motorista.Endereco.Bairro);
            cmd.Parameters.AddWithValue("@Cep", motorista.Endereco.CEP);

            cmd.Prepare();
            try
            {
                cmd.ExecuteNonQuery();
            }
            finally
            {
                con.Close();
            }
            MessageBox.Show("Cadastro realizado com sucesso!");
        }
    }
 }
