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

namespace Grundlagen
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //Dies verweist auf eine Methode in der (versteckten) automatisch generierten zweiten Klassen-Datei (*.g.i.cs),
            //welche für das Rendering des XAML-Codes verantwortlich ist. InitializeComponent() erstellt die
            //Steuerelement-Objekte und muss daher als erste Methode des Konstruktors bestehen bleiben
            InitializeComponent();

            Btn_KlickMich.Background = new SolidColorBrush(Colors.Blue);
        }

        private void Btn_KlickMich_Click(object sender, RoutedEventArgs e)
        {
            this.Background = new SolidColorBrush(Colors.LightGreen);

            //Verändern des Inhalts des Buttons
            //Btn_KlickMich.Content = "Button wurde geklickt";

            //Ändern einer UI-Property über den Sender-Parameter (beinhaltet den Verursacher des Events)
            (sender as Button).Content = "Button wurde geklickt";
        }
    }
}
