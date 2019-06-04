using ControleDePecas.DAO;
using ControleDePecas.Models;
using ControleManutencao;
using ControleManutencao.DAO;
using ControleManutencao.Models;
using ControleMulta.DAO;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Lógica interna para CadManutencao.xaml
    /// </summary>
    public partial class CadManutencao //: UserControl
    {
        private Peca1 peca1;
        private PecaDAO pecaDAO;
        private PecaDAO1 pecaDAO1;
        public CadManutencao()
        {
            InitializeComponent();
            peca1 = new Peca1();
            pecaDAO = new PecaDAO();
            pecaDAO1 = new PecaDAO1();
        }

        private void BtnCadManutencao_Click(object sender, RoutedEventArgs e)
        {
            tbTitulo.Text = "CADASTRAR MANUTENÇÃO";
            spInManutencao.Visibility = Visibility.Hidden;
            spCadManutencao.Visibility = Visibility.Visible;
            MultaDAO multaDAO = new MultaDAO();
            cbPlacaManutencao.ItemsSource = multaDAO.Listarbox();
        }

        private void BtnFinalizar_Click(object sender, RoutedEventArgs e)
        {
            tbTitulo.Text = "FINALIZAR MANUTENÇÃO";
            spInManutencao.Visibility = Visibility.Hidden;
            spFinalizarManutencao.Visibility = Visibility.Visible;
            cbPeca.ItemsSource = pecaDAO.Listarbox();
            MultaDAO multaDAO = new MultaDAO();
            cbPlaca.ItemsSource = multaDAO.Listarbox();
        }

        private void BtnConsultar_Click(object sender, RoutedEventArgs e)
        {
            tbTitulo.Text = "VEICULOS EM MANUTENÇÃO";
            spInManutencao.Visibility = Visibility.Hidden;
            spListarVeiculos.Visibility = Visibility.Visible;
        }

        private void BtnVoltarSaindo_Click(object sender, RoutedEventArgs e)
        {
            tbTitulo.Text = "MANUTENÇÃO";
            spInManutencao.Visibility = Visibility.Visible;
            spCadManutencao.Visibility = Visibility.Hidden;
        }

        private void BtnVoltarSaindo1_Click(object sender, RoutedEventArgs e)
        {
            tbTitulo.Text = "MANUTENÇÃO";
            spInManutencao.Visibility = Visibility.Visible;
            spFinalizarManutencao.Visibility = Visibility.Hidden;
        }

        private void BtnVoltar_Click(object sender, RoutedEventArgs e)
        {
            tbTitulo.Text = "MANUTENÇÃO";
            spInManutencao.Visibility = Visibility.Visible;
            spListarVeiculos.Visibility = Visibility.Hidden;
        }

        private void BtnAdicionar_Click(object sender, RoutedEventArgs e)
        {
            Peca1 p = new Peca1
            {
                peca = cbPeca.Text,
                Quantidade = Convert.ToInt32(txtQtd.Text)
            };
            pecaDAO1.Adicionar(p);
            dgPeca.ItemsSource = "";
            dgPeca.ItemsSource = pecaDAO1.Pecas;
        }

        private void BtnDeletar_Click(object sender, RoutedEventArgs e)
        {
            Peca1 peca = new Peca1();
            peca = dgPeca.SelectedItem as Peca1;
            pecaDAO1.Pecas.Remove(peca);
            dgPeca.ItemsSource = "";
            dgPeca.ItemsSource = pecaDAO1.Pecas;
        }

        private void BtnSalvarFim_Click(object sender, RoutedEventArgs e)
        {
            FinalizarManutencao finalizar = new FinalizarManutencao();
            FinalizarManutencaoDAO manutencaoDAO = new FinalizarManutencaoDAO();
            finalizar.Data = DateTime.Now;
            finalizar.Obs = txtDescricao1.Text;
            finalizar.Valor = Convert.ToDecimal(txtValor.Text.Replace('$', ' ').Replace('.', ','));
            //pegar id da manutenção e retornar abaixo.... fazer
            finalizar.Manutencao_Id = 6;
            manutencaoDAO.FinalizarManutencao(finalizar);
            EstoqueSaidaDAO estoqueSaida = new EstoqueSaidaDAO();
            EstoqueSaida saida = new EstoqueSaida();
                foreach (Peca1 p in pecaDAO1.Pecas)
                { 
                    saida.Data = DateTime.Now;
                //pegar id da ordem de serviço e retornar abaixo.... fazer
                saida.IdOrdemServico = 1;
                    saida.QtdEstoque = p.Quantidade;
                    saida.IdPeca = saida.RetornoID(p.peca);
                    estoqueSaida.CadastrarEstoque(saida);
                }
            MessageBox.Show("Finalização cadastrada!");
        }

        private void BtnCadastrar_Click_1(object sender, RoutedEventArgs e)
        {
            if ((txtDescricao.Text == "") || (cbPlacaManutencao.Text == "") || (dpData.Text == ""))
            {
                MessageBox.Show("há campos vazios ou incorretos!");
            }
            else
            {
                ManutencaoDAO manutencaoDAO = new ManutencaoDAO();
                Manutencao manutencao = new Manutencao();
                manutencao.Data = DateTime.Now;
                manutencao.Descricao = txtDescricao.Text;
                manutencao.DataPrevista = Convert.ToDateTime(dpData.Text);
                manutencao.Veiculo_Id = manutencaoDAO.RetornoID(cbPlacaManutencao.Text);
                manutencaoDAO.CadastrarManutencao(manutencao);
                MessageBox.Show("Cadastrado!");
            }
        }
    }
}
