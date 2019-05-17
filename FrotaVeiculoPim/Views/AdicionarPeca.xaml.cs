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
    /// Lógica interna para AdicionarPeca.xaml
    /// </summary>
    public partial class AdicionarPeca// : UserControl
    {
        public AdicionarPeca()
        {
            InitializeComponent();
            PecaDAO peca = new PecaDAO();
            cbNome.ItemsSource = peca.Listarbox();
            lblData.Content = Convert.ToString(DateTime.Now);
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if ((cbNome.Text != "") && (txtQtdEstoque.Text != ""))
            {
                PecaDAO peca = new PecaDAO();
                EstoqueEntrada estoque = new EstoqueEntrada();
                estoque.IdPeca = 1;
                estoque.Data = DateTime.Now;
                estoque.QtdEstoque = Convert.ToInt32(txtQtdEstoque.Text);
                EstoqueEntradaDAO estoqueEntrada = new EstoqueEntradaDAO();
                estoqueEntrada.CadastrarEstoque(estoque);
                peca.AlterarQtd("soma", Convert.ToInt32(txtQtdEstoque.Text), cbNome.Text);
                MessageBox.Show("Adicionado!!");
            }else
            {
                MessageBox.Show("Campos nulos, ou incorretos!!");
            }
        }

        private void CbNome_LostFocus(object sender, RoutedEventArgs e)
        {
            PecaDAO peca = new PecaDAO();
            lblEstoque.Content = ("Em estoque: " + peca.RetornoQtdEstoque("estoque", cbNome.Text));
            lblQtdMin.Content = ("Estoque minímo: " + peca.RetornoQtdEstoque("", cbNome.Text));
        }
    }
}
