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
using System.Windows.Shapes;

namespace Orarend_osszerako
{
    /// <summary>
    /// Interaction logic for TimeTableWindow.xaml
    /// </summary>
    public partial class TimeTableWindow : Window
    {
        Style Primary = Application.Current.FindResource("MaterialDesignRaisedButton") as Style;
        Style Secondary = Application.Current.FindResource("MaterialDesignRaisedDarkButton") as Style;
        //Kicseréli az aktív tab stílusát Primary stílusra, a másik kettőt Secondaryra
        public void ChangeTab(Button active, Button inactive, Button inactive2)
        {
            active.Style = Primary;
            inactive.Style = Secondary;
            inactive2.Style = Secondary;
        }

        public TimeTableWindow()
        {
            InitializeComponent();
            Main.Content = new Orarend(); //Alapból az órarend page-et tölti be
            ChangeTab(orarend, profil, beallitasok);
        }

        private void orarend_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Orarend(); // átvált órarend-re a <frame>
            ChangeTab(orarend, profil, beallitasok);
        }

        private void beallitasok_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Beallitas(); //átvált beállítások-ra a <frame>
            ChangeTab(beallitasok, profil, orarend);
        }

        private void profil_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new Profil(); // átvált profil-ra a <frame>
            ChangeTab(profil, beallitasok, orarend);
        }

        private void logout_Click(object sender, RoutedEventArgs e)
        {
            //new MainWindow().Show();
            //this.Close();
        }

        private void Main_Navigated(object sender, System.Windows.Navigation.NavigationEventArgs e)
        {

        }
    }
}
