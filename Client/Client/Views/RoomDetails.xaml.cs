using Client.entities;
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

namespace Client.Views
{
    /// <summary>
    /// Interaction logic for RoomDetails.xaml
    /// </summary>
    public partial class RoomDetails : UserControl
    {
        private RoomsEntity _roomsEntity = new RoomsEntity();
        public RoomDetails(RoomsEntity roomsEntity)
        {
            InitializeComponent();
            _roomsEntity = roomsEntity;

            roomTypeTextBox.Text = roomsEntity.roomType;

            roomRateTextBox.Text = convert(roomsEntity.roomRate);

            DateTime dt = roomsEntity.dateBook;
            string format = String.Format("{0:d/M/yyyy HH:mm}", dt);
            dateBookTextBox.Text = format;
        }

        private string convert(int value)
        {
            double newValue = double.Parse(value.ToString());
            return newValue.ToString("N0");
        }
    }
}
