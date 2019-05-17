using ControleDePecas.DAO;
using ControleDePecas.Models;
using System;
using System.Collections.Generic;
using System.Data;
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
    /// Lógica interna para ListarPeca.xaml
    /// </summary>
    public partial class ListarPeca : Window
    {
        public ListarPeca()
        {
            InitializeComponent();
            PecaDAO pecaDAO = new PecaDAO();
            dgListar.ItemsSource = pecaDAO.ListarPeca();
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

        private void DgListar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Close();
            CadPeca cadPeca = new CadPeca();
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            mainWindow.imgFundo.Visibility = Visibility.Collapsed;
            mainWindow.ButtonCloseMenu.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            mainWindow.GridPrincipal.Children.Add(cadPeca);
            Peca peca = new Peca();
            peca = dgListar.SelectedItem as Peca;
            cadPeca.txtNome.Text = peca.Nome.ToString();
            cadPeca.txtPrateleira.Text = peca.Pratileira;
            cadPeca.txtValor.Number = peca.Valor;
            cadPeca.txtQtdMin.Text = peca.QtdMin.ToString();


        }
    }
}
