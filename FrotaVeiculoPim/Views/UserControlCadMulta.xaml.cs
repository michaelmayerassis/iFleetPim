using ControleMulta.DAO;
using ControleMulta.Models;
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
    /// Interação lógica para UserControlCadMulta.xam
    /// </summary>
    public partial class UserControlCadMulta //: UserControl
    {
        public UserControlCadMulta()
        {
            InitializeComponent();
            gridCadMulta.Visibility = Visibility.Collapsed;
            gbEndereco.Visibility = Visibility.Collapsed;
            MultaDAO multaDAO = new MultaDAO();
            cbPlaca.ItemsSource = multaDAO.Listarbox();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            gridCadMulta.Visibility = Visibility.Visible;
            gbEndereco.Visibility = Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MultaDAO multaDAO = new MultaDAO();
            Multa multa = new Multa
            {
                Cep = txtCEP.Text,
                Cidade = txtCidade.Text,
                Estado = txtEstado.Text,
                Endereco = txtEndereço.Text,
                Gravidade = txtGravidade.Text,
                Data = Convert.ToDateTime(dpData.Text),
                Veiculoid = multaDAO.RetornoID(cbPlaca.Text)
            };
            multaDAO.CadastrarMulta(multa);
            MessageBox.Show("Cadastro efetuado");
        }
    }
}
