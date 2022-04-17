using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Client.Utils
{
    /// <summary>
    /// Interaction logic for Message.xaml
    /// </summary>
    public partial class Message : Window
    {
        private int time = 2000;
        public Message()
        {
            InitializeComponent();
        }
        public string message
        {
            get { return txtMessage.Text; }
            set { txtMessage.Text = value; }
        }
        public void Sounds()
        {
            SystemSounds.Hand.Play();
        }
        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Left = Owner.Left + Owner.Width / 2 - Width / 2;
            Top = this.Owner.Top + Owner.Height / 2 - Height / 2;

            await Task.Run(() =>
            {
                Thread.Sleep(time);
            });

            DialogResult = false;
        }
    }
}
