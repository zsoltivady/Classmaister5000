using Orarend_osszerako.View;
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

namespace Orarend_osszerako
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new LoginPage(); //Alapból a login page-et tölti be
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new LoginPage(); // átvált LoginPage-re a <frame>
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new RegisterPage(); // átvált RegisterPage-re a <frame>
        }
    }
}
