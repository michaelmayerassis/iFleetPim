using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using ControleDePecas.Models;
using System.Data;

namespace ControleDePecas.DAO
{
    public class PecaDAO
    {
        public void CadastrarPeca(Peca peca, string tipo)
        {
            MySqlConnection conn = new SqlConnection().Criar();
            MySqlCommand command = new MySqlCommand();
            if (tipo == "cadastrar")
            {
                 command = new MySqlCommand("INSERT INTO Peca (Nome, Descricao, Prateleira, Valor, EstoqueMinimo) values (@Nome, @Descricao, @Prateleira, @Valor, @EstoqueMinimo)", conn);
            }else
            {
                 command = new MySqlCommand("update Peca set Nome = @Nome, Descricao = @Descricao, Prateleira = @Prateleira, Valor = @Valor, EstoqueMinimo = @EstoqueMinimo where Id = @Id)", conn);
            }
            command.Parameters.Add(new MySqlParameter("Nome", peca.Nome));
            command.Parameters.Add(new MySqlParameter("Descricao", peca.Descricao));
            command.Parameters.Add(new MySqlParameter("Prateleira", peca.Pratileira));
            command.Parameters.Add(new MySqlParameter("Valor", peca.Valor));
            command.Parameters.Add(new MySqlParameter("EstoqueMinimo", peca.QtdMin));
            command.Parameters.Add(new MySqlParameter("Id", peca.Id));
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

        public List<Peca> ListarPeca()
        {
            List<Peca> pecas = new List<Peca>();
            MySqlConnection conn = new SqlConnection().Criar();
            MySqlCommand command = new MySqlCommand("SELECT Id, Nome, Descricao, Prateleira, Valor, EstoqueMinimo, Quantidade FROM Peca", conn);
            try
            {
                MySqlDataReader dr = command.ExecuteReader();
                pecas = convertDataReaderToList(dr);
            }
            finally
            {
                conn.Close();
            }
            return pecas;
        }

        public void AlterarQtd(string tipo, decimal valor, string nome)
        {
            MySqlConnection conn = new SqlConnection().Criar();
            MySqlCommand cmd = new MySqlCommand();
            try
            {
                if (tipo == "soma")
                {
                     cmd = new MySqlCommand("update Peca set Quantidade = Quantidade+? where Nome = ?", conn);
                }
                else
                {
                     cmd = new MySqlCommand("update Peca set Quantidade = Quantidade-? where Nome = ?", conn);
                }
                cmd.Parameters.Clear();
                cmd.Parameters.AddWithValue("@Quantidade", valor);
                cmd.Parameters.AddWithValue("@Nome", nome);

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
                MySqlCommand cmd = new MySqlCommand("SELECT nome FROM Peca;", conn);
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

        public int RetornoQtdEstoque(string qtd, string nome)
        {
            MySqlConnection conn = new SqlConnection().Criar();
            MySqlCommand cmd = new MySqlCommand();
            int valor = 0;
            try
            {
                if (qtd == "estoque")
                {
                    cmd = new MySqlCommand("select Quantidade from Peca where Nome = ?", conn);
                }
                else
                {
                    cmd = new MySqlCommand("select EstoqueMinimo from Peca where Nome = ?", conn);
                }
                cmd.Parameters.Clear();
                cmd.Parameters.Add("@nome", MySqlDbType.VarChar, 50).Value = nome;

                cmd.CommandType = CommandType.Text;
                cmd.ExecuteNonQuery();
                MySqlDataReader dreader = cmd.ExecuteReader();
                while (dreader.Read())
                {
                    if (qtd == "estoque")
                    {
                        valor = Convert.ToInt32(dreader["Quantidade"]);
                    }
                    else
                    {
                        valor = Convert.ToInt32(dreader["EstoqueMinimo"]);
                    }
                }

                conn.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Erro {0}", e);
            }
            return valor;
        }

        private List<Peca> convertDataReaderToList(MySqlDataReader dreader)
        {
            List<Peca> pecas = new List<Peca>();
            while (dreader.Read())
            {
                Peca peca = new Peca()
                {
                    Id = Convert.ToInt32(dreader["Id"]),
                    Nome = dreader["Nome"].ToString(),
                    Descricao = dreader["Descricao"].ToString(),
                    Pratileira = dreader["Prateleira"].ToString(),
                    Valor = Convert.ToDecimal(dreader["Valor"]),
                    QtdMin = Convert.ToInt32(dreader["EstoqueMinimo"]),
                    QtdEstoque = Convert.ToInt32(dreader["Quantidade"]),
                };
                pecas.Add(peca);
            }
            return pecas;
        }

    }

}
