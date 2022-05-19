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
        private int ROW_PER_PAGE = 8;

        private List<RoomsEntity> listRooms = new List<RoomsEntity>();

        private PagingInfo _pagingInfo;

        public SearchScreen()
        {
            InitializeComponent();
        }
        void CalculatePagingInfo()
        {
            int count = listRooms.Count();
            _pagingInfo = new PagingInfo()
            {
                RowsPerPage = ROW_PER_PAGE,
                TotalItems = count,
                TotalPages = count / ROW_PER_PAGE + (((count % ROW_PER_PAGE) == 0) ? 0 : 1),
                CurrentPage = 1
            };

            comboBoxPaging.ItemsSource = _pagingInfo.Pages;
            comboBoxPaging.SelectedIndex = 0;

            statusLabel.Content = $"Tổng sản phẩm: {count} ";

        }
        void UpdateListRoomView()
        {
            var skip = (_pagingInfo.CurrentPage - 1) * _pagingInfo.RowsPerPage;
            var take = _pagingInfo.RowsPerPage;
            roomsListView.ItemsSource = listRooms.Skip(skip).Take(take);
        }

        private void PreviousPaging_Click(object sender, RoutedEventArgs e)
        {
            var currentIndex = comboBoxPaging.SelectedIndex;
            if (currentIndex > 0)
            {
                comboBoxPaging.SelectedIndex--;
            }
        }

        private void NextPaging_Click(object sender, RoutedEventArgs e)
        {
            var currentIndex = comboBoxPaging.SelectedIndex;
            if (currentIndex <= _pagingInfo.Pages.Count)
            {
                comboBoxPaging.SelectedIndex++;
            }
        }

        private void ComboPageIndex_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int nextPage = comboBoxPaging.SelectedIndex + 1;
            _pagingInfo.CurrentPage = nextPage;

            UpdateListRoomView();
        }
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
            CalculatePagingInfo();
            UpdateListRoomView();
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
            SendData<String> sendData = new SendData<String>(Actions.SHOW_LIST, "Show list", name);
            int byteSent = SocketUtils.send(sendData);
            ReceiveListData receiveListData = SocketUtils.receiveListRooms();
            if(receiveListData.listData.Count > 0)
            {
                header.Text = "Tên khách sạn được tìm kiếm: ";
                nameHotel.Text = receiveListData.listData[0].hotels.name;
            }
            else
            {
                header.Text = "";
                nameHotel.Text = "";
            }
            listRooms = receiveListData.listData.ToList();
            //roomsListView.ItemsSource = receiveListData.listData.ToList();
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
                CalculatePagingInfo();
                UpdateListRoomView();
            }
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
                    RoomDTO roomDTO = new RoomDTO();
                    roomDTO.id = itemRoom.id;
                    roomDTO.roomType = itemRoom.roomType;
                    roomDTO.roomRate = itemRoom.roomRate;

                    roomDTO.hotel.name = itemRoom.hotels.name;
                    roomDTO.hotel.id = itemRoom.hotels.id;

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
            addListRoomButton.IsEnabled = false;
        }
    }
}
