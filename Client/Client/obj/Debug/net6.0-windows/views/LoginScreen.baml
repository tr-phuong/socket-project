   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5   	       Client.Views.LoginScreen   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   &localclr-namespace:Client.Views  5   	   -   5        $��loginScreen��5
   	     � Title$  Login��5	   	   $	��480��5   	   $	��500��6    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � AllowsTransparency$
 True��5   	   
������  � 	Resources 5       A  =Fluent.Ribbon.Brushes.WindowCommands.CaptionButton.Foreground �� Color  EllipseButton �� 
TargetType �� Property �� Value	 �� 
TargetType
 �� Triggers P� Property P� Value��%
  &	        &	      �� 5   
   $ White��6`   �� 5   
   " ��6&   .�5      ��  �@�OverridesDefaultStyle$
 True��66   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5      �� 5      "	 ��6&   .R�5      �� $��border��6!   $��0q�6/   
�������#��z��6W   ._�5      �� $��Center=�6/   $��Center=�6L   5      
 5      P� 5       �@J�IsMouseOver$
 True��6=   . �5    "   ��  �@J�Opacity$	 0.8Q�6<   5!      5#      5%      5&      5'      .��5*      ��  �� CornerRadius$ 8��6   ���	#FFFAFAFA._�5+   
   �  � RowDefinitions 5,      �� 5.      $��3* �6    �� 51      $
��1.5* �6    �� 54      $
��1.5* �6    �� 57      $
��2.0* �6    �� 5:      $
��1.0* �6    .+�5>      (  "MaterialDesignThemes.Wpf.ColorZone  -   5        $��5q�5@      ���#21bf73   CornerRadius$ 8��5B      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth2=�5C      .��5E      � $��30��6   .+�5G      �� -   5        $��txtTitle��5G       $��Đăng Nhập��5H       $��20(�5I       $��Sitka Subheading)�5J       $��Center=�5K       $��Center=�5L       �� 5N      -   5        
 � Tag$ btnClose��5O      $��25��5P      $��25��6)   
��� E�� J� Opacity$	 0.8Q�5R      ���	#FFF6713F$��Right=�5T       / +MaterialDesignFloatingActionMiniLightButton#��[ 5U      .��5V      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Power=�62   $��15��5W   2   $��15��5X   2   5Y      �� 5Z      -   5        $ btnMaxim��5[      $��0,0,30,0q�5\      $��25��5]      $��25��6)   $	 0.8Q�64   $��Right=�5^      #��[ 5_      ���#21bf73���#2b580c.��5b        $ WindowMaximize=�62   $��15��5c   2   $��15��5d   2   5e      �� 5f      -   5        $ btnMinim��5g      $��0,0,60,0q�5h      $��25��5i      $��25��6)   $	 0.8Q�64   $��Right=�5j      #��[ 5k      ���#21bf73���#2b580c.��5n        $ WindowMinimize=�62   $��15��5o   2   $��15��5p   2   5q      5r      5s      � 5u      $��0��6   $��0 30 0 0q�6    5v      � 5x      $��1��6   .+�5y      � $��	0 10 0 10q�6   .+�5{      �� $��/Views/Images/User.png��6   $
��Left=�5|      $��Center=�5}      $��30��5~      $��30��5      $��80 0 0 0q�5�      �� 5�      -   5        $��
tbUsername��5�      $��17(�5�      $��Sitka Subheading)�5�      
������ $��130,0,100,0q�5�      $��
0,0,0,0.25q�5�      $��Center=�5�      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Username��5�      $��1 0 0 0q�5�      $
{�True��5�         FloatingScale$	 .85Q�5�       % !MaterialDesignFloatingHintTextBox#��[ 5�      5�      5�      � 5�      $��2��6   .+�5�      � $��	0 10 0 10q�6   .+�5�      �� $��/Views/Images/Pass.png��6   $
��Left=�5�      $��Center=�5�      $��30��5�      $��30��5�      $��80 0 0 0q�5�       �� StretchDirection$
 Both=�6+   $��Uniform=�6C   G� 5�      -   5        $��
tbPassword��5�   "   $��17(�5�      $��Sitka Subheading)�5�      
������ $��130,0,100,0q�5�      $��
0,0,0,0.25q�5�      $��Center=�5�      $ Mật Khẩu��5�      $��1 0 0 0q�5�      $
{�True��5�      $	 .85Q�5�       ) %MaterialDesignFloatingHintPasswordBox#��[ 5�      5�      5�      � 5�      $��3��6   .+�5�      �� -	   5        $��btnLogin��5�      $��3��5�      $��15(�5�      $��Sitka Subheading)�5�      $	��200��5�      $��35��5�      $��Đăng Nhập��5�      $��0,40,0,0q�5�      $	��Top=�5�      ���#21bf73#��[ 5�       5�      ��%_   '��       �� 5�      " ��6    .�5�      ��  �@��CornerRadius$ 20��6=   5�      5�      5�      �� 5�      -
   5        $��version��5�      $��Center=�5�      $��Bottom=�5�      $��Italic$�5�      $��Times New Roman)�5�      $��15(�5�      $��0 0 0 5q�5�      5�      � 5�      $��4��6   .+�5�      �� $��Center=�6   $	��Top=�5�      $��Sitka Subheading)�5�      $��12(�5�      �� 5�      -   5        
���   �.�5�   J   Đăng ký tài khoản6]   5�      5�      5�      5�      5�      