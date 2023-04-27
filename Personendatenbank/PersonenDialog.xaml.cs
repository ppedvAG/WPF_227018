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

namespace Personendatenbank
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class PersonenDialog : Window
    {
        public PersonenDialog()
        {
            InitializeComponent();
        }

        private void Btn_Ok_Click(object sender, RoutedEventArgs e)
        {
            Person neuePerson = this.DataContext as Person;

            string ausgabe = neuePerson.Vorname + " " + neuePerson.Nachname + " (" + neuePerson.Geschlecht + ")\n" + neuePerson.Geburtsdatum.ToShortDateString() + "\n" + neuePerson.Lieblingsfarbe.ToString();
            if (neuePerson.Verheiratet) ausgabe = ausgabe + "\nIst verheiratet";
            if (neuePerson.Kinder > 0) ausgabe = ausgabe + $"\nHat {neuePerson.Kinder} {(neuePerson.Kinder == 1 ? "Kind" : "Kinder")}";
            if (MessageBox.Show(ausgabe + "\nAbspeichern?", neuePerson.Vorname + " " + neuePerson.Nachname, MessageBoxButton.YesNo, MessageBoxImage.Information) == MessageBoxResult.Yes)
            {
                this.DialogResult = true;

                this.Close();
            }
        }

        private void Btn_Abbruch_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
