using System.Windows;
using System.Windows.Controls;

namespace Orarend_osszerako.View
{
    /// <summary>
    /// Interaction logic for RegisterPage.xaml
    /// </summary>
    public partial class RegisterPage : Page
    {
        public RegisterPage()
        {
            InitializeComponent();
        }

        private void RegisterPage_Loaded(object sender, RoutedEventArgs e)
        {
            firstname.Focus();
        }
    }
}
