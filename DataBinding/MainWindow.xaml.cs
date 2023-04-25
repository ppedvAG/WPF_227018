using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace DataBinding
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<Person> Personenliste { get; set; } = new ObservableCollection<Person>()
        {
            new Person(){Name="Anna Nass", Alter=45},
            new Person(){Name="Rainer Zufall", Alter=23},
        };

        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        private void Btn_Show_Click(object sender, RoutedEventArgs e)
        {
            Person person = Spl_DataContextBsp.DataContext as Person;
            MessageBox.Show(person.Name);
        }

        private void Btn_Altern_Click(object sender, RoutedEventArgs e)
        {
            Person person = Spl_DataContextBsp.DataContext as Person;
            person.Alter++;
        }

        private void Btn_Add_Click(object sender, RoutedEventArgs e)
        {
            Personenliste.Add(new Person() { Name = "Hugo Meier", Alter = 12 });
        }

        private void Btn_Delete_Click(object sender, RoutedEventArgs e)
        {
            if(Lbx_Personen.SelectedItem != null)
                Personenliste.Remove(Lbx_Personen.SelectedItem as Person);
        }
    }
}
