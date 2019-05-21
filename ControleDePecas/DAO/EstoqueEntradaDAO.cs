using ControleDePecas.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDePecas.DAO
{
    public class EstoqueEntradaDAO
    {
        public void CadastrarEstoque(EstoqueEntrada estoque)
        {
            MySqlConnection conn = new SqlConnection().Criar();
            MySqlCommand command = new MySqlCommand("INSERT INTO MovimentacaoPecaEntrada (Peca_Id, Data, Quantidade) values (@Peca_Id, @Data, @Quantidade)", conn);
            command.Parameters.Add(new MySqlParameter("Peca_Id", estoque.IdPeca));
            command.Parameters.Add(new MySqlParameter("Data", estoque.Data));
            command.Parameters.Add(new MySqlParameter("Quantidade", estoque.QtdEstoque));
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

        public List<EstoqueEntrada> ListaEstoque()
        {
            List<EstoqueEntrada> estoques = new List<EstoqueEntrada>();
            MySqlConnection conn = new SqlConnection().Criar();
            MySqlCommand command = new MySqlCommand("SELECT Id, Nome, Prateleira, EstoqueMinimo, Quantidade FROM Peca", conn);
            try
            {
                MySqlDataReader dr = command.ExecuteReader();
                estoques = convertDataReaderToList(dr);
            }
            finally
            {
                conn.Close();
            }
            return estoques;
        }

        public int RetornoID(string nome)
        {
            MySqlConnection conn = new SqlConnection().Criar();
            MySqlCommand cmd = new MySqlCommand();
            int valor = 0;
            try
            {
                    cmd = new MySqlCommand("select Id from Peca where Nome = ?", conn);
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

        private List<EstoqueEntrada> convertDataReaderToList(MySqlDataReader dreader)
        {
            List<EstoqueEntrada> estoques = new List<EstoqueEntrada>();
            while (dreader.Read())
            {
                EstoqueEntrada estoque = new EstoqueEntrada()
                {
                    Data = Convert.ToDateTime(dreader["Data"]),
                    QtdEstoque = Convert.ToInt32(dreader["Quantidade"]),
                };
                estoques.Add(estoque);
            }
            return estoques;
        }
    }
}
