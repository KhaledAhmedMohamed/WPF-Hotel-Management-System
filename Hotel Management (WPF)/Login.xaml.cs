using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using System.Data;
using System.Linq;
using System.Windows;

namespace Hotel_Management__WPF_
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow
    {
        public MainWindow()
        {
            context = new();

            InitializeComponent();
        }

        HotelDBContext context;

        private void SignIn(object sender, RoutedEventArgs e)
        {
            if (TboxUserName.Text == string.Empty || TboxPassword.Password == string.Empty)
                MessageBox.Show("Enter the username and the password");
            else
            {
                if (context.Frontend.Where(f => f.UserName == TboxUserName.Text && f.Password == TboxPassword.Password).ToList().Count == 1)
                {
                    Frontend front = new();
                    front.Show();
                    this.Close();
                }
                else if (context.Kitchen.Where(k => k.UserName == TboxUserName.Text && k.Password == TboxPassword.Password).ToList().Count == 1)
                {
                    Kitchen kitchen = new();
                    kitchen.Show();
                    this.Close();
                }
                else
                    this.ShowMessageAsync("Error", "Wrong username or password");


            }
        }

    }
}
