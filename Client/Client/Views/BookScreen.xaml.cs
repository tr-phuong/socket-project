using Client.DTO;
using Client.entities;
using Client.Send;
using Client.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for BookScreen.xaml
    /// </summary>
    public partial class BookScreen : UserControl
    {
        private BookItemEntity bookItemEntity = new BookItemEntity();
        private List<BookItemEntity> listBookItem;
        private long total = 0;
        public BookScreen()
        {
            InitializeComponent();
            listBookItem = new List<BookItemEntity>();
        }
        private void NumberOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private void selectRoom_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var chooseRoom = new SearchScreen();
            chooseRoom.contentBack.Content = "Đặt Phòng";
            chooseRoom.addListRoomButton.Visibility = Visibility.Hidden;
            chooseRoom.PickRoomId = (x) =>
            {
                RoomDTO roomDTO = x;
                hotelNameTextBox.Text = roomDTO.hotel.name;
                hotelNameTextBox.IsReadOnly = true;
                typeRoomTextBox.Text = roomDTO.roomType;
                typeRoomTextBox.IsReadOnly = true;
                rateRoomTextBox.Text = convert(roomDTO.roomRate);
                rateRoomTextBox.IsReadOnly = true;

                bookItemEntity.hotelsEntity.id = roomDTO.hotel.id;
                bookItemEntity.hotelsEntity.name = roomDTO.hotel.name;
                bookItemEntity.roomsEntity.id = roomDTO.id;
                bookItemEntity.roomsEntity.roomType = roomDTO.roomType;
                bookItemEntity.roomsEntity.roomRate = roomDTO.roomRate;

                bookItemEntity.rate = roomDTO.roomRate;
            };
            chooseRoom.addListRoomButton.Visibility = Visibility.Visible;
            bookScreen.Children.Add(chooseRoom);
        }

        private string convert(int value)
        {
            double newValue = double.Parse(value.ToString());
            return newValue.ToString("N0");
        }
        private string convert(long value)
        {
            double newValue = double.Parse(value.ToString());
            return newValue.ToString("N0");
        }

        private void backWard_Click(object sender, RoutedEventArgs e)
        {
            bookScreen.Children.Clear();
        }

        private void rateRoomTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void dateBookDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void leavingDateDatePicker_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void btncancel_Click(object sender, RoutedEventArgs e)
        {

        }
        private string Convert(long value)
        {
            double newValue = double.Parse(value.ToString());
            return newValue.ToString("N0");
        }
        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {
            if (listBookItem.Count <= 0) {
                Dialog dialog = new Dialog() { Message = "Hiện không có phòng được đặt." };
                dialog.Owner = Window.GetWindow(this);
                dialog.ShowDialog();
                return;
            }

            var dialogNotification = new Dialog() { Message = "Xác nhận đặt phòng?" };
            dialogNotification.Owner = Window.GetWindow(this);
            dialogNotification.ShowDialog();
            if (true == dialogNotification.DialogResult)
            {
                try
                {
                    string userId = Application.Current.Properties["userId"] as string;
                    BookingDTO bookingDTO = new BookingDTO(userId, listBookItem);

                    SendData<BookingDTO> sendData = new SendData<BookingDTO>(Actions.BOOKING, "Booking", bookingDTO);
                    int byteSent = SocketUtils.send(sendData);
                    ReceiveData<long> receiveTotal = SocketUtils.receiveTotal();

                    if (receiveTotal.message.Equals(MessResponse.SUCCESS))
                    {
                        var messBox = new Dialog() { Message = String.Format("Tổng tiền: {0} đ", Convert(receiveTotal.data)) };
                        messBox.Owner = Window.GetWindow(this);
                        messBox.ShowDialog();
                    }
                    else
                    {
                        var messBox = new Dialog() { Message = receiveTotal.message };
                        messBox.Owner = Window.GetWindow(this);
                        messBox.ShowDialog();
                    }
                }
                catch(Exception ex)
                {
                    var messBox = new Dialog() { Message = ex.Message };
                    messBox.Owner = Window.GetWindow(this);
                    messBox.ShowDialog();
                }

            }
        }
        private void updateListRoom()
        {
            listBookItem.Add(bookItemEntity);
            if(bookItemEntity != null) 
                bookItemEntity = new BookItemEntity();
            updateView();
        }
        private void BtnAddNewRoom_Click(object sender, RoutedEventArgs e)
        { 
            try { 
                if((DateTime)dateBookDatePicker.SelectedDate == null || (DateTime)leavingDateDatePicker.SelectedDate == null)
                {
                    Dialog dialog = new Dialog() { Message = "Vui long chon ngay" };
                    dialog.Owner = Window.GetWindow(this);
                    dialog.ShowDialog();
                 }
                DateTime dateBook = (DateTime)dateBookDatePicker.SelectedDate;
                DateTime leavingDate = (DateTime)leavingDateDatePicker.SelectedDate;

                if (dateBook == null || leavingDate == null)
                {
                    Dialog dialog = new Dialog() { Message = "Vui lòng chọn ngày " + ((dateBook == null) ? "đặt" : "rời đi ") + "" };
                    dialog.Owner = Window.GetWindow(this);
                    dialog.ShowDialog();
                    return;
                }
                if (dateBook > leavingDate)
                {
                    Dialog dialog = new Dialog() { Message = "Ngày rời đi phải lớn hơn ngày đặt, vui lòng chọn lại!" };
                    dialog.Owner = Window.GetWindow(this);
                    dialog.ShowDialog();
                    return;
                }

                bookItemEntity.bookingDate = dateBook;
                bookItemEntity.leavingDate = leavingDate;
                bookItemEntity.note = (noteRoomTextBox.Text.Equals("")) ? "" : noteRoomTextBox.Text;
                updateListRoom();
                clear();
            }
            catch(Exception ex)
            {
                Dialog dialog = new Dialog() { Message = ex.Message };
                dialog.Owner = Window.GetWindow(this);
                dialog.ShowDialog();
            }
        }
        private void clear()
        {
            hotelNameTextBox.Clear();
            typeRoomTextBox.Clear();
            rateRoomTextBox.Clear();
            noteRoomTextBox.Clear();
        }
        private void cannelRoom_MouseUp(object sender, MouseButtonEventArgs e)
        {
            BookItemEntity pick = listRooms.SelectedItem as BookItemEntity;

            listBookItem.Remove(pick);
            updateView();
        }

        private void updateView()
        {
            total = listBookItem.Sum(room => room.rate);
            sumTotalOfRoom.Text = String.Format("VNĐ {0}", convert(total));
            listRooms.ItemsSource = listBookItem.ToList();
        }

        private void hotelNameTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if (hotelNameTextBox.Text.Equals("")){
                btnAddNewRoom.IsEnabled = false;
            }
            else {
                btnAddNewRoom.IsEnabled = true;
            }
        }
    }
}
