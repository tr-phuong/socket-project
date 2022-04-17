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
            //// Kiểm tra nếu chưa nhập username hay password
            //if (tbUser.Text.Length == 0 && tbPass.Password.Length == 0)
            //{
            //    // Hiện thông báo lỗi
            //    var dialog = new Messenge() { Message = "Please enter your account and password" };
            //    dialog.Sounds();
            //    dialog.time = 1000;
            //    dialog.Owner = Window.GetWindow(this);
            //    dialog.ShowDialog();
            //    return;
            //}
            //else if (tbUser.Text.Length == 0)
            //{
            //    // Hiện thông báo lỗi
            //    var dialog = new Messenge() { Message = "Please enter your account" };
            //    dialog.Sounds();
            //    dialog.time = 1000;
            //    dialog.Owner = Window.GetWindow(this);
            //    dialog.ShowDialog();
            //    return;
            //}
            //else if (tbPass.Password.Length == 0)
            //{
            //    // Hiện thông báo lỗi
            //    var dialog = new Messenge() { Message = "Please enter a password" };
            //    dialog.Sounds();
            //    dialog.time = 1000;
            //    dialog.Owner = Window.GetWindow(this);
            //    dialog.ShowDialog();
            //    return;
            //}
            //else
            //{
            //    // Doc app.config de lay thong itn connection
            //    var server = ConfigurationManager.AppSettings["server"];
            //    var database = ConfigurationManager.AppSettings["database"];
            //    var username = tbUser.Text;
            //    var password = tbPass.Password;

            //    var builder = new SqlConnectionStringBuilder();
            //    builder.DataSource = server;
            //    builder.InitialCatalog = database;
            //    builder.UserID = username;
            //    builder.Password = password;

            //    var connectionString = builder.ConnectionString;

            //    var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            //    if (checkRememberMeCheckBox.IsChecked == true)
            //    {
            //        //Lấy thông tin tài khoản cho vào app.config
            //        config.AppSettings.Settings["username"].Value = username;

            //        //Mã hóa mật khẩu
            //        var passwordInBytes = Encoding.UTF8.GetBytes(password);
            //        var entropy = new byte[20];
            //        using (var rng = new RNGCryptoServiceProvider())
            //        {
            //            rng.GetBytes(entropy);
            //        }

            //        var cypherText = ProtectedData.Protect(passwordInBytes, entropy, DataProtectionScope.CurrentUser);

            //        //Lưu mật khẩu được mã hóa vào config
            //        config.AppSettings.Settings["password"].Value = Convert.ToBase64String(cypherText);
            //        config.AppSettings.Settings["entropy"].Value = Convert.ToBase64String(entropy);
            //    }
            //    else
            //    {
            //        config.AppSettings.Settings["username"].Value = "";
            //        config.AppSettings.Settings["password"].Value = "";
            //        config.AppSettings.Settings["entropy"].Value = "";
            //    }

            //    config.Save(ConfigurationSaveMode.Minimal);
            //    ConfigurationManager.RefreshSection("appSettings");

            //    using (var db = new MyShopEntities(connectionString))
            //    {
            //        //db.Database.Connection.Open();
            //        var (ok, message) = db.TestConnection();
            //        if (ok)
            //        {
            //            var account = db.Accounts.Find(username);
            //            if (account.Role.Equals("Admin"))
            //            {
            //                var role = account.Role;
            //                var user = account.Username;
            //                Dashboard dashboard = new Dashboard(connectionString, role, user);
            //                dashboard.Show();

            //                this.Close();
            //            }
            //            else
            //            {
            //                var role = account.Role;
            //                var user = account.Username;
            //                Dashboard dashboard = new Dashboard(connectionString, role, user);
            //                dashboard.Show();

            //                this.Close();
            //            }
            //        }
            //        else
            //        {
            //            // Hiện thông báo lỗi
            //            var dialog = new Messenge() { Message = "Account or password is incorrect" };
            //            dialog.time = 1000;
            //            dialog.Owner = Window.GetWindow(this);
            //            dialog.ShowDialog();
            //            return;
            //        }
            //    }

                ////Nếu đăng nhập thành công, ẩn màn hình login
                //Dashboard dashboard = new Dashboard();
                //dashboard.Show();
                //this.Close();
            //}
        }

        private void btnSetting_Click(object sender, RoutedEventArgs e)
        {
            //var screen = new SettingScrenn();
            //screen.ShowDialog();
        }
    }
}
