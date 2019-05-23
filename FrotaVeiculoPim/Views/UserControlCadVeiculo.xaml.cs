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
using Pim_ControleFrota;
using Pim_ControleFrota.Class_DAO;

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
            //Seguro seguro = new Seguro();
           // seguro.ShowDialog();
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void BtnCadSeguro_Click(object sender, RoutedEventArgs e)
        {
           // Seguro telaSeguro = new Seguro();
           // telaSeguro.ShowDialog();
        }

        private void BtnListaVeiculo_Click(object sender, RoutedEventArgs e)
        {
            ClassVeiculoDAO veiculoDAO = new ClassVeiculoDAO();
            cadVeiculo.Visibility = Visibility.Hidden;
            listaVeiculo.Visibility = Visibility.Visible;
            dgListar.ItemsSource = veiculoDAO.ListarVeiculo();
        }

        private void BtnVoltar_Click(object sender, RoutedEventArgs e)
        {
            listaVeiculo.Visibility = Visibility.Hidden;
            cadVeiculo.Visibility = Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            ClassVeiculos veiculos = new ClassVeiculos();
            veiculos.Ano = Convert.ToInt32(txtAno.Text);
            veiculos.Cor = txtCor.Text;
            veiculos.Marca = txtMarca.Text;
            veiculos.Modelo = txtModelo.Text;
            veiculos.Nome = txtNomeVeiculo.Text;
            veiculos.Renavan = txtRenavan.Text;
            veiculos.Placa = txtPlaca.Text;
            ClassVeiculoDAO veiculoDAO = new ClassVeiculoDAO();
            veiculoDAO.Cadastrar(veiculos);
            MessageBox.Show("cadastrado");
        }
    }
}
