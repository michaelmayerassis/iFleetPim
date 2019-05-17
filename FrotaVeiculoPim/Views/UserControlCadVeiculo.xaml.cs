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
using FrotaVeiculoPim;

namespace FrotaVeiculoPim.Views
{
    /// <summary>
    /// Interação lógica para UserControlCadVeiculo.xam
    /// </summary>
    public partial class UserControlCadVeiculo : UserControl
    {
        public UserControlCadVeiculo()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Seguro seguro = new Seguro();
            seguro.ShowDialog();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void BtnCadSeguro_Click(object sender, RoutedEventArgs e)
        {
            Seguro telaSeguro = new Seguro();
            telaSeguro.ShowDialog();
        }

        private void BtnListaVeiculo_Click(object sender, RoutedEventArgs e)
        {
            cadVeiculo.Visibility = Visibility.Hidden;
            listaVeiculo.Visibility = Visibility.Visible;
        }

        private void BtnVoltar_Click(object sender, RoutedEventArgs e)
        {
            listaVeiculo.Visibility = Visibility.Hidden;
            cadVeiculo.Visibility = Visibility.Visible;
        }
    }
}
