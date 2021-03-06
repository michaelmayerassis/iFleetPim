﻿using ControleDePecas.DAO;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FrotaVeiculoPim.Views
{
    /// <summary>
    /// Lógica interna para CadPeca.xaml
    /// </summary>
    public partial class CadPeca// : UserControl
    {
        private Peca peca;
        private readonly PecaDAO pecaDAO;
        public CadPeca()
        {   
            InitializeComponent();
            peca = new Peca();
            pecaDAO = new PecaDAO();
        }

        private void BtnCadastrar_Click(object sender, RoutedEventArgs e)
        {
            if (pecaDAO.RetornarNomePeca(txtNome.Text))
            {
                MessageBox.Show("Essa peça já está cadastrada!");
            }else if ((txtNome.Text == ""))
            {
                MessageBox.Show("É obrigatório preencher o campo nome para proseguir com o cadastro!");
            }
            else
            {
                if ((txtPrateleira.Text == "") || (txtQtdMin.Text == "") || (txtDescricao.Text == ""))
                {
                    if (MessageBox.Show("Há campos em branco, prosseguir com cadastro mesmo assim?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                            Pecas();
                        pecaDAO.CadastrarPeca(peca, "cadastrar");
                        if (MessageBox.Show("Cadastro realizado com sucesso, deseja movimentar estoque ?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        {
                            AdicionarPeca adicionarPeca = new AdicionarPeca();
                            MainWindow mainWindow = new MainWindow();
                            mainWindow.Show();
                            mainWindow.imgFundo.Visibility = Visibility.Collapsed;
                            mainWindow.ButtonCloseMenu.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                            mainWindow.GridPrincipal.Children.Add(adicionarPeca);
                            adicionarPeca.cbNome.Text = txtNome.Text;
                           //adicionarPeca.txtQtdEstoque.Focus();
                        }
                        else
                        {
                            Limpar();
                        }
                    }
                }else
                {
                    Pecas();
                    pecaDAO.CadastrarPeca(peca, "cadastrar");
                    if (MessageBox.Show("Cadastro realizado com sucesso, deseja movimentar estoque ?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        AdicionarPeca adicionarPeca = new AdicionarPeca();
                        MainWindow mainWindow = new MainWindow();
                        mainWindow.Show();
                        mainWindow.imgFundo.Visibility = Visibility.Collapsed;
                        mainWindow.ButtonCloseMenu.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                        mainWindow.GridPrincipal.Children.Add(adicionarPeca);
                        adicionarPeca.cbNome.Text = txtNome.Text;
                        //adicionarPeca.txtQtdEstoque.Focus();
                    }
                    else
                    {
                        Limpar();
                    }
                }
            }
        }

        internal void ShowDialog()
        {
            throw new NotImplementedException();
        }

        private void OnKeyDownHandler(object sender, KeyEventArgs e)
        {
        if ((e.Key == Key.Enter)&&(txtNome.Text!=""))
             {
                txtPrateleira.Focus();
            }
        }

        private void TxtValor_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Enter) && (txtValor.Text != ""))
            {
                txtQtdMin.Focus();
            }
        }

        private void TxtPrateleira_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Key == Key.Enter) && (txtPrateleira.Text != ""))
            {
                txtValor.Focus();
            }
        }

        private void BtnListarPeca_Click(object sender, RoutedEventArgs e)
        {
            cadPeca.Visibility = Visibility.Collapsed;
            spListar.Visibility = Visibility.Visible;
            txtTitulo.Text = "LISTAR PEÇAS";
            btnVoltar.Visibility = Visibility.Visible;
            dgListar.ItemsSource = pecaDAO.ListarPeca();
        }

        private void Pecas()
        {
            peca.Nome = txtNome.Text;
            peca.Pratileira = txtPrateleira.Text;
            peca.Valor = Convert.ToDecimal(txtValor.Text.Replace('$', ' ').Replace('.', ','));
            if (txtQtdMin.Text == "")
            {
                peca.QtdMin = 0;
            }
            else
            {
                peca.QtdMin = Convert.ToInt32(txtQtdMin.Text);
            }
                peca.Descricao = txtDescricao.Text;
        }

        private void Limpar()
        {
            txtNome.Text = "";
            txtPrateleira.Text = "";
            txtQtdMin.Text = "";
            txtValor.Text = "$0.00";
            txtDescricao.Text = "";
        }

        private void BtnVoltar_Click(object sender, RoutedEventArgs e)
        {
            txtTitulo.Text = "PEÇA";
            dgListar.Visibility = Visibility.Collapsed;
            cadPeca.Visibility = Visibility.Visible;
            btnVoltar.Visibility = Visibility.Collapsed;
        }

        private void DgListar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            spListar.Visibility = Visibility.Collapsed;
            cadPeca.Visibility = Visibility.Visible;
            btnVoltar.Visibility = Visibility.Collapsed;
            btnCadastrar.Visibility = Visibility.Collapsed;
            btnAltera.Visibility = Visibility.Visible;
            peca = dgListar.SelectedItem as Peca;
            txtNome.Text = peca.Nome.ToString();
            txtPrateleira.Text = peca.Pratileira;
            txtValor.Number = peca.Valor;
            txtQtdMin.Text = peca.QtdMin.ToString();
            txtDescricao.Text = peca.Descricao;
        }

        private void BtnAltera_Click(object sender, RoutedEventArgs e)
        {
            if (txtNome.Text == "")
            {
                MessageBox.Show("É obrigatório preencher o campo nome para proseguir com o cadastro!");
            }
            else
            {
                if ((txtPrateleira.Text == "") || (txtQtdMin.Text == "") || (txtDescricao.Text == ""))
                {
                    if (MessageBox.Show("Há campos em branco, prosseguir com cadastro mesmo assim?", "", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                    {
                        Pecas();
                        pecaDAO.CadastrarPeca(peca, "alterar");
                        MessageBox.Show("Cadastro alterado com sucesso!");
                    }
                }else
                {
                    Pecas();
                    pecaDAO.CadastrarPeca(peca, "alterar");
                    MessageBox.Show("Cadastro alterado com sucesso!");
                }
            }
            Limpar();
            btnAltera.Visibility = Visibility.Collapsed;
            btnCadastrar.Visibility = Visibility.Visible;
        }

        private void DgListar_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dgListar.Columns[1].Visibility = Visibility.Collapsed;
            dgListar.Columns[4].Header = "Quantidade em estoque";
            dgListar.Columns[5].Header = "Quantidade miníma";
            dgListar.Columns[6].Header = "Valor unitário";
            dgListar.Columns[2].Visibility = Visibility.Collapsed;
            dgListar.Columns[0].Width = 350;
            dgListar.Columns[3].Width = 200;
            dgListar.Columns[4].Width = 200;
            dgListar.Columns[5].Width = 200;
            dgListar.Columns[6].Width = 200;
        }

        private void TxtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            dgListar.ItemsSource = pecaDAO.BuscarPeca("%" + txtBuscar.Text + "%");
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            dgListar.ItemsSource = pecaDAO.BuscarPeca("%" + txtBuscar.Text + "%");
        }

        private void TxtQtdMin_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            Int32 selectionStart = textBox.SelectionStart;

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
