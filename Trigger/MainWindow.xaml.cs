using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using UserControls;

namespace Trigger
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public bool BoolVal { get; set; }


        public MainWindow()
        {
            InitializeComponent();

            this.BoolVal = true;

            //Setzen des DataContext
            this.DataContext = this;
        }

        //EventHandler zum Ändern der Property
        private void Btn_Ändern_Click(object sender, RoutedEventArgs e)
        {
            BoolVal = !BoolVal;

            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BoolVal)));
        }


        //EventHandler des UserControls (vgl. M11_UserControls)
        private void ColorPicker_Tap(object sender, RoutedEventArgs e)
        {
            MessageBox.Show((sender as ColorPicker).PickedColor.ToString());
        }

        private void ColorPicker_PickedColorChanged(object sender, RoutedEventArgs e)
        {
            if ((sender as ColorPicker).PickedColor.ToString().Equals("#FF000000"))
                MessageBox.Show("Alles ist schwarz");
        }

        //EventHandler des Buttons
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Zugriff auf AttachedProperty
            MessageBox.Show(ColorPicker.GetCount(sender as Button).ToString());
        }
    }
}
