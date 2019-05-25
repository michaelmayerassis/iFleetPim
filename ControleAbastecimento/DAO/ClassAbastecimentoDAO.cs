using System;
using System.Collections.Generic;
using ControleDePecas.DAO;
using MySql.Data.MySqlClient;

namespace Pim_ControleFrota.Class_DAO
{
    public class ClassAbastecimentoDAO
    {

        ClassAbastecimentos ab = new ClassAbastecimentos();

        public String Cadastrar(ClassAbastecimentos ab)
        {


            MySqlConnection con = new SqlConnection().Criar();
            //Comando sql para inseri dados na tabela
            MySqlCommand cmd = new MySqlCommand("Insert into Abastecimento(Veiculo_Id, Combustivel, Valor, Quantidade, Km)" +
                " values (@Veiculo_Id, @Combustivel, @Valor, @Quantidade, @Km)", con);

            //Passar oque cada campo do banco vai receber

            cmd.Parameters.AddWithValue("@Veiculo_Id", ab.Codigo_Veiculo);
            cmd.Parameters.AddWithValue("@Combustivel", ab.Combustivel);
            cmd.Parameters.AddWithValue("@Valor", ab.Valor_Total);
            cmd.Parameters.AddWithValue("@Quantidade", ab.Quant);
            cmd.Parameters.AddWithValue("@Km", ab.KM);

            //comando para executar query
            cmd.ExecuteNonQuery();
            //fecha conexão
            con.Close();

            return "Cadastro efetuado com sucesso";

        }

        public List<ClassAbastecimentos> ListarVeiculo()
        {
            List<ClassAbastecimentos> listaVeiculo = new List<ClassAbastecimentos>();

            try
            {
                MySqlConnection con = new SqlConnection().Criar();

                MySqlCommand cmd = new MySqlCommand("select * from veiculo", con);
                cmd.Prepare();

                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ClassAbastecimentos ab = new ClassAbastecimentos()
                    {
                        Codigo = Convert.ToInt32(dr["Id"]),
                        Codigo_Veiculo = Convert.ToInt32(dr["Veiculo_Id"]),
                        Combustivel = dr["Combustivel"].ToString(),
                        Valor_Total = Convert.ToDouble(dr["Valor"]),
                        Quant = Convert.ToDouble(dr["Quantidade"]),
                        KM = Convert.ToDouble(dr["Km"])

                    };
                    listaVeiculo.Add(ab);
                }

                con.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Erro {0}", e);
            }

            return listaVeiculo;
        }

        public List<object> Listarbox()
        {
            List<object> listabox = new List<object>();
            MySqlConnection conn = new SqlConnection().Criar();

            try
            {
                MySqlCommand cmd = new MySqlCommand("SELECT placa FROM Veiculo;", conn);
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
    }
}

