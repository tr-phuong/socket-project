using Client.DTO;
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
        private RoomDTO roomDTO;
        private List<RoomDTO> roomList;
        public BookScreen()
        {
            InitializeComponent();
            roomList = new List<RoomDTO>();
        }
        private void NumberOnly_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            var textBox = sender as TextBox;
            e.Handled = Regex.IsMatch(e.Text, "[^0-9]+");
        }

        private void selectRoom_MouseUp(object sender, MouseButtonEventArgs e)
        {
            var chooseRoom = new SearchScreen();
            chooseRoom.contentBack.Content = "Creating new orders";
            chooseRoom.PickRoomId = (x) =>
            {
                roomDTO = x;
                hotelNameTextBox.Text = roomDTO.hotel.name;
                hotelNameTextBox.IsReadOnly = true;
                typeRoomTextBox.Text = roomDTO.roomType;
                typeRoomTextBox.IsReadOnly = true;
                rateRoomTextBox.Text = convert(roomDTO.roomRate);
                rateRoomTextBox.IsReadOnly = true;

            };
            createOrdersScreen.Children.Add(chooseRoom);
        }

        private string convert(int value)
        {
            double newValue = double.Parse(value.ToString());
            return newValue.ToString("N0");
        }

        private void backWard_Click(object sender, RoutedEventArgs e)
        {

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

        private void BtnConfirm_Click(object sender, RoutedEventArgs e)
        {

        }
        private void updateListRoom(RoomDTO roomDTO)
        {
            roomList.Add(roomDTO);
            listRooms.ItemsSource = roomList.ToList();
        }
        private void BtnAddNewRoom_Click(object sender, RoutedEventArgs e)
        {
            roomDTO.dateBook = (DateTime)dateBookDatePicker.SelectedDate;
            roomDTO.leavingDate = (DateTime)leavingDateDatePicker.SelectedDate;
            roomDTO.note = noteRoomTextBox.Text;
            updateListRoom(roomDTO);
        }

        private void ListRoom_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {

        }
    }
}
