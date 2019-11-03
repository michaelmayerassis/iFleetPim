using ControllerMotorista.models;
using ControllerMotorista.dao;
using ModViagem.DAO;
using ModViagem.models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

//using ModViagem.DAO;
//using ModViagem.models;

namespace FrotaVeiculoPim.Views
{
    /// <summary>
    /// Interação lógica para UserControlCadViagem.xam
    /// </summary>
    public partial class UserControlCadViagem : UserControl
    {
        static int IdViagem;
        private String titulo = "Viagens".ToUpper();
        private String tituloChegando = "Entrada de veículo".ToUpper();
        private String tituloSaindo = "Saida de veículo".ToUpper();
        private String tituloListagem = "Veículos em viagem".ToUpper();
        ClassVeiculoDAO veiculoDao;
        MotoristaDao motoristaDao;
        public UserControlCadViagem()
        {
            InitializeComponent();
            veiculoDao = new ClassVeiculoDAO();
            motoristaDao = new MotoristaDao();
            cbPlaca.ItemsSource = veiculoDao.ListarVeiculo();
            cbNomeMotorista.ItemsSource = motoristaDao.ListarMotorista();
           
        }


        private void CbVeiculoMulta_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            //gridCadViagem.Visibility = Visibility.Visible;
        }

        private void BtnChegadaVeiculo_Click(object sender, RoutedEventArgs e)
        {
            tbTitulo.Text = tituloChegando;
            spInicioViagem.Visibility = Visibility.Hidden;
            spListarViagem.Visibility = Visibility.Visible;
            AtualizarGrid();

        }

        private void BtnSaidaVeiculo_Click(object sender, RoutedEventArgs e)
        {
            tbTitulo.Text = tituloSaindo;
            spInicioViagem.Visibility = Visibility.Hidden;
            spCarroSaindo.Visibility = Visibility.Visible;
            
            dtDataSaida.DisplayDate = DateTime.Now;
           
        }

        private void BtnConsultarViagem_Click(object sender, RoutedEventArgs e)
        {
            tbTitulo.Text = tituloListagem;
            spInicioViagem.Visibility = Visibility.Hidden;
            spListarViagem.Visibility = Visibility.Visible;
            AtualizarGrid();

        }


        private void BtnVoltar_Click(object sender, RoutedEventArgs e)
        {
            tbTitulo.Text = titulo;
            spListarViagem.Visibility = Visibility.Hidden;
            spInicioViagem.Visibility = Visibility.Visible;

        }

        private void BtnVoltarChegando_Click(object sender, RoutedEventArgs e)
        {
            tbTitulo.Text = titulo;
            spInicioViagem.Visibility = Visibility.Visible;
            spCarroChegando.Visibility = Visibility.Hidden;

        }

        private void BtnVoltarSaindo_Click(object sender, RoutedEventArgs e)
        {
            tbTitulo.Text = titulo;
            spInicioViagem.Visibility = Visibility.Visible;
            spCarroSaindo.Visibility = Visibility.Hidden;
        }

        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            ViagemDao vdao = new ViagemDao();
            dgViagem.ItemsSource = vdao.BuscarViagem("%" + txtBuscar.Text + "%");
        }

        private void TxtBuscar_TextChanged(object sender, TextChangedEventArgs e)
        {
            ViagemDao vdao = new ViagemDao();
            dgViagem.ItemsSource = vdao.BuscarViagem("%" + txtBuscar.Text + "%");
        }

        private void BtnSalvarViagem_Click(object sender, RoutedEventArgs e)
        {
            if (VerificarCamposNulos())
            {
                MessageBox.Show("Ainda ha campos para serem preenchidos", "Aviso", MessageBoxButton.OK);
            }
            else
            {
                ViagemDao viagemDao = new ViagemDao();
                int idMotorista = viagemDao.PegarIdMotorista(cbNomeMotorista.Text);
                if (idMotorista < 0 || idMotorista == 0)
                {
                    MessageBox.Show("Motorista não encontrado no sistema, tente novamente!", "Aviso", MessageBoxButton.OK);
                }
                else
                {
                    if (viagemDao.RetornarPlacasEmViagem(cbPlaca.Text))
                    {
                        MessageBox.Show("O carro ja esta em viagem!");
                    }
                    else
                    {
                        Viagem viagem = new Viagem()
                        {
                            DataSaida = dtDataSaida.SelectedDate.Value,
                            KmSaida = Convert.ToDecimal(txtQuilometroSaida.Text),
                            Local = txtLocalViagem.Text,
                            Situacao = "Em viagem"
                        };
                        viagem.Motorista = new Motorista();
                        viagem.Motorista.IdMotorista = idMotorista;


                        viagemDao.InserirViagem(viagem);
                        viagemDao.InserirViagemVeiculo(cbPlaca.Text);
                        MessageBox.Show("Viagem cadastrada com sucesso!", "", MessageBoxButton.OK);
                        LimparCampos();
                        spCarroSaindo.Visibility = Visibility.Hidden;
                        spListarViagem.Visibility = Visibility.Visible;
                        AtualizarGrid();
                    }
                }
            }
        }

        private void BtnSalvarChegando_Click(object sender, RoutedEventArgs e)
        {
            if (txtQuilometroChegada.Text == "" || dtEntrada.Text == "")
            {
                MessageBox.Show("Ainda ha campos para serem preenchidos", "Aviso", MessageBoxButton.OK);
            }
            else
            {
                Viagem viagem = new Viagem()
                {

                    DataEntrada = DateTime.Now,
                    KmEntrada = Convert.ToDecimal(txtQuilometroChegada.Text),
                    Situacao = "Disponível",
                    IdViagem = IdViagem,
                };
                
                ViagemDao viagemDao = new ViagemDao();
                if (viagemDao.AlterarViagem(viagem))
                {
                    MessageBox.Show("Viagem alterada com sucesso!!", "", MessageBoxButton.OK);
                    spCarroChegando.Visibility = Visibility.Hidden;
                    spListarViagem.Visibility = Visibility.Visible;
                    AtualizarGrid();
                }
                else
                    MessageBox.Show("Ocorreu um erro ao alterar sua viagem, contacte o adminsitrador do sistema", "", MessageBoxButton.OK);
            }


        }

        private void DgViagem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            spListarViagem.Visibility = Visibility.Hidden;
            spCarroChegando.Visibility = Visibility.Visible;
            Viagem viagem = new Viagem();
            viagem = dgViagem.SelectedItem as Viagem;
            txtCpfMotoristaCh.Text = viagem.Motorista.Nome;
            txtPlacaCh.Text = viagem.Veiculo.Placa;
            txtLocalViagemCh.Text = viagem.Local;
            txtQuilometroChegada.Text = viagem.KmEntrada.ToString();
            dtEntrada.DisplayDate = DateTime.Now;
            IdViagem = viagem.IdViagem;
        }

        private void LimparCampos()
        {
           
            txtCpfMotoristaCh.Clear();
            txtLocalViagem.Clear();
            txtLocalViagemCh.Clear();
            txtQuilometroChegada.Clear();
            txtQuilometroSaida.Clear();
            //cbPlaca.Clear();
            txtPlacaCh.Clear();
            dtDataSaida.DisplayDate = DateTime.Now;
            dtEntrada.DisplayDate = DateTime.Now;

        }

        //SOMENTE PARA A FUNCIONALIDE DO CARRO ESTAR SAINDO DA EMPRESA
        private bool VerificarCamposNulos()
        {
            if (cbNomeMotorista.Text == "" || txtLocalViagem.Text == "" || txtQuilometroSaida.Text == "" || cbPlaca.Text == "")
            {
                return true;
            }
            else { return false; }
        }

        private void AtualizarGrid()
        {
            ViagemDao vdao = new ViagemDao();
            dgViagem.ItemsSource = vdao.ListarTodasViagens();
        }

        private void DgViagem_AutoGeneratedColumns(object sender, EventArgs e)
        {
            dgViagem.Columns[0].Visibility = Visibility.Collapsed;
            dgViagem.Columns[1].Header = "Data de Entrada";
            dgViagem.Columns[2].Header = "Veículo";
            dgViagem.Columns[3].Header = "Motorista";
            dgViagem.Columns[4].Header = "Data de Saída";
            dgViagem.Columns[5].Header = "Local";
            dgViagem.Columns[6].Header = "Km Entrada";
            dgViagem.Columns[7].Header = "Km Saída";
            dgViagem.Columns[8].Header = "Situação";
            dgViagem.Columns[1].Width = 150;
            dgViagem.Columns[2].Width = 150;
            dgViagem.Columns[3].Width = 200;
            dgViagem.Columns[4].Width = 150;
        }
    }
}
