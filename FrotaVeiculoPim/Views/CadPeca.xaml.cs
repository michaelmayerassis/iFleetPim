using ControleDePecas.DAO;
using ControleDePecas.Models;
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

namespace FrotaVeiculoPim.Views
{
    /// <summary>
    /// Lógica interna para CadPeca.xaml
    /// </summary>
    public partial class CadPeca// : UserControl
    {
        private Peca peca;
        private PecaDAO pecaDAO;
        public CadPeca()
        {   
            InitializeComponent();
            peca = new Peca();
            pecaDAO = new PecaDAO();
        }

        private void btnCadastrar_Click(object sender, RoutedEventArgs e)
        {
           if (txtNome.Text == "")
            {
                MessageBox.Show("É obrigatório preencher o campo nome para proseguir com o cadastro!");
            }
            else
            {
                if ((txtPrateleira.Text == "") || (txtQtdMin.Text == "") || (txtDescricao.Text == ""))
                {
                    if (MessageBox.Show("Há campos em branco, prosseguir com cadastro mesmo assim?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                            Pecas();
                        pecaDAO.CadastrarPeca(peca, "cadastrar");
                        if (MessageBox.Show("Cadastro realizado com sucesso, deseja movimentar estoque ?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            AdicionarPeca adicionarPeca = new AdicionarPeca();
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                            mainWindow.imgFundo.Visibility = Visibility.Collapsed;
                            mainWindow.ButtonCloseMenu.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                            mainWindow.GridPrincipal.Children.Add(adicionarPeca);
                            adicionarPeca.cbNome.Text = txtNome.Text;
                           //adicionarPeca.txtQtdEstoque.Focus();
                        }
                        else
                        {
                            Limpar();
                        }
                    }
                }
            }
        }

        internal void ShowDialog()
        {
            throw new NotImplementedException();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
        if ((e.Key == Key.Enter)&&(txtNome.Text!=""))
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

        private void BtnListarPeca_Click(object sender, RoutedEventArgs e)
        {
            cadPeca.Visibility = Visibility.Collapsed;
            dgListar.Visibility = Visibility.Visible;
            txtTitulo.Text = "LISTAR PEÇAS";
            btnVoltar.Visibility = Visibility.Visible;
            dgListar.ItemsSource = pecaDAO.ListarPeca();
        }

        private void Pecas()
        {
            peca.Nome = txtNome.Text;
            peca.Pratileira = txtPrateleira.Text;
            peca.Valor = Convert.ToDecimal(txtValor.Text.Replace('$', ' ').Replace('.', ','));
            if (txtQtdMin.Text == "")
            {
                peca.QtdMin = 0;
            }
            else
            {
                peca.QtdMin = Convert.ToInt32(txtQtdMin.Text);
            }
                peca.Descricao = txtDescricao.Text;
        }

        private void Limpar()
        {
            txtNome.Text = "";
            txtPrateleira.Text = "";
            txtQtdMin.Text = "";
            txtValor.Text = "";
            txtDescricao.Text = "";
        }

        private void btnVoltar_Click(object sender, RoutedEventArgs e)
        {
            txtTitulo.Text = "PEÇA";
            dgListar.Visibility = Visibility.Collapsed;
            cadPeca.Visibility = Visibility.Visible;
            btnVoltar.Visibility = Visibility.Collapsed;
        }

        private void DgListar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            dgListar.Visibility = Visibility.Collapsed;
            cadPeca.Visibility = Visibility.Visible;
            btnVoltar.Visibility = Visibility.Collapsed;
            btnCadastrar.Visibility = Visibility.Collapsed;
            btnAltera.Visibility = Visibility.Visible;
            peca = dgListar.SelectedItem as Peca;
            txtNome.Text = peca.Nome.ToString();
            txtPrateleira.Text = peca.Pratileira;
            txtValor.Number = peca.Valor;
            txtQtdMin.Text = peca.QtdMin.ToString();
            txtDescricao.Text = peca.Descricao;
        }

        private void BtnAltera_Click(object sender, RoutedEventArgs e)
        {
            if (txtNome.Text == "")
            {
                MessageBox.Show("É obrigatório preencher o campo nome para proseguir com o cadastro!");
            }
            else
            {
                if ((txtPrateleira.Text == "") || (txtQtdMin.Text == "") || (txtDescricao.Text == ""))
                {
                    if (MessageBox.Show("Há campos em branco, prosseguir com cadastro mesmo assim?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        Pecas();
                        pecaDAO.CadastrarPeca(peca, "alterar");
                        MessageBox.Show("Cadastro alterado com sucesso!");
                    }
                }
            }
        }
    }
}
