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

namespace EventRouting
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Btn_Klick.Click += Btn_Klick_Click_02;
        }

        private void Btn_Klick_Click(object sender, RoutedEventArgs e)
        {
            Tbl_Output.Text += (sender as FrameworkElement).Name + ": Click\n";
        }

        private void Btn_Klick_Click_02(object sender, RoutedEventArgs e)
        {
            (sender as Button).Background = new SolidColorBrush(Colors.HotPink);
        }

        private void Tbx_Input_TextChanged(object sender, TextChangedEventArgs e)
        {
            Tbl_Output.Text += (sender as FrameworkElement).Name + ": TextChanged\n";
        }

        private void Window_Click(object sender, RoutedEventArgs e)
        {
            Tbl_Output.Text += (sender as FrameworkElement).Name + ": ButtonBase.Click\n";

        }

        private void SP_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if ((sender as FrameworkElement).Name == "Aqua")
                Tbl_Output.Text += $"Origin: {(e.OriginalSource as FrameworkElement).Name}\n";
            Tbl_Output.Text += (sender as FrameworkElement).Name + ": Preview/Tunneling\n";
        }

        private void SP_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Tbl_Output.Text += (sender as FrameworkElement).Name + ": Bubbleing\n";

            if ((sender as FrameworkElement).Name == "Gelb")
                e.Handled = true;
        }
    }
}
