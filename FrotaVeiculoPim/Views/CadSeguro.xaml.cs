using ControleMulta.DAO;
using ModuloSeguro.DAO;
using ModuloSeguro.Models;
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
    /// Lógica interna para CadSeguro.xaml
    /// </summary>
    public partial class CadSeguro //: UserControl
    {
        public CadSeguro()
        {
            InitializeComponent();
            MultaDAO multaDAO = new MultaDAO();
            cbPlaca.ItemsSource = multaDAO.Listarbox();
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            Seguro seguro = new Seguro();
                seguro.Apolice = txtApolice.Text;
                seguro.Plano = txtPlano.Text;
                seguro.Seguradora = txtSeguradora.Text;
                seguro.Validade = Convert.ToDateTime(dpData.Text);
                seguro.Veiculo_id = seguro.RetornoID(cbPlaca.Text);
            SeguroDao seguroDao = new SeguroDao();
            seguroDao.CadastrarSeguro(seguro);
            MessageBox.Show("Cadastrado!");
        }
    }
}
