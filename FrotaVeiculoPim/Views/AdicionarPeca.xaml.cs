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
                EstoqueEntradaDAO estoqueEntrada = new EstoqueEntradaDAO();
                EstoqueEntrada estoque = new EstoqueEntrada();
                estoque.IdPeca = estoqueEntrada.RetornoID(cbNome.Text);
                estoque.Data = DateTime.Now;
                estoque.QtdEstoque = Convert.ToInt32(txtQtdEstoque.Text);
                estoqueEntrada.CadastrarEstoque(estoque);
                peca.AlterarQtd("soma", Convert.ToInt32(txtQtdEstoque.Text), cbNome.Text);
                MessageBox.Show("Adicionado(a): "+ txtQtdEstoque.Text+" !!");
                lblEstoque.Content = ("Em estoque: " + peca.RetornoQtdEstoque("estoque", cbNome.Text));
            }
            else
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

        private void BtnRemover_Click(object sender, RoutedEventArgs e)
        {
            if ((cbNome.Text != "") && (txtQtdEstoque.Text != ""))
            {
                PecaDAO peca = new PecaDAO();
                EstoqueEntradaDAO estoqueEntrada = new EstoqueEntradaDAO();
                EstoqueEntrada estoque = new EstoqueEntrada();
                estoque.IdPeca = estoqueEntrada.RetornoID(cbNome.Text);
                estoque.Data = DateTime.Now;
                estoque.QtdEstoque = Convert.ToInt32(txtQtdEstoque.Text);
                estoqueEntrada.CadastrarEstoque(estoque);
                peca.AlterarQtd("remover", Convert.ToInt32(txtQtdEstoque.Text), cbNome.Text);
                MessageBox.Show("Removido(a): "+ txtQtdEstoque.Text+" !!");
                lblEstoque.Content = ("Em estoque: " + peca.RetornoQtdEstoque("estoque", cbNome.Text));
            }
            else
            {
                MessageBox.Show("Campos nulos, ou incorretos!!");
            }
        }

        private void TxtQtdEstoque_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            Int32 selectionStart = textBox.SelectionStart;
            Int32 selectionLength = textBox.SelectionLength;

            String newText = String.Empty;
            foreach (Char c in textBox.Text.ToCharArray())
            {
                if (Char.IsDigit(c) || Char.IsControl(c)) newText += c;
            }

            textBox.Text = newText;

            textBox.SelectionStart = selectionStart <= textBox.Text.Length ?
                selectionStart : textBox.Text.Length;
        }
    }
}
