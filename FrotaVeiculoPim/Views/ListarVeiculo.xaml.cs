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
    /// Lógica interna para ListarVeiculo.xaml
    /// </summary>
    public partial class ListarVeiculo : Window
    {
        public ListarVeiculo()
        {
            InitializeComponent();
            
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
    }
}
