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
    /// Interaction logic for PopupBookingScreen.xaml
    /// </summary>
    public partial class PopupBookingScreen : Window
    {
        private RoomsEntity _roomsEntity;
        public PopupBookingScreen(RoomsEntity lastPick)
        {
            InitializeComponent();
            _roomsEntity = lastPick;

            //hotelNameTB.Text = _roomsEntity.hotels.name;
            tbTypeRoom.Text = _roomsEntity.roomType;
            tbTypeRoom.IsReadOnly = true;
            tbRateRoom.Text = Convert(_roomsEntity.roomRate);
            tbRateRoom.IsReadOnly = true;
        }
        private string Convert(int value)
        {
            double newValue = double.Parse(value.ToString());
            return newValue.ToString("N0");
        }

        private void BtnBooking_Click(object sender, RoutedEventArgs e)
        {
            string hotelName = _roomsEntity.hotels.name;
            string typeRoom = _roomsEntity.roomType;
            int rateRoom = _roomsEntity.roomRate;
            DateTime dateBook = (DateTime)dateBookDatePicker.SelectedDate;
            DateTime leavingDate = (DateTime)leavingDateDatePicker.SelectedDate;

            string username = (string)Application.Current.Properties["username"];

            BookEntity bookEntity = new BookEntity();
            bookEntity.user.username = username;

            BookItemEntity bookItemEntity = new BookItemEntity();
            bookItemEntity.hotelsEntity.name = hotelName;
            bookItemEntity.roomsEntity.roomType = typeRoom;
            bookItemEntity.roomsEntity.roomRate = rateRoom;
            bookItemEntity.bookingDate = dateBook;
            bookItemEntity.leavingDate = leavingDate;

            bookEntity.addItem(bookItemEntity); 

            SendData<BookEntity> sendData = new SendData<BookEntity>(Actions.SHOW_LIST, "aaa", bookEntity);
            int byteSent = SocketUtils.send(sendData);
            ReceiveData<long> receiveListData = SocketUtils.receiveTotal();
            Dialog dialog = new Dialog();
            MessageBox.Show(receiveListData.message);


        }
        private void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Return)
            {
                btnBooking.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
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

        private void leavingDateDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void dateBookDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}
