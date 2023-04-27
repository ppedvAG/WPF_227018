using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Multitasking
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        public Task<string> TestTask { get; set; } = new Task<string>
            (
            () =>
            {
                Thread.Sleep(3000);

                return "FINISHED";
            }
            );

        private async void Btn_LongTask_Click(object sender, RoutedEventArgs e)
        {
            //Btn_LongTask.IsEnabled = false;
            //Thread.Sleep(3000);
            //Tbl_LongTask.Text = "FINISHED";
            //Btn_LongTask.IsEnabled = true;


            Btn_LongTask.IsEnabled = false;

            //var taskResult = await Task.Run(() =>
            //{
            //    Thread.Sleep(3000);

            //    return "FINISHED";
            //});

            TestTask.Start();
            await TestTask.ContinueWith
                (
                    t =>
                    {
                        Dispatcher.Invoke(() =>
                        {
                            Tbl_LongTask.Text = t.Result;
                            Btn_LongTask.IsEnabled = true;
                        });
                    }
                );


        }

        public int Count { get; set; } = 0;

        private void Btn_ShortTask_Click(object sender, RoutedEventArgs e)
        {
            Count += 1;
            Tbl_ShortTask.Text = Count.ToString();
        }

        private async void Btn_ContinueLongTask_Click(object sender, RoutedEventArgs e)
        {
            Btn_ContinueLongTask.IsEnabled = false;
            await TestTask.ContinueWith
               (
                   t =>
                   {
                       Dispatcher.Invoke(() =>
                       {
                           Tbl_ContinueLongTask.Text = "FERTIG";
                           Btn_ContinueLongTask.IsEnabled = true;
                       });
                   }
               );
        }
    }
}
