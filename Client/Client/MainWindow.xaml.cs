using Client.DTO;
using Client.Utils;
using Client.Views;
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

namespace Client
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(UserDTO data)
        {
            InitializeComponent();

            infoAccount.DataContext = data.username;
            Application.Current.Properties["userId"] = data.id.ToString();
        }
        private void Dashboard_Loaded(object sender, RoutedEventArgs e)
        {
            _main.Navigate(new SearchScreen());
        }
        private void ColorZone_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
        public void btnCommands_Click(object sender, RoutedEventArgs e)
        {
            Button curButton = sender as Button;
            if (curButton.Tag.Equals("btnClose"))
            {
                string exitStr = "Close";
                SendData<String> sendData = new SendData<String>(Actions.EXIT, "aaa", exitStr);
                int byteSent = SocketUtils.send(sendData);

                // close connect
                SocketUtils.close();
                this.Close();
            }
            else if (curButton.Tag.Equals("btnMinim"))
            {
                this.WindowState = WindowState.Minimized;
            }
            else if (curButton.Tag.Equals("btnMaxim"))
            {
                if (this.WindowState == WindowState.Maximized)
                {
                    this.WindowState = WindowState.Normal;
                }
                else
                {
                    this.WindowState = WindowState.Maximized;
                }
            }
        }
        private void LogOutMenu_Click(object sender, RoutedEventArgs e)
        {
            var screen = new LoginScreen();
            screen.Show();

            this.Close();

        }

        private void infoRoom_Click(object sender, RoutedEventArgs e)
        {
            _main.Navigate(new HotelBookingHistoryScreen());
        }
    }
}
