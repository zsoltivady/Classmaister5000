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
using Orarend_osszerako;

namespace Orarend_osszerako.View
{
    /// <summary>
    /// Interaction logic for LoginPage.xaml
    /// </summary>
    public partial class LoginPage : Page
    {
        public LoginPage()
        {
            InitializeComponent();
        }

        //                         Majd a LoginViewModel.cs-ben!!
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            new TimeTableWindow().Show();
            Window.GetWindow(this).Close();
            // TODO Itt kell csekkolni a login adatokat és validálni!!!!!
        }
    }
}
