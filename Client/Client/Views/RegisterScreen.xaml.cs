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
    /// Interaction logic for RegisterScreen.xaml
    /// </summary>
    public partial class RegisterScreen : Window
    {
        public RegisterScreen()
        {
            InitializeComponent();
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
        private void btnSetting_Click(object sender, RoutedEventArgs e)
        {
            //var screen = new SettingScrenn();
            //screen.ShowDialog();
        }

        private void btnResgister_Click(object sender, RoutedEventArgs e)
        {
            string username = tbUsername.Text;
            string password = tbPassword.Password;
            string bankCardID = tbBankCardId.Text;
            UserEntity newUser = new UserEntity(username, password, bankCardID);

            SendData<UserEntity> sendData = new SendData<UserEntity>(Actions.REGISTER, "", newUser);
            SocketUtils.send(sendData);
            ReceiveData<UserDTO> receive = SocketUtils.receiveUser();
            Dialog dialog = new Dialog() { Message = receive.message };
            dialog.Owner = Window.GetWindow(this);
            dialog.ShowDialog();
        }

        private void login_Click(object sender, RoutedEventArgs e)
        {
            LoginScreen loginScreen = new LoginScreen();
            loginScreen.Visibility = Visibility.Visible;
            this.Close();
        }
    }
}
