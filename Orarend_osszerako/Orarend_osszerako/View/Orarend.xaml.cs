using System.Windows;
using System.Windows.Controls;

namespace Orarend_osszerako.View
{
    /// <summary>
    /// Interaction logic for Orarend.xaml
    /// </summary>
    public partial class Orarend : Page
    {
        public Orarend()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            new TargyHozzaad().Show();
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {
            new KurzusHozzaad().Show();
        }
    }
}
