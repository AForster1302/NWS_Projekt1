   M S B A M L   `   `   `  ����J  FChat_Client_GUI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:Chat_Client_GUIChat_Client_GUI  5   	        Chat_Client_GUI.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:Chat_Client_GUI     5   	   -   5          � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)   .��5
      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��5* �6   .+�5   
   �� -   5         ��Name$ tb_msg��5      $��10q�6"   $	��400��6.   $
��Left=�6:   $��25��6U   $��Center=�6a   �� 5   
   $��1��6    �� Orientation$ 
Horizontal=�6"   .+�5      �� -   5         ��Name$ 
bt_sendAll��5      $��25��6)   $��10q�66   $	��100��6B   $��Senden An Alle��6N   $
��Left=�6�   �� 5      -   5        $ bt_sendUser��5      $��25��6*   $��10q�66   $	��100��6B   $��	Senden An��6N   $
��Left=�6|   �� 5      -   5        $ tb_send��5      $	��200��6'   $��25��63   $��Center=�6?   5      �� 5   
   -   5         ��Name$ lv_msg��5      $��2��6#   $��10,20q�60   ��6?   �� 5      5      