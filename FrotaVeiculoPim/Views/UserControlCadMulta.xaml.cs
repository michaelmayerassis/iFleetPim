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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            gridCadMulta.Visibility = Visibility.Visible;
            gbEndereco.Visibility = Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            MultaDAO multaDAO = new MultaDAO();
            Multa multa = new Multa();
            Multas();
            multaDAO.CadastrarMulta(multa);
            MessageBox.Show("Cadastro efetuado");
        }

        private void Multas ()
        {
            Multa multa = new Multa();
            multa.Cep = txtCEP.Text;
            multa.Cidade = txtCidade.Text;
            multa.Estado = txtEstado.Text;
            multa.Endereco = txtEndereço.Text;
            multa.Gravidade = txtGravidade.Text;
            multa.Data = Convert.ToDateTime(dpData.Text);
            multa.Veiculoid = 1;
        }
    }
}
