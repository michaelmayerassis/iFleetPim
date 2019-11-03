using ControllerMotorista.dao;
using ControllerMotorista.models;
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
    /// Lógica interna para Controle_Motorista.xaml
    /// </summary>
    public partial class Controle_Motorista //: UserControl
    {
        public Controle_Motorista()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnListaMotorista_Click(object sender, RoutedEventArgs e)
        {
            cadMotorista.Visibility = Visibility.Hidden;
            spListaMotorista.Visibility = Visibility.Visible;
            AtualizarGrid();
        }

        private void BtnSalvar_Click(object sender, RoutedEventArgs e)
        {
            string exameMedico;
            if (rbNao.IsChecked == true)
                exameMedico = "NAO";
            else
                exameMedico = "SIM";

            if (verificarCamposNulos())
                MessageBox.Show("Ainda ha campos para serem preenchidos!!", "Alerta!", MessageBoxButton.OK);
            else
            {
                MotoristaDao mdao = new MotoristaDao();
                Motorista motorista = new Motorista()
                {
                    Nome = txtNome.Text,
                    Cpf = txtCpf.Text,
                    Cnh = txtCnh.Text,
                    CategoriaCnh = txtCatCnh.Text,
                    DataNascimento = dtDataNasc.SelectedDate.Value,
                    ExameMedico = exameMedico,
                    Email = txtEmail.Text
                };
                motorista.Endereco = new Endereco();
                motorista.Endereco.Rua = txtRua.Text;
                motorista.Endereco.Bairro = txtBairro.Text;
                motorista.Endereco.Numero = txtNumero.Text;
                motorista.Endereco.Cidade = txtCidade.Text;
                motorista.Endereco.Cep = RetirarTracoCep();

                mdao.InserirMotorista(motorista);
                MessageBox.Show("Motorista inserido com sucesso!!");
            }

        }

        private bool verificarCamposNulos()
        {
            if (txtNome.Text == "" || txtCpf.Text == "" || txtCnh.Text == "" || txtCatCnh.Text == "" || txtRua.Text == "" || txtBairro.Text == "" 
                || txtNumero.Text == "" || txtCidade.Text == "" || txtEmail.Text == "" || txtCep.Text == "")
                return true;
            else
                return false;
        }

        private void limparCampos()
        {
            txtNome.Clear();
            txtCatCnh.Clear();
            txtCpf.Clear();
            txtCnh.Clear();
            txtRua.Clear();
            txtNumero.Clear();
            txtBairro.Clear();
            txtCidade.Clear();
            txtCep.Clear();
            txtEmail.Clear();
            rbNao.IsChecked = null;
            rbSim.IsChecked = null;

        }

        private void TxtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            MotoristaDao mdao = new MotoristaDao();
            dgMotorista.ItemsSource = mdao.BuscarMotorista("%" + txtBuscar.Text + "%");
            AlterarTamanhoColunas();
        }

        private void DgMotorista_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

        }

        private void AlterarTamanhoColunas()
        {
            dgMotorista.Columns[0].Visibility = Visibility.Hidden;
            dgMotorista.Columns[1].Header = "Nome";
            dgMotorista.Columns[2].Header = "CPF";
            dgMotorista.Columns[3].Header = "CNH";
            dgMotorista.Columns[4].Header = "Cat. CNH";
            dgMotorista.Columns[5].Header = "Data de Nascimento";
            dgMotorista.Columns[6].Header = "Exame";
            dgMotorista.Columns[7].Header = "Email";
            dgMotorista.Columns[8].Header = "Endereco";
         
            dgMotorista.Columns[1].Width = 150;
            dgMotorista.Columns[2].Width = 110;
            dgMotorista.Columns[3].Width = 80;
            dgMotorista.Columns[4].Width = 60;
            dgMotorista.Columns[5].Width = 150;
            dgMotorista.Columns[6].Width = 90;
            dgMotorista.Columns[7].Width = 220;
            dgMotorista.Columns[8].Width = 420;
         
        }

        private void AtualizarGrid()
        {
            MotoristaDao mdao = new MotoristaDao();
            dgMotorista.ItemsSource = mdao.ListarMotorista();
            AlterarTamanhoColunas();
        }

        private int RetirarTracoCep()
        {
            int cep =0;

            if (txtCep.Text.Contains("-"))
            {
                cep =  Convert.ToInt32(txtCep.Text.Replace("-", " "));
            }
            return cep;
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            MotoristaDao mdao = new MotoristaDao();
            dgMotorista.ItemsSource = mdao.BuscarMotorista("%" + txtBuscar.Text + "%");
            AlterarTamanhoColunas();
        }

        private void BtnVoltar_Click(object sender, RoutedEventArgs e)
        {
            spListaMotorista.Visibility = Visibility.Hidden;
            cadMotorista.Visibility = Visibility.Visible;
        }

        private void TxtNumero_TextChanged(object sender, TextChangedEventArgs e)
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

        private void TxtCpf_TextChanged(object sender, TextChangedEventArgs e)
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
