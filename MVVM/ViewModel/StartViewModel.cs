using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM.ViewModel
{
    internal class StartViewModel : INotifyPropertyChanged
    {
        public CustomCommand LadeDbCmd { get; set; }
        public CustomCommand ÖffneDbCmd { get; set; }

        public int AnzahlPersonen { get { return Model.Person.Personenliste.Count; } }


        public StartViewModel()
        {
            LadeDbCmd = new CustomCommand
                (
                    p =>
                    {
                        Model.Person.LadePersonenAusDb();
                        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(AnzahlPersonen)));
                    },
                    p => AnzahlPersonen == 0
                );

            ÖffneDbCmd = new CustomCommand
                (
                    p =>
                    {
                        //TODO: Nächstes Fenster öffnen

                        (p as Window).Close();
                    },
                    p => AnzahlPersonen > 0
                );
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
