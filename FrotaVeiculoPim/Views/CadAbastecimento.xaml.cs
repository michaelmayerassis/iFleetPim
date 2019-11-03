using Pim_ControleFrota;
using Pim_ControleFrota.Class_DAO;
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
    /// Lógica interna para CadAbastecimento.xaml
    /// </summary>
    public partial class CadAbastecimento //: UserControl
    {
        public CadAbastecimento()
        {
            InitializeComponent();
            ClassAbastecimentoDAO abastecimentoDAO = new ClassAbastecimentoDAO();
            cbPlaca.ItemsSource = abastecimentoDAO.Listarbox();
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            ClassAbastecimentos abastecimentos = new ClassAbastecimentos
            {
                Combustivel = txtCombustivel.Text,
                KM = Convert.ToDouble(txtKM.Text),
                Quant = Convert.ToDouble(txtQtd.Text),
                Valor_Total = Convert.ToDouble(txtValor.Text.Replace('$', ' ').Replace('.', ','))
        };
            abastecimentos.Codigo_Veiculo = abastecimentos.RetornoID(cbPlaca.Text);
            ClassAbastecimentoDAO abastecimentoDAO = new ClassAbastecimentoDAO();
            abastecimentoDAO.Cadastrar(abastecimentos);
            MessageBox.Show("Cadastrado!");
        }

        private void TxtQtd_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
