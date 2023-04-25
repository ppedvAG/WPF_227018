using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBinding
{
    public class Person : INotifyPropertyChanged
    {
        private int alter;

        public string Name { get; set; }
        public int Alter 
        { 
            get => alter;
            set
            {
                alter = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Alter)));
            }
        }

        public List<DateTime> WichtigeTage { get; set; } = new List<DateTime>()
        {
            DateTime.Now,
            new DateTime(2002, 3, 14),
            new DateTime(2022, 1, 1)
        };

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return $"{Name} ({Alter})";
        }
    }
}
