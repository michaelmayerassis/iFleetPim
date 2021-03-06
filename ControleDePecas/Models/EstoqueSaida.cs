﻿using ControleDePecas.DAO;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleDePecas.Models
{
    public class EstoqueSaida
    {
        public DateTime Data { get; set; }
        public Int32 Id { get; set; }

        private Int32 _qtdEstoque;
        public int QtdEstoque
        {
            get => _qtdEstoque;
            set
            {
                if (isQtdValida(value))
                    _qtdEstoque = value;
            }
        }

        private Int32 _idPeca;
        public int IdPeca
        {
            get => _idPeca;
            set
            {
                if (isQtdValida(value))
                    _idPeca = value;
            }
        }

        private Int32 _idOrdemServico;
        public int IdOrdemServico
        {
            get => _idOrdemServico;
            set
            {
                if (isQtdValida(value))
                    _idOrdemServico = value;
            }
        }

        private bool isQtdValida(int qtd)
        {
            return qtd >= 0;
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
    }
}
