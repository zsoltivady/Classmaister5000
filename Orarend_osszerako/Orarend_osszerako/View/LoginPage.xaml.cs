using System.Windows;
using System.Windows.Controls;

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

        private void LoginPage_Loaded(object sender, RoutedEventArgs e)
        {
            userName.Focus();
        }
    }
}
