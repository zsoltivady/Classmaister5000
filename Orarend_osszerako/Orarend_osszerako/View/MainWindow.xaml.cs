using Orarend_osszerako.View;
using System;
using System.Windows;

namespace Orarend_osszerako
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        Style Primary = Application.Current.FindResource("MaterialDesignRaisedButton") as Style;
        Style Secondary = Application.Current.FindResource("MaterialDesignRaisedDarkButton") as Style;
        public MainWindow()
        {
            InitializeComponent();
            Main.Content = new LoginPage(); //Alapból a login page-et tölti be
            signin.Style = Primary;
            signup.Style = Secondary;
        }

        private void SignIn_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new LoginPage(); // átvált LoginPage-re a <frame>
            signin.Style = Primary;
            signup.Style = Secondary;
        }

        private void SignUp_Click(object sender, RoutedEventArgs e)
        {
            Main.Content = new RegisterPage(); // átvált RegisterPage-re a <frame>
            signup.Style = Primary;
            signin.Style = Secondary;
        }

    }
}
