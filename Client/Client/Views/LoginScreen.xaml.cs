using Client.DTO;
using Client.entities;
using Client.Utils;
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

namespace Client.Views
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        public LoginScreen()
        {
            InitializeComponent();
            SocketUtils.connection();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {

        }
        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                btnLogin.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }

        public void btnCommands_Click(object sender, RoutedEventArgs e)
        {
            Button curButton = sender as Button;
            if (curButton.Tag.Equals("btnClose"))
            {
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
        private void ColorZone_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Password;

            UserLogin newUser = new UserLogin(username, password);

            SendData<UserLogin> sendData = new SendData<UserLogin>(Actions.LOGIN, "", newUser);
            SocketUtils.sendUserLogin(sendData);
            ReceiveData<UserDTO> receive = SocketUtils.receiveUser();
            if (!receive.action.Equals(Actions.LOGGED))
            {
                Dialog dialog = new Dialog() { Message = receive.message };
                dialog.Owner = Window.GetWindow(this);
                dialog.ShowDialog();
            }
            else
            {
                MainWindow mainWindow = new MainWindow(receive.data);
                mainWindow.Show();

                this.Close();
            }
        }

        private void register_Click(object sender, RoutedEventArgs e)
        {
            RegisterScreen registerScreen = new RegisterScreen();
            registerScreen.Show();
            this.Visibility = Visibility.Collapsed;
        }
    }
}
