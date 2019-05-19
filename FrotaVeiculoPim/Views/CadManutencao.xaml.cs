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
using System.Windows.Shapes;

namespace FrotaVeiculoPim.Views
{
    /// <summary>
    /// Lógica interna para CadManutencao.xaml
    /// </summary>
    public partial class CadManutencao //: UserControl
    {
        private Peca1 peca1;
        private PecaDAO pecaDAO;
        private PecaDAO1 pecaDAO1;
        public CadManutencao()
        {
            InitializeComponent();
            peca1 = new Peca1();
            pecaDAO = new PecaDAO();
            pecaDAO1 = new PecaDAO1();

        }

        private void BtnCadManutencao_Click(object sender, RoutedEventArgs e)
        {
            tbTitulo.Text = "CADASTRAR MANUTENÇÃO";
            spInManutencao.Visibility = Visibility.Hidden;
            spCadManutencao.Visibility = Visibility.Visible;
        }

        private void BtnFinalizar_Click(object sender, RoutedEventArgs e)
        {
            tbTitulo.Text = "FINALIZAR MANUTENÇÃO";
            spInManutencao.Visibility = Visibility.Hidden;
            spFinalizarManutencao.Visibility = Visibility.Visible;
            cbPeca.ItemsSource = pecaDAO.Listarbox();
        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            tbTitulo.Text = "VEICULOS EM MANUTENÇÃO";
            spInManutencao.Visibility = Visibility.Hidden;
            spListarVeiculos.Visibility = Visibility.Visible;
        }

        private void BtnVoltarSaindo_Click(object sender, RoutedEventArgs e)
        {
            tbTitulo.Text = "MANUTENÇÃO";
            spInManutencao.Visibility = Visibility.Visible;
            spCadManutencao.Visibility = Visibility.Hidden;
        }

        private void BtnVoltarSaindo1_Click(object sender, RoutedEventArgs e)
        {
            tbTitulo.Text = "MANUTENÇÃO";
            spInManutencao.Visibility = Visibility.Visible;
            spFinalizarManutencao.Visibility = Visibility.Hidden;
        }

        private void BtnVoltar_Click(object sender, RoutedEventArgs e)
        {
            tbTitulo.Text = "MANUTENÇÃO";
            spInManutencao.Visibility = Visibility.Visible;
            spListarVeiculos.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if ((txtDescricao.Text == "") || (txtPlaca.Text == ""))
            {
                MessageBox.Show("há campos vazios ou incorretos!");
            }
            else
            {
                MessageBox.Show("Manutenção cadastrada!");
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if ((txtDescricao1.Text == "") || (txtPlaca.Text == ""))
            {
                MessageBox.Show("há campos vazios ou incorretos!");
            }
            else
            {
                MessageBox.Show("Manutenção cadastrada!");
            }
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            Peca1 p = new Peca1
            {
                peca = cbPeca.Text,
                Quantidade = Convert.ToInt32(txtQtd.Text)
            };
            pecaDAO1.Adicionar(p);
            dgPeca.ItemsSource = "";
            dgPeca.ItemsSource = pecaDAO1.Pecas;
        }

        private void BtnDeletar_Click(object sender, RoutedEventArgs e)
        {
            Peca1 peca = new Peca1();
            peca = dgPeca.SelectedItem as Peca1;
            pecaDAO1.Pecas.Remove(peca);
            dgPeca.ItemsSource = "";
            dgPeca.ItemsSource = pecaDAO1.Pecas;
        }
    }
}
