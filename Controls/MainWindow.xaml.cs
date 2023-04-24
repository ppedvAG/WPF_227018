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

namespace Controls
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_KlickMich_Click(object sender, RoutedEventArgs e)
        {
            //(sender as Button).Content = "Wurde geklickt";
            (sender as Button).Content = Sdr_Wert.Value;

            Tbl_Output.Text = Tbx_Input.Text;

            if (Cbx_Haken.IsChecked == true) 
                Lbl_Output.Content = (Cbb_Auswahl.SelectedItem as ComboBoxItem)?.Content;
        }

        private void Schließen_Click(object sender, RoutedEventArgs e)
        {
            if(MessageBox.Show(
                "Möchtest du das Programm beenden?", 
                "Schließen", 
                MessageBoxButton.YesNo, 
                MessageBoxImage.Warning) == MessageBoxResult.Yes)

                this.Close();
        }

        private void Fenster_Click(object sender, RoutedEventArgs e)
        {
            Window wnd = new MainWindow();

            wnd.Title = "2. Fenster";

            wnd.Show();
        }

        private void Dialog_Click(object sender, RoutedEventArgs e)
        {
            Window wnd = new MainWindow();

            wnd.Title = "Dialog-Fenster";

            if (wnd.ShowDialog() == true) Lbl_Output.Content = "OKAY :-)";
        }

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            this.Close();
        }
    }
}
