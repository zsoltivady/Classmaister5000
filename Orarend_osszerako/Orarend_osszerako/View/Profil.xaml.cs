using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Orarend_osszerako.View
{
    /// <summary>
    /// Interaction logic for Profil.xaml
    /// </summary>
    public partial class Profil : Page
    {
        public Profil()
        {
            InitializeComponent();
        }

        private void BasicRatingBar_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.youtube.com/watch?v=Sagg08DrO5U");
        }
    }
}
