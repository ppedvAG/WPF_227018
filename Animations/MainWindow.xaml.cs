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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Animations
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            InitAnimation();
            sb.Begin(this);

            (this.Resources["BlendStoryboard"] as Storyboard).Begin();
        }

        //Bsp-Daten für Graphen
        List<Point> Points = new List<Point>()
        {
            new Point(100, 200),
            new Point(150, 300),
            new Point(200, 200),
            new Point(400, 220),
            new Point(450, 200),
            new Point(500, 350)
        };

        Storyboard sb;

        //Methode zur Initialisierung des Storyboards/ der Animation
        public void InitAnimation()
        {
            sb = new Storyboard();

            for (int i = 0; i < Points.Count - 1; ++i)
            {
                //new line for current line segment
                var l = new Line();
                l.Stroke = Brushes.Black;
                l.StrokeThickness = 2;

                //data from list
                var startPoint = Points[i];
                var endPoint = Points[i + 1];

                //set startpoint = endpoint will result in the line not being drawn
                l.X1 = startPoint.X;
                l.Y1 = startPoint.Y;
                l.X2 = startPoint.X;
                l.Y2 = startPoint.Y;
                Cvs_Main.Children.Add(l);

                //Initialize the animations with duration of 1 second for each segment
                var daX = new DoubleAnimation(endPoint.X, new Duration(TimeSpan.FromMilliseconds(1000)));
                var daY = new DoubleAnimation(endPoint.Y, new Duration(TimeSpan.FromMilliseconds(1000)));
                //Define the begin time. This is sum of durations of earlier animations + 10 ms delay for each
                daX.BeginTime = TimeSpan.FromMilliseconds(i * 1010);
                daY.BeginTime = TimeSpan.FromMilliseconds(i * 1010);

                sb.Children.Add(daX);
                sb.Children.Add(daY);

                //Set the targets for the animations
                Storyboard.SetTarget(daX, l);
                Storyboard.SetTarget(daY, l);
                Storyboard.SetTargetProperty(daX, new PropertyPath(Line.X2Property));
                Storyboard.SetTargetProperty(daY, new PropertyPath(Line.Y2Property));
            }
        }
    }
}