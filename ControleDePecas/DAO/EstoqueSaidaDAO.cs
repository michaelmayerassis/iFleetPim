﻿using ControleDePecas.Models;
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
        public void CadastrarEstoque(EstoqueSaida estoque)
        {
            MySqlConnection conn = new SqlConnection().Criar();
            MySqlCommand command = new MySqlCommand("INSERT INTO Peca () values ()", conn);
            command.Parameters.Add(new MySqlParameter("Data", estoque.Data));
            command.Parameters.Add(new MySqlParameter("Quantidade", estoque.QtdEstoque));
            command.Parameters.Add(new MySqlParameter("Quantidade", estoque.IdPeca));
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
