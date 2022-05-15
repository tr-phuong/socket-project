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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client.Views
{
    /// <summary>
    /// Interaction logic for HotelBookingHistoryScreen.xaml
    /// </summary>
    public partial class HotelBookingHistoryScreen : UserControl
    {
        private List<BookItemEntity> listBookItem = new List<BookItemEntity>();
        public HotelBookingHistoryScreen()
        {
            InitializeComponent();
            getListBookingHotel();
        }
        private  void updateView()
        {
            listRooms.ItemsSource = listBookItem.ToList();
        }
        private void getListBookingHotel()
        {
            string userId = Application.Current.Properties["userId"] as string;
            SendData<String> sendData = new SendData<String>(Actions.SHOW_HOTEL_BOOKING_HISTORY, "Show history", userId);
            int byteSent = SocketUtils.send(sendData);
            ReceiveData<BookingDTO> receiveData = SocketUtils.receiveListData(byteSent);

            listBookItem = receiveData.data.listBookItem;
            updateView();
        }

        private void backWard_Click(object sender, RoutedEventArgs e)
        {
            hotelBookingHistory.Children.Clear();
            hotelBookingHistory.Children.Add(new SearchScreen());
        }

        private void deleteRoom_MouseUp(object sender, MouseButtonEventArgs e)
        {

            var notification = new Dialog() { Message = "Xác nhận hủy đặt phòng?" };
            notification.Owner = Window.GetWindow(this);
            notification.ShowDialog();
            if (true == notification.DialogResult)
            {
                try
                {
                    BookItemEntity bookItem = (BookItemEntity)listRooms.SelectedItem;
                    SendData<int> sendData = new SendData<int>(Actions.CANCEL_BOOKING_ROOM, "Cancel booking item", bookItem.id);
                    int byteSent = SocketUtils.send(sendData);
                    ReceiveData<string> receiveData = SocketUtils.receive(byteSent);

                    if (receiveData != null)
                    {
                        if (receiveData.message.Equals(MessResponse.SUCCESS))
                        {
                            listBookItem.Remove(bookItem);
                            updateView();
                            var dialogNotification = new Dialog() { Message = "Hủy thành công" };
                            dialogNotification.Owner = Window.GetWindow(this);
                            dialogNotification.ShowDialog();
                        }
                        else
                        {
                            var dialogNotification = new Dialog() { Message = receiveData.message };
                            dialogNotification.Owner = Window.GetWindow(this);
                            dialogNotification.ShowDialog();
                        }
                    }
                }
                catch (Exception ex)
                {
                    var dialogNotification = new Dialog() { Message = ex.Message };
                    dialogNotification.Owner = Window.GetWindow(this);
                    dialogNotification.ShowDialog();
                }
            }

        }
    }
}
