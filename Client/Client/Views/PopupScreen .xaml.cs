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
    /// Interaction logic for PopupScreen.xaml
    /// </summary>
    public partial class PopupScreen : Window
    {
        private string _action = "";
        private RoomsEntity _roomsEntity = new RoomsEntity();
        public PopupScreen(RoomsEntity roomsEntity, string action)
        {
            InitializeComponent();
            _roomsEntity = roomsEntity;
            _action = action;
        }
        private void Dashboard_Loaded(object sender, RoutedEventArgs e)
        {
            if (Actions.DETAIL_ROOM.Equals(_action))
            {
                _main.Navigate(new RoomDetails(_roomsEntity));
            }
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
                this.Close();
            }
        }
    }
}
