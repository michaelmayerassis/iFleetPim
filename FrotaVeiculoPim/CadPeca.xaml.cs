using GerenciadorViagem.DAO;
using GerenciadorViagem.models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ManterVeiculo
{
    /// <summary>
    /// Lógica interna para CadPeca.xaml
    /// </summary>
    public partial class cadPeca //: UserControl
    {
        
        public cadPeca()
        {   
            InitializeComponent();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            Peca peca = new Peca();
            peca.Nome = txtNome.Text;
            peca.Categoria = txtCategoria.Text;
            peca.Pratileira = txtPrateleira.Text;
            peca.Valor = Convert.ToDecimal(txtValor.Text);
            peca.QtdMin = Convert.ToDecimal(txtQtdMin.Text);

             PecaDAO pecaDAO = new PecaDAO();
            String retorno = pecaDAO.cadastrarPeca(peca);
            MessageBox.Show($"{retorno}");
            btnAdicionar.IsEnabled = true;
        }

        internal void ShowDialog()
        {
            throw new NotImplementedException();
        }

        private void BtnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            panel1.IsEnabled = false;
            panel2.IsEnabled = false;
            btnCadastrar.IsEnabled = false;
            gridAdicionar.Children.Add(new Adicionar());
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
        if ((e.Key == Key.Enter)&&(txtNome.Text!=""))
             {
                txtCategoria.Focus();
            }
        }

        private void TxtCategoria_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Enter) && (txtCategoria.Text != ""))
            {
                txtPrateleira.Focus();
            }
        }

        private void TxtValor_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Enter) && (txtValor.Text != ""))
            {
                txtQtdMin.Focus();
            }
        }

        private void TxtPrateleira_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Enter) && (txtPrateleira.Text != ""))
            {
                txtValor.Focus();
            }
        }
    }
}
