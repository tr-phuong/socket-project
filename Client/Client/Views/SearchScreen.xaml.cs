using Client.DTO;
using Client.entities;
using Client.Receive;
using Client.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Client.Views
{
    /// <summary>
    /// Interaction logic for SearchScreen.xaml
    /// </summary>
    public partial class SearchScreen : UserControl
    {

        //delegate cho screen hóa đơn
        public delegate void PickRoom(RoomDTO Data);
        public PickRoom PickRoomId;
        private const Int32 TIMEOUT = 10000;

        public SearchScreen()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Quay lại màn hình home
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backWard_Click(object sender, RoutedEventArgs e)
        {
            // nếu Pick sản phẩm để tạo hóa đơn
            if (PickRoomId != null)
            {
                homeSearch.Children.Clear();
            }
            else
            {
                //homeProduct.Children.Clear();
                //homeProduct.Children.Add(new MainWindow());
            }

        }
        /// <summary>
        /// Giá trị của comboBox thay đổi
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void categoriesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        #region Xử lý hiệu ứng Comboxbox
        /// <summary>
        /// Hiệu ứng khi chọn
        /// </summary>
        private void ComboProductTypes_DropDownOpened(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            comboBox.Background = Brushes.LightGray;
        }

        /// <summary>
        /// Hiệu ứng khi bỏ chọn
        /// </summary>
        private void ComboProductTypes_DropDownClosed(object sender, EventArgs e)
        {
            ComboBox comboBox = sender as ComboBox;
            comboBox.Background = Brushes.Transparent;
        }
        #endregion

        private void searchChange()
        {
            string name = searchTextBox.Text;
            SendData<String> sendData = new SendData<String>(Actions.SHOW_LIST, "aaa", name);
            int byteSent = SocketUtils.send(sendData);
            ReceiveListData receiveListData = SocketUtils.receiveListRooms();
            if(receiveListData.listData.Count > 0)
            {
                header.Text = "Tên khách sạn được tìm kiếm: ";
                nameHotel.Text = receiveListData.listData[0].hotels.name;
            }
            roomsListView.ItemsSource = receiveListData.listData.ToList();
        }
        /// <summary>
        /// Nhân giá trị text trong khung Search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void searchTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            statusLabel.Content = "Search";
            Thread getItemRooms = new Thread(() => {
                Thread.Sleep(TIMEOUT);
            });
            getItemRooms.Start();

            if (!"".Equals(searchTextBox.Text))
            {
                searchChange();
            }
            //if (!"".Equals(searchTextBox.Text))
            //{
            //    searchChange();
            //}
        }
        private void productsListView_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            statusLabel.Content = "Thông tin chi tiết phòng";
            dynamic itemRoom = (sender as ListView).SelectedItem;
            if(itemRoom != null)
            {
                int id = itemRoom.id;
                SendData<int> sendData = new SendData<int>(Actions.DETAIL_ROOM, "aaa", id);
                int byteSent = SocketUtils.send(sendData);
                ReceiveData<RoomsEntity> receiveData = SocketUtils.receiveRoom();
                RoomsEntity roomsEntity = (RoomsEntity)receiveData.data;


                PopupScreen popupScreen = new PopupScreen(roomsEntity, receiveData.action);
                popupScreen.Show();
            }






            //var db = new MyShopEntities(_connectionString);
            //dynamic itemProduct = (sender as ListView).SelectedItem;

            //if (itemProduct != null)
            //{
            //    // lấy sản phẩm trong database
            //    var product = db.Products.Find(itemProduct.Product_Id);

            //    // nếu Pick sản phẩm để tạo hóa đơn
            //    if (PickProductId != null)
            //    {
            //        PickProductId.Invoke(product);
            //        homeProduct.Children.Clear();
            //    }
            //    else
            //    {
            //        var screen = new DetailProductScreen(_connectionString, product);
            //        screen.RefreshProductList = refresh;
            //        homeProduct.Children.Add(screen);
            //    }
            //}

        }


        private void BookButton_Click(object sender, RoutedEventArgs e)
        {
            lastPick = (RoomsEntity)roomsListView.SelectedItem;
            PopupBookingScreen popupBookingScreen = new PopupBookingScreen(lastPick);
            popupBookingScreen.ShowDialog();
        }

        private void roomListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            statusLabel.Content = "Thông tin chi tiết phòng";
            RoomsEntity itemRoom = (RoomsEntity)(sender as ListView).SelectedItem;
            if (itemRoom != null)
            {
                if (PickRoomId != null)
                {
                    addListRoomButton.IsEnabled = false;
                    RoomDTO roomDTO = new RoomDTO();
                    roomDTO.id = itemRoom.id;
                    roomDTO.roomType = itemRoom.roomType;
                    roomDTO.roomRate = itemRoom.roomRate;

                    roomDTO.hotel.name = itemRoom.hotels.name;
                    roomDTO.hotel.id = itemRoom.hotels.id;

                    addListRoomButton.IsEnabled = true;

                    PickRoomId.Invoke(roomDTO);
                    homeSearch.Children.Clear();
                }
                else
                {
                    int id = itemRoom.id;
                    SendData<int> sendData = new SendData<int>(Actions.DETAIL_ROOM, "Detail room", id);
                    int byteSent = SocketUtils.send(sendData);
                    ReceiveData<RoomsEntity> receiveData = SocketUtils.receiveRoom();
                    RoomsEntity roomsEntity = (RoomsEntity)receiveData.data;


                    PopupScreen popupScreen = new PopupScreen(roomsEntity, receiveData.action);
                    popupScreen.Show();
                }
            }
        }

        private RoomsEntity lastPick = new RoomsEntity();

        private void roomsListView_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            lastPick = (RoomsEntity)(sender as ListView).SelectedItem;
        }

        private void AddListRoomButton_Click(object sender, RoutedEventArgs e)
        {
            BookScreen bookScreen = new BookScreen();
            homeSearch.Children.Add(bookScreen);
        }
    }
}
