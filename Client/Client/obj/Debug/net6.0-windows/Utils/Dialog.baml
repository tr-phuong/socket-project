   M S B A M L   `   `   `  ����A  =Client, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:Client.UtilsClient.Utils  5   	       Client.Utils.Dialog   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   _ [MaterialDesignThemes.Wpf, Version=4.4.0.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   &localclr-namespace:Client.Utils  5   	   -   5          � Title$  Dialog��5	   	   $	��200��5
   	   $	��350��6    � WindowStyle$
 None=�5   	    � WindowStartupLocation$ CenterScreen=�5   	    � AllowsTransparency$
 True��5   	   ���	#FFEDF7F3.��5      � .+�5   
   (  "MaterialDesignThemes.Wpf.ColorZone  -   5           Mode$
 Dark=�5   #   ���#21bf73$��5q�5   #   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth2=�5   #   .��5      � $��23��6   .+�5      �� $��Notification��6   $��15(�5      $��Sitka Subheading)�5      $��Center=�5      $��Center=�5      �� 5      -   5        
 � Tag$ btnClose��5       $��22��5!      $��22��6%   
��� E�� J� Opacity$	 0.8Q�5#      ���	#FFF6713F$��Right=�5%       /  +MaterialDesignFloatingActionMiniLightButton#��[  5&      .��5'      '  !MaterialDesignThemes.Wpf.PackIcon     Kind$ Power=�6.   $��15��5(   .   $��15��5)   .   5*      5+      5,      �� 5/   
   -   5        $��
txtMessage��5/      $��Sitka Subheading)�50      $��15(�51      $��
25,0,25,25q�52      $��Center=�53      $��Center=�54      	 �� TextAlignment$	 Center=�55      $
��Bold"�56      $
��Wrap=�57      
���   �58      �� 5;   
   -   5        $��1��5;      $��1��6!   $	��100��5<      $��OK��6   $
��Bold"�5=      
�������$��15(�5?      $��
0,0,120,25q�5@      $��Center=�5A      $��Bottom=�5B      ���#21bf73���#2b580c$��Sitka Subheading)�5E      
 �� 	IsDefault$

 True��5F        MaterialDesignRaisedButton#��[ 5G      5I      �� 5L   
   -   5        $��1��5L      $��1��6!   $	��100��5M      $��Cancel��6   $
��Bold"�5N      
�������$��15(�5P      $��
120,0,0,25q�5Q      $��Center=�5R      $��Bottom=�5S      ���#21bf73���#2b580c$��Sitka Subheading)�5V      #��[ 5W      5Y      5Z      5[      