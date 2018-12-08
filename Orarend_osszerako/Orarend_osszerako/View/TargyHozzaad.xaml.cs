using System.Windows;

namespace Orarend_osszerako.View
{
    /// <summary>
    /// Interaction logic for KurzusHozzaad.xaml
    /// </summary>
    public partial class TargyHozzaad : Window
    {
        public TargyHozzaad()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
