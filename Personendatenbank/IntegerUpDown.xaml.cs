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
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    public partial class IntegerUpDown : UserControl
    {
        public IntegerUpDown()
        {
            InitializeComponent();
        }

        public int Value
        {
            get { return (int)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        // Using a DependencyProperty as the backing store for Value.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register("Value", typeof(int), typeof(IntegerUpDown), new PropertyMetadata(default(int)));

        private void Btn_Up_Click(object sender, RoutedEventArgs e)
        {
            this.Value++;
        }

        private void Btn_Down_Click(object sender, RoutedEventArgs e)
        {
            this.Value--;
        }

        private void Uc_IntUpDown_PreviewKeyUp(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Up:
                    Btn_Up_Click(sender, e);
                    break;
                case Key.Down:
                    Btn_Down_Click(sender, e);
                    break;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if ((sender as TextBox).Text.Any(x => !Char.IsDigit(x)))
                (sender as TextBox).GetBindingExpression(TextBox.TextProperty).UpdateTarget();
        }
    }
}