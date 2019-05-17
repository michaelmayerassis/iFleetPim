using ModViagem.DAO;
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
//using ModViagem.DAO;
//using ModViagem.models;

namespace FrotaVeiculoPim.Views
{
    /// <summary>
    /// Interação lógica para UserControlCadViagem.xam
    /// </summary>
    public partial class UserControlCadViagem : UserControl
    {
        private String titulo = "Viagens".ToUpper();
        private String tituloChegando = "Entrada de veículo".ToUpper();
        private String tituloSaindo = "Saida de veículo".ToUpper();
        private String tituloListagem = "Veículos em viagem".ToUpper();
        public UserControlCadViagem()
        {
            InitializeComponent();
        }

        private void TxtCpfMotorista_TextChanged(object sender, TextChangedEventArgs e)
        {
            /*int tamanho = txtCpfMotorista.Text.Length;

            if(tamanho == 11)
            {
                gridVeiculo.Visibility = Visibility.Visible;
            }*/
        }

        private void CbVeiculoMulta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //gridCadViagem.Visibility = Visibility.Visible;
        }

        private void BtnChegadaVeiculo_Click(object sender, RoutedEventArgs e)
        {
            tbTitulo.Text = tituloChegando;
            spInicioViagem.Visibility = Visibility.Hidden;
            spCarroChegando.Visibility = Visibility.Visible;
        }

        private void BtnSaidaVeiculo_Click(object sender, RoutedEventArgs e)
        {
            tbTitulo.Text = tituloSaindo;
            spInicioViagem.Visibility = Visibility.Hidden;
            spCarroSaindo.Visibility = Visibility.Visible;
        }

        private void BtnConsultarViagem_Click(object sender, RoutedEventArgs e)
        {
            tbTitulo.Text = tituloListagem;
            spInicioViagem.Visibility = Visibility.Hidden;
            spListarViagem.Visibility = Visibility.Visible;
            ViagemDao vdao = new ViagemDao();
            dgViagem.ItemsSource = vdao.ListarTodasViagens();
        }

        private void CbFiltroVeiculo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string valorCombo = cbFiltroVeiculo.SelectedValue.ToString();
            int index = valorCombo.IndexOf(':');
            string textoCombo = valorCombo.Substring(index + 2);
            if (textoCombo == "Placa")
                lblFiltro.Content = "Informe a " + textoCombo;
            else
                lblFiltro.Content = "Informe o " + textoCombo;
        }

        private void BtnVoltar_Click(object sender, RoutedEventArgs e)
        {
            tbTitulo.Text = titulo;
            spListarViagem.Visibility = Visibility.Hidden;
            spInicioViagem.Visibility = Visibility.Visible;
            
        }

        private void BtnVoltarChegando_Click(object sender, RoutedEventArgs e)
        {
            tbTitulo.Text = titulo;
            spInicioViagem.Visibility = Visibility.Visible;
            spCarroChegando.Visibility = Visibility.Hidden;
            
        }

        private void BtnVoltarSaindo_Click(object sender, RoutedEventArgs e)
        {
            tbTitulo.Text = titulo;
            spInicioViagem.Visibility = Visibility.Visible;
            spCarroSaindo.Visibility = Visibility.Hidden;
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            ViagemDao vdao = new ViagemDao();
            dgViagem.ItemsSource = vdao.BuscarViagem("%" + txtBuscar.Text + "%");
        }

        private void TxtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            ViagemDao vdao = new ViagemDao();
            dgViagem.ItemsSource = vdao.BuscarViagem("%" + txtBuscar.Text + "%");
        }
    }
}
