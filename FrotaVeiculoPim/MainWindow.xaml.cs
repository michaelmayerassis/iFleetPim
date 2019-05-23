using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using FrotaVeiculoPim.Views;

namespace FrotaVeiculoPim
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void ButtonOpenMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Visible;
            ButtonOpenMenu.Visibility = Visibility.Collapsed;
        }

        private void ButtonCloseMenu_Click(object sender, RoutedEventArgs e)
        {
            ButtonCloseMenu.Visibility = Visibility.Collapsed;
            ButtonOpenMenu.Visibility = Visibility.Visible;
            
        }

        private void ButtonCloseApplication_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UserControl usc = null;
            GridPrincipal.Children.Clear();

            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "Principal":
                    if (ButtonCloseMenu.Visibility == Visibility.Visible)
                    {
                        ButtonCloseMenu.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    }
                    imgFundo.Visibility = Visibility.Visible;
                    break;
                case "cadVeiculo":
                    usc = new UserControlCadVeiculo();
                    imgFundo.Visibility = Visibility.Collapsed;
                    if (ButtonCloseMenu.Visibility == Visibility.Visible)
                    {
                        ButtonCloseMenu.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    }
                    GridPrincipal.Children.Add(usc);
                    break;
                case "cadMultas":
                    usc = new UserControlCadMulta();
                    imgFundo.Visibility = Visibility.Collapsed;
                    if (ButtonCloseMenu.Visibility == Visibility.Visible)
                    {
                        ButtonCloseMenu.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    }
                    GridPrincipal.Children.Add(usc);
                    break;
                case "cadViagem":
                    usc = new UserControlCadViagem();
                    imgFundo.Visibility = Visibility.Collapsed;
                    if (ButtonCloseMenu.Visibility == Visibility.Visible)
                    {
                        ButtonCloseMenu.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    }
                    GridPrincipal.Children.Add(usc);
                    break;
                case "cadPecas":
                    usc = new CadPeca();
                    imgFundo.Visibility = Visibility.Collapsed;
                    if (ButtonCloseMenu.Visibility == Visibility.Visible)
                    {
                        ButtonCloseMenu.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    }
                    GridPrincipal.Children.Add(usc);
                    break;
                case "cadMovimento":
                    usc = new AdicionarPeca();
                    imgFundo.Visibility = Visibility.Collapsed;
                    if (ButtonCloseMenu.Visibility == Visibility.Visible)
                    {
                        ButtonCloseMenu.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    }
                    GridPrincipal.Children.Add(usc);
                    break;
                case "cadManutencao":
                    usc = new CadManutencao();
                    imgFundo.Visibility = Visibility.Collapsed;
                    if (ButtonCloseMenu.Visibility == Visibility.Visible)
                    {
                        ButtonCloseMenu.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    }
                    GridPrincipal.Children.Add(usc);
                    break;
                case "cadSeguro":
                   // usc = new CadSeguro();
                    imgFundo.Visibility = Visibility.Collapsed;
                    if (ButtonCloseMenu.Visibility == Visibility.Visible)
                    {
                        ButtonCloseMenu.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    }
                    GridPrincipal.Children.Add(usc);
                    break;
                case "cadMotorista":
                    usc = new Controle_Motorista();
                    imgFundo.Visibility = Visibility.Collapsed;
                    if (ButtonCloseMenu.Visibility == Visibility.Visible)
                    {
                        ButtonCloseMenu.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
                    }
                    GridPrincipal.Children.Add(usc);
                    break;
            }
        }

        private void BtnFecharAplicacao_MouseLeave(object sender, MouseEventArgs e)
        {
            btnFecharAplicacao.Background = Brushes.Transparent;
        }

        private void BtnFecharAplicacao_MouseEnter(object sender, MouseEventArgs e)
        {
            btnFecharAplicacao.Background = Brushes.Red;
        }

        private void BtnFecharAplicacao_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Deseja realmente sair?", "Saindo...", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                Application.Current.Shutdown();
        }

        private void ListView_SelectionChanged_1(object sender, SelectionChangedEventArgs e)
        {
            switch (((ListViewItem)((ListView)sender).SelectedItem).Name)
            {
                case "CloseApplication":
                    if (MessageBox.Show("Deseja realmente sair?", "Saindo...", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                        Application.Current.Shutdown();
                    break;
            }
        }

        private void ListViewItem_Selected(object sender, RoutedEventArgs e)
        {

        }

        private void CloseApplication_MouseLeave(object sender, MouseEventArgs e)
        {
            CloseApplication.Background = Brushes.Transparent;
        }

        private void CloseApplication_MouseEnter(object sender, MouseEventArgs e)
        {
            CloseApplication.Background = Brushes.Red;
        }
    }
}
