using ControleDePecas.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDePecas.DAO
{
    public class EstoqueSaidaDAO
    {
        public List<EstoqueSaida> Pecas;

        public EstoqueSaidaDAO()
        {
            Pecas = new List<EstoqueSaida>();
        }

        public void Adicionar(EstoqueSaida pecas)
        {
            Pecas.Add(pecas);
        }

        public List<EstoqueSaida> FindAll()
        {
            return Pecas;
        }

        public void CadastrarEstoque(EstoqueSaida estoque)
        {
            MySqlConnection conn = new SqlConnection().Criar();
            MySqlCommand command = new MySqlCommand(typeof(List<EstoqueSaidaDAO>).ToString());
            command = new MySqlCommand("INSERT INTO Peca (Peca_Id, OrdemServico_Id, Data, Quantidade) values (@Peca_Id, @OrdemServico_Id, @Data, @Quantidade)", conn);
            command.Parameters.Add(new MySqlParameter("Peca_Id", estoque.IdPeca));
            command.Parameters.Add(new MySqlParameter("OrdemServico_Id", estoque.IdOrdemServico));
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

        public List<EstoqueSaida> ListaEstoque()
        {
            List<EstoqueSaida> estoques = new List<EstoqueSaida>();
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

        private List<EstoqueSaida> convertDataReaderToList(MySqlDataReader dreader)
        {
            List<EstoqueSaida> estoques = new List<EstoqueSaida>();
            while (dreader.Read())
            {
                EstoqueSaida estoque = new EstoqueSaida()
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
