   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.ViewsClient.Views  5   	   !    Client.Views.RegisterScreen   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   &localclr-namespace:Client.Views  5   	   -   5        $��registerScreen��5
   	     � Title$  Login��5	   	   $	��480��5   	   $	��500��6    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � AllowsTransparency$
 True��5   	   
������  � 	Resources 5       A  =Fluent.Ribbon.Brushes.WindowCommands.CaptionButton.Foreground �� Color  EllipseButton �� 
TargetType �� Property �� Value	 �� 
TargetType
 �� Triggers P� Property P� Value��%
  &	        &	      �� 5   
   $ White��6`   �� 5   
   " ��6&   .�5      ��  �@�OverridesDefaultStyle$
 True��66   �� 5       �@�Cursor$
 Hand��6'   �� 5       � �� 5      �� 5      "	 ��6&   .R�5      �� $��border��6!   $��0q�6/   
�������#��z��6W   ._�5      �� $��Center=�6/   $��Center=�6L   5      
 5      P� 5       �@J�IsMouseOver$
 True��6=   . �5   "   ��  �@J�Opacity$	 0.8Q�6<   5       5"      5$      5%      5&      .��5)      ��  �� CornerRadius$ 8��6   ���	#FFFAFAFA._�5*   
   �  � RowDefinitions 5+      �� 5-      $��3* �6    �� 50      $
��1.5* �6    �� 53      $
��1.5* �6    �� 56      $
��1.5* �6    �� 59      $
��2.0* �6    �� 5;      $
��0.7* �6    5=      .+�5A      (  "MaterialDesignThemes.Wpf.ColorZone  -   5        $��5q�5C      ���#21bf73   CornerRadius$ 8��5E      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth2=�5F      .��5H      � $��30��6   .+�5J      �� -   5        $��txtTitle��5J       $��
Đăng Ký��5K       $��20(�5L       $��Sitka Subheading)�5M       $��Center=�5N       $��Center=�5O       �� 5Q      -   5        
 � Tag$ btnClose��5R      $��25��5S      $��25��6)   
��� E�� J� Opacity$	 0.8Q�5U      ���	#FFF6713F$��Right=�5W       / +MaterialDesignFloatingActionMiniLightButton#��[ 5X      .��5Y      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Power=�62   $��15��5Z   2   $��15��5[   2   5\      �� 5]      -   5        $ btnMaxim��5^      $��0,0,30,0q�5_      $��25��5`      $��25��6)   $	 0.8Q�64   $��Right=�5a      #��[ 5b      ���#21bf73���#2b580c.��5e        $ WindowMaximize=�62   $��15��5f   2   $��15��5g   2   5h      �� 5i      -   5        $ btnMinim��5j      $��0,0,60,0q�5k      $��25��5l      $��25��6)   $	 0.8Q�64   $��Right=�5m      #��[ 5n      ���#21bf73���#2b580c.��5q        $ WindowMinimize=�62   $��15��5r   2   $��15��5s   2   5t      5u      5v      � 5x      $��0��6   $��0 30 0 0q�6    5y      � 5{      $��1��6   .+�5|      � $��	0 10 0 10q�6   .+�5~      �� $��/Views/Images/User.png��6   $
��Left=�5      $��Center=�5�      $��30��5�      $��30��5�      $��80 0 0 0q�5�      �� 5�      -   5        $��
tbUsername��5�      $��17(�5�      $��Sitka Subheading)�5�      
������ $��130,0,100,0q�5�      $��
0,0,0,0.25q�5�      $��Center=�5�      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Username��5�      $��1 0 0 0q�5�      $
{�True��5�         FloatingScale$	 .85Q�5�       % !MaterialDesignFloatingHintTextBox#��[ 5�      5�      5�      � 5�      $��2��6   .+�5�      � $��	0 10 0 10q�6   .+�5�      �� $��/Views/Images/Pass.png��6   $
��Left=�5�      $��Center=�5�      $��30��5�      $��30��5�      $��80 0 0 0q�5�       �� StretchDirection$
 Both=�6+   $��Uniform=�6C   G� 5�      -   5        $��
tbPassword��5�   "   $��17(�5�      $��Sitka Subheading)�5�      
������ $��130,0,100,0q�5�      $��
0,0,0,0.25q�5�      $��Center=�5�      $ Mật Khẩu��5�      $��1 0 0 0q�5�      $
{�True��5�      $	 .85Q�5�       ) %MaterialDesignFloatingHintPasswordBox#��[ 5�      5�      5�      � 5�      $��3��6   .+�5�      � $��	0 10 0 10q�6   .+�5�      �� $%��../Views/Images/credit-card.png��6   $
��Left=�5�      $��Center=�5�      $��30��5�      $��30��5�      $��80 0 0 0q�5�      �� 5�      -	   5        $��tbBankCardId��5�      $��17(�5�      $��Sitka Subheading)�5�      
������ $��130,0,100,0q�5�      $��
0,0,0,0.25q�5�      $��Center=�5�      $ Card ID Ngân hàng��5�      $��1 0 0 0q�5�      $
{�True��5�      $	 .85Q�5�      #��[ 5�      5�      5�      � 5�      $��4��6   .+�5�      �� -
   5        $��btnLogin��5�      $��3��5�      $��15(�5�      $��Sitka Subheading)�5�      $	��200��5�      $��35��5�      $��
Đăng Ký��5�      $��0,40,0,0q�5�      $	��Top=�5�      ���#21bf73#��[ 5�       5�      ��%_   '��       �� 5�      " ��6    .�5�      ��  �@��CornerRadius$ 20��6=   5�      5�      5�      5�      � 5�      $��5��6   .+�5�      �� $��Center=�6   $	��Top=�5�      $��Sitka Subheading)�5�      $��12(�5�      �� 5�      -   5        
���   �.�5�   G   Quay về đăng nhập6Z   5�      5�      5�      5�      5�      