   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5          Client.Views.RoomDetails   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      &localclr-namespace:Client.Views  5        � 	Resources  5
      ��%    5      .��5      � -   5         �Name$ createOrdersScreen��5      .+�5   
   � ���	#FFFAFAFA � RowDefinitions 5      �� 5      $��0.23* �6    �� 5      $��0.23* �6    �� 5      $��0.23* �6    �� 5      $��1* �6     � ColumnDefinitions 5      �� 5      $
��1.4* �6#   �� 5      $��1* �6#   .+�5      �� -   5        $��roomTypeTextBox��5!      $��0��5      $��1��6#   )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Loại Phòng��5      $��15(�5      
������ $��Sitka Subheading)�5      $
��Bold"�5       %  !MaterialDesignFloatingHintTextBox#��[  5       $��Center=�5"      �� 5(      -   5        $��dateBookTextBox��5/      $��1��5(      $��1��6#   $ Ngày Có Thể Đặt��5)      $��15(�5*      
������ $��Sitka Subheading)�5,      $
��Bold"�5-      #��[  5.      $��Center=�50      �� 54      -   5        $��roomRateTextBox��5;      $��2��54      $��1��6#   $ Giá Phòng��55      $��15(�56      
������ $��Sitka Subheading)�58      $
��Bold"�59      #��[  5:      $��Center=�5<      �� 5B      $��0��6   $��0��5C      $��3��6"    �� CornerRadius$ 15��5D      
�������$��
15 10 30 0q�5F       J� Effect 5G      3  -System.Windows.Media.Effects.DropShadowEffect  5H         Color$ Black��5I   %      	Direction$	 270Q�5J   %   	   ShadowDepth$	 1Q�5K   %   
   
BlurRadius$
 10Q�5L   %   ._�5O      �� -   5        $��imgRoom��5P      $
��Fill=�5O      5Q      5R      � 5T      $��3��6   $��2��6     5U      �� 5V      $
��0.1* �6$   �� 5W      $��* �6$   .+�5Z      �� $��0��6   $��10 0 0 0q�5[      $��Mô tả��5\      $��15(�5]      $
��Left=�5^      $��Bottom=�5_      
������ $��Sitka Subheading)�5a      �� 5c      $��1��6    �� Orientation$ 
Horizontal=�6+   .+�5d      �� $��10 0 0 0q�5e      $��13(�5f      $
��Left=�5g      
������ $��Sitka Subheading)�5i      �� 5j      $
��Bold"�6   .�61   Kích thước phòng 12 m²6J   �� 6P   1 giường đôi lớn�� 5k   /   <:Giường thoải mái, 7.3 – Dựa trên 10 đánh giá�� 5l   K   GEPhòng Giường Đôi này có truyền hình vệ tinh và minibar.�� 5m   V   �� 5n      �� 5o      $
��Bold"�6   .�61   (&Trong phòng tắm riêng của bạn:6S   �� 6X   '%Đồ vệ sinh cá nhân miễn phí�� 5p   :   Nhà vệ sinh�� 5q   *   !Bồn tắm hoặc Vòi sen�� 5r   7   Khăn tắm�� 5s   '   Máy sấy tóc�� 5t   -   Giấy vệ sinh�� 5u   +   5v      �� 5w      $��10 0 0 0q�5x      $��13(�5y      $
��Left=�5z      
������ $��Sitka Subheading)�5|      �� 5}      $
��Bold"�6   .�61   Tiện nghi phòng:6D   �� 6I   Nước rửa tay�� 5~   +   	Minibar�� 5   &   Điều hòa không khí�� 5�   1   Lối vào riêng�� 5�   ,   Quạt máy�� 5�   )   #!Thiết bị báo carbon monoxide�� 5�   ;   Ấm đun nước điện�� 5�   /   Bàn làm việc�� 5�   /   TV�� 5�   !   Điện thoại�� 5�   +   TV màn hình phẳng�� 5�   0   Truyền hình cáp�� 5�   1   Máy lọc không khí�� 5�   0   Ổ điện gần giường�� 5�   0   Dịch vụ báo thức�� 5�   /   20Máy điều hòa độc lập cho từng phòng�� 5�   B   &$Hút thuốc: ​Không hút thuốc�� 5�   :   5�      �� 5�      $��10 0 0 0q�5�      $��13(�5�      $
��Left=�5�      
������ $��Sitka Subheading)�5�      �� 5�      $
��Bold"�6   .�60   Hướng tầm nhìn:6B   �� 6G   Tầm nhìn ra khung cảnh�� 5�   5   �� 5�      �� 5�      $
��Bold"�6   .�60   Chỗ đậu xe: ​6@   �� 6E   Không có chỗ đỗ xe.�� 5�   3   5�      5�      5�      � 5�      -   5         �Name$ ProgressBar��5�      $��1��5�      $��4��6'   $��4��68   $��2��6L   $��25��5�      $��25��6%    % !MaterialDesignCircularProgressBar#��[ 5�      5�      5�      5�      5�      