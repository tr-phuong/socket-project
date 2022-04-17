using Client.entities;
using Client.Receive;
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
    /// Interaction logic for SearchScreen.xaml
    /// </summary>
    public partial class SearchScreen : UserControl
    {
        List<Product> products = new List<Product>();
        public SearchScreen()
        {
            InitializeComponent();


            //for (int i = 0; i < 5; i++)
            //{
            //    products.Add(new Product(i, "Khach san 5 sao", "Giuong doi", "Co hai giuong", DateTime.Now, "image"));
            //}

            //productsListView.ItemsSource = products.ToList();
        }

        /// <summary>
        /// Quay lại màn hình home
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void backWard_Click(object sender, RoutedEventArgs e)
        {
            // nếu Pick sản phẩm để tạo hóa đơn
            //if (PickProductId != null)
            //{
            //    homeProduct.Children.Clear();
            //}
            //else
            //{
            //    homeProduct.Children.Clear();
            //    homeProduct.Children.Add(new HomeScreen(_connectionString));
            //}

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
            productsListView.ItemsSource = receiveListData.listData.ToList();
        }
        /// <summary>
        /// Nhân giá trị text trong khung Search
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void searchTextBox_SelectionChanged(object sender, RoutedEventArgs e)
        {
            if(!"".Equals(searchTextBox.Text))
            {
                searchChange();
            }
            statusLabel.Content = "Search";
        }

        private void productsListView_PreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            statusLabel.Content = "Detail product";
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

    }
    public class Product
    {
        public int id { get; set; }
        public string name { get; set; }
        public string typeRoom { get; set; }
        public string description { get; set; }
        public DateTime dateTime { get; set; }
        public string image { get; set; }

        public Product(int id, string name, string typeRoom, string description, DateTime date, string image)
        {
            this.id = id;
            this.name = name;
            this.typeRoom = typeRoom;
            this.description = description;
            this.dateTime = date;
            this.image = image;
        }
    }
}
