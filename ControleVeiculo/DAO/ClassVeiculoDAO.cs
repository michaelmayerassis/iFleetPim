using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Data;
using ControleDePecas.DAO;


namespace Pim_ControleFrota.Class_DAO
{
    public class ClassVeiculoDAO
    {
        ClassVeiculos v = new ClassVeiculos();

        public String Cadastrar(ClassVeiculos veiculos)
        {


            //passa a string de conexão
            MySqlConnection con = new SqlConnection().Criar();
            //abre o banco de dados
           // con.Open();
            //Comando sql para inseri dados na tabela
            MySqlCommand cmd = new MySqlCommand("Insert into Veiculo(nome, modelo, placa, ano, renavan, cor, marca)" +
                " values (@nome, @modelo, @placa, @ano, @renavan, @cor, @marca)", con);

            //Passar oque cada campo do banco vai receber
            
            cmd.Parameters.AddWithValue("@nome", veiculos.Nome);
            cmd.Parameters.AddWithValue("@modelo", veiculos.Modelo);
            cmd.Parameters.AddWithValue("@placa", veiculos.Placa);
            cmd.Parameters.AddWithValue("@ano", veiculos.Ano);
            cmd.Parameters.AddWithValue("@renavan", veiculos.Renavan);
            cmd.Parameters.AddWithValue("@cor", veiculos.Cor);
            cmd.Parameters.AddWithValue("@marca", veiculos.Marca);

            //comando para executar query
            cmd.ExecuteNonQuery();
            //fecha conexão
            con.Close();

            return "Cadastro efetuado com sucesso";

        }

        public List<ClassVeiculos> ListarVeiculo()
        {
            List<ClassVeiculos> listaVeiculo = new List<ClassVeiculos>();

            try
            {
                MySqlConnection con = new SqlConnection().Criar();
               // con.Open();

                MySqlCommand cmd = new MySqlCommand("select * from Veiculo", con);
                cmd.Prepare();

                MySqlDataReader dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    ClassVeiculos veiculo = new ClassVeiculos()
                    {
                        Codigo = Convert.ToInt32(dr["Id"]),
                        Nome = dr["Nome"].ToString(),
                        Modelo = dr["Modelo"].ToString(),
                        Placa = dr["Placa"].ToString(),
                        Ano = Convert.ToInt32(dr["Ano"]),
                        Renavan = dr["Renavan"].ToString(),
                        Cor = dr["Cor"].ToString(),
                        Marca = dr["Marca"].ToString()
                    };
                    listaVeiculo.Add(veiculo);
                }

                con.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Erro {0}", e);
            }

            return listaVeiculo;
        }
        public String Alterar(ClassVeiculos veiculos)
        {


            //passa a string de conexão
            MySqlConnection con = new SqlConnection().Criar();
            //abre o banco de dados
            con.Open();
            //Comando sql para inseri dados na tabela
            MySqlCommand cmd = new MySqlCommand("update veiculo set nome=@nome, modelo=@modelo, placa=@placa, ano=@ano, renavan=@renavan, cor=@cor, marca=@marca where (id=@id)", con);

            //Passar oque cada campo do banco vai receber

            cmd.Parameters.AddWithValue("@id", veiculos.Codigo);
            cmd.Parameters.AddWithValue("@nome", veiculos.Nome);
            cmd.Parameters.AddWithValue("@modelo", veiculos.Modelo);
            cmd.Parameters.AddWithValue("@placa", veiculos.Placa);
            cmd.Parameters.AddWithValue("@ano", veiculos.Ano);
            cmd.Parameters.AddWithValue("@renavan", veiculos.Renavan);
            cmd.Parameters.AddWithValue("@cor", veiculos.Cor);
            cmd.Parameters.AddWithValue("@marca", veiculos.Marca);

            //comando para executar query
            cmd.ExecuteNonQuery();
            //fecha conexão
            con.Close();

            return "Alterado com sucesso";

        }

       /* public ClassVeiculos Selecionar(int codigo)
        {
            ClassVeiculos veiculo = new ClassVeiculos();
            MySqlConnection con = new MySqlConnection(ClassConectionBanco.StringConexao);
            con.Open();

            MySqlCommand cmd = new MySqlCommand("select * from veiculo where id = @id", con);


            cmd.Parameters.AddWithValue("@id", veiculo.Codigo);

        }
*/
    }
}
