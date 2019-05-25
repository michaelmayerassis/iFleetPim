using ControleDePecas.DAO;
using ModuloSeguro.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModuloSeguro.DAO
{
   public class SeguroDao
    {
        public void CadastrarSeguro(Seguro seguro)
        {
            MySqlConnection conn = new SqlConnection1().Criar();
            MySqlCommand command = new MySqlCommand("INSERT INTO Seguro (Seguradora, Veiculo_Id, Plano, Apolice, Validade) values (@Seguradora, @Veiculo_Id, @Plano, @Apolice, @Validade)", conn);
            command.Parameters.Add(new MySqlParameter("Seguradora", seguro.Seguradora));
            command.Parameters.Add(new MySqlParameter("Veiculo_Id", seguro.Veiculo_id));
            command.Parameters.Add(new MySqlParameter("Plano", seguro.Plano));
            command.Parameters.Add(new MySqlParameter("Apolice", seguro.Apolice));
            command.Parameters.Add(new MySqlParameter("Validade", seguro.Validade));
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
