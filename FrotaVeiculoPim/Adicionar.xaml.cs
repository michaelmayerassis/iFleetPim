using GerenciadorViagem.DAO;
using GerenciadorViagem.models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ManterVeiculo
{
    /// <summary>
    /// Lógica interna para Adicionar.xaml
    /// </summary>
    public partial class Adicionar : UserControl
    {
        public Adicionar()
        {
            InitializeComponent();
            ListarCombobox();
        }
        public void ListarCombobox()
        {
           MySqlConnection conn = new MySqlConnection(@"server=localhost;database=testepim;userid=root;password=2303;");
            try
            {
                conn.Open();
                String cmd = "select nome from peca";
                MySqlCommand da = new MySqlCommand(cmd, conn);
                MySqlDataReader dr = da.ExecuteReader();
                while (dr.Read())
                {
                    string name = dr.GetString(0);
                    cbNome.Items.Add(name);
                }
                conn.Close();
            }
            catch (Exception e)
            {
                throw new Exception("Erro {0}", e);
            }
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            PecaDAO peca = new PecaDAO();
            peca.alterarQtd(Convert.ToDecimal(txtqtd.Text), cbNome.Text);
            MessageBox.Show("salvo");
        }

        private void ComboBox_Initialized(object sender, EventArgs e)
        {
            
            
        }
    }
}
