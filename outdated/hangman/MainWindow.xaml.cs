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

namespace hangman
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        static Random rnd = new Random();
        Label lbl;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            
            
            for (int i = 0; i < pwb.Password.Length; i++)
            {
                lbl = new Label();
                lbl.Content = "_";
                lbl.Margin = new Thickness(0, 0, 20, 0);
                RegisterName("lbl" + i.ToString(), lbl);
               // lbl.Name = "lbl" + i.ToString();
                stpLabels.Children.Add(lbl);      
            }
          //  pwb.Password = null;
            btnOK.IsEnabled = false;
        }

        private void btnGuess_Click(object sender, RoutedEventArgs e)
        {
            Ellipse ell = new Ellipse();
            ell.Height = ell.Width = 30; ell.Fill = new SolidColorBrush(Colors.Red);
            int x = rnd.Next(30, 170);
            Canvas.SetLeft(ell, x);
            x = rnd.Next(30, 170);
            Canvas.SetTop(ell, x);
            bool match = false;
            string pass = pwb.Password;
            for (int i = 0; i < pwb.Password.Length; i++)
            {
                if (pass[i].ToString().ToUpper() == tbLot.Text.ToUpper())
                {
                    match = true;
                    (win.FindName("lbl" + i.ToString()) as Label).Content = pass[i];
                }
            }
            if (!match)
                canvasHang.Children.Add(ell);                    
        }

        private void win_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
