﻿using ControleDePecas.DAO;
using ControleMulta.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleMulta.DAO
{
   public class MultaDAO
    {
        public void CadastrarMulta(Multa multa)
        {
            MySqlConnection conn = new SqlConnection().Criar();
            MySqlCommand command = new MySqlCommand("INSERT INTO Multa (veiculo_Id, Local, Gravidade, Data) values (@veiculo_Id, @Local, @Gravidade, @Data)", conn);
            command.Parameters.Add(new MySqlParameter("Veiculo_Id", multa.Veiculoid));
            command.Parameters.Add(new MySqlParameter("Local", multa.Local));
            command.Parameters.Add(new MySqlParameter("Gravidade", multa.Gravidade));
            command.Parameters.Add(new MySqlParameter("Data", multa.Data));
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

    }
}
