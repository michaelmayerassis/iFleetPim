using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using Pim_ControleFrota.Class;

namespace Pim_ControleFrota.Class_DAO
{
    public class ClassAbastecimentoDAO
    {

        ClassAbastecimentos ab = new ClassAbastecimentos();

        public String Cadastrar(ClassAbastecimentos ab)
        {


            //passa a string de conexão
            MySqlConnection con = new MySqlConnection(ClassConectionBanco.StringConexao);
            //abre o banco de dados
            con.Open();
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
                MySqlConnection con = new MySqlConnection(ClassConectionBanco.StringConexao);
                con.Open();

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
    }
}

