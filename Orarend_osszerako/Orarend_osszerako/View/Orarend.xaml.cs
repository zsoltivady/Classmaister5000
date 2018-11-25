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
