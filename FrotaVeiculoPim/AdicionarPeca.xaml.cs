using ControleDePecas.DAO;
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

namespace FrotaVeiculoPim.Views
{
    /// <summary>
    /// Lógica interna para AdicionarPeca.xaml
    /// </summary>
    public partial class AdicionarPeca : Window
    {
        public AdicionarPeca()
        {
            InitializeComponent();
            PecaDAO peca = new PecaDAO();
            cbNome.ItemsSource = peca.Listarbox();
            txtData.Text = Convert.ToString(DateTime.Today);
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            PecaDAO peca = new PecaDAO();
            peca.AlterarQtd("soma", Convert.ToInt32(txtQtdEstoque.Text), cbNome.Text);
            MessageBox.Show("Adicionado!!");
        }

        private void BtnFecharAplicacao_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void BtnFecharAplicacao_MouseLeave(object sender, MouseEventArgs e)
        {
            btnFecharAplicacao.Background = Brushes.Transparent;
        }

        private void BtnFecharAplicacao_MouseEnter(object sender, MouseEventArgs e)
        {
            btnFecharAplicacao.Background = Brushes.Red;
        }

        private void CbNome_LostFocus(object sender, RoutedEventArgs e)
        {
            PecaDAO peca = new PecaDAO();
            lblEstoque.Content = ("Em estoque: " + peca.RetornoQtdEstoque("estoque", cbNome.Text));
            lblQtdMin.Content = ("Estoque minímo: " + peca.RetornoQtdEstoque("", cbNome.Text));
        }
    }
}
