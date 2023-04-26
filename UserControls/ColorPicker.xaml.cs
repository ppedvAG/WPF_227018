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
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UserControls
{
    /// <summary>
    /// Interaction logic for UserControl1.xaml
    /// </summary>
    //Das ContentProperty-Attribut definiert eine Eigenschaft als neue Content-Property (vgl. auch M10_Trigger)
    [ContentProperty("MyContent")]
    public partial class ColorPicker : UserControl
    {

        public ColorPicker()
        {
            InitializeComponent();

            //EventRaising durch MouseDown-Event des TextBlocks
            Tbl_Output.PreviewMouseDown += (s, e) => RaiseTapEvent(this);

            //Erstellen einer neuen Bindung (Fill-Eigenschaft des Rechtecks an PickedColor-Eigenschaft)
            //Initialisierung mit Übergabe der zu bindenden Quell-Eigenschaft
            Binding binding = new Binding("Fill");
            //Setzen des Quell-Objekts
            binding.Source = Rct_Output;
            //Setzen des Bindings-Modes
            binding.Mode = BindingMode.OneWay;

            //Erstellen der Bindung mit Übergabe des Ziel-Objekts, der Ziel-Eigenschaft und des Bindungs-Elements
            BindingOperations.SetBinding(this, PickedColorProperty, binding);
        }

        //Damit der Control eine Ausgabe hat, an welche die User andere Properties binden können muss für jede dieser Ausgaben eine DependencyProperty
        //erstellt werden, welche im Konstruktor des UserControlls manuell an die entsprechnende Property eines Teilelements gebunden wird.
        //DependencyProperties sind spezielle WPF-Element-Properties, welche nicht in den Objekten selbst gespeichert werden. Stattdessen werden diese
        //in einer eigenen Liste abgelegt. Durch diese Mechanik werden Bindungen und Co in WPF erst möglich.

        //Getter/Setter der DependencyProperty
        public SolidColorBrush PickedColor
        {
            get { return (SolidColorBrush)GetValue(PickedColorProperty); }
            set { SetValue(PickedColorProperty, value); }
        }

        //Registrierung für neue Bindungen an der DependencyProperty
        public static readonly DependencyProperty PickedColorProperty =
            DependencyProperty.Register
            (
                "PickedColor",
                typeof(SolidColorBrush),
                typeof(ColorPicker),
                new PropertyMetadata
                (
                    //Standartwert der DP
                    default(SolidColorBrush),
                    //Methode, welche nach der Wertveränderung aufgerufen wird (PropertyChangedCallback), hier wird das PropertyChangedEvent ausgelöst
                    (s, e) => (s as UIElement)?.RaiseEvent(new RoutedPropertyChangedEventArgs<SolidColorBrush>(e.OldValue as SolidColorBrush, e.NewValue as SolidColorBrush, PickedColorChangedEvent)),
                    //Methode, welche vor der Wertveränderung aufgerufen wird (CoerceValueCallback)
                    (dpo, value) => { return (dpo as ColorPicker).Sdr_Alpha.Value == 150 ? new SolidColorBrush(Colors.Red) : value; }
                )
            );


        //PickedColorChangedEvent
        public event RoutedPropertyChangedEventHandler<SolidColorBrush> PickedColorChanged
        {
            add { AddHandler(PickedColorChangedEvent, value); }
            remove { RemoveHandler(PickedColorChangedEvent, value); }
        }

        public static readonly RoutedEvent PickedColorChangedEvent = EventManager.RegisterRoutedEvent("PickedColorChanged", RoutingStrategy.Direct, typeof(RoutedPropertyChangedEventHandler<SolidColorBrush>), typeof(ColorPicker));

        //ShowRectangleProperty
        public Boolean ShowRectangle
        {
            get { return (Boolean)GetValue(ShowRectangleProperty); }
            set { SetValue(ShowRectangleProperty, value); }
        }

        // Using a DependencyProperty as the backing store for ShowRectangle.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ShowRectangleProperty =
            DependencyProperty.Register("ShowRectangle", typeof(Boolean), typeof(ColorPicker), new PropertyMetadata((bool)false));



        //CustomEvent
        public static readonly RoutedEvent TapEvent = EventManager.RegisterRoutedEvent("Tap", RoutingStrategy.Direct, typeof(RoutedEventHandler), typeof(ColorPicker));

        //Handleranmeldung
        public event RoutedEventHandler Tap
        {
            add { AddHandler(TapEvent, value); }
            remove { RemoveHandler(TapEvent, value); }
        }

        //Methode zum Feuern des Eventhandlers
        void RaiseTapEvent(object source)
        {
            RoutedEventArgs newEventArgs = new RoutedEventArgs(ColorPicker.TapEvent, source);
            RaiseEvent(newEventArgs);
        }



        //AttachedProperty (Eigenschaft, welche an Elemente im Content verteilt wird - Zugriff erfolgt über ColorPicker.Count in den Content-Objekten)
        public static int GetCount(DependencyObject obj)
        {
            return (int)obj.GetValue(CountProperty);
        }

        public static void SetCount(DependencyObject obj, int value)
        {
            obj.SetValue(CountProperty, value);
        }

        public static readonly DependencyProperty CountProperty =
            DependencyProperty.RegisterAttached("Count", typeof(int), typeof(ColorPicker), new PropertyMetadata(0));


        //Property, welche als Content benutzt werden soll (vgl. Attribut über Klassensignatur)
        public object MyContent
        {
            get { return (object)GetValue(MyContentProperty); }
            set { SetValue(MyContentProperty, value); }
        }

        public static readonly DependencyProperty MyContentProperty =
            DependencyProperty.Register("MyContent", typeof(object), typeof(ColorPicker), new PropertyMetadata(null));


    }
}