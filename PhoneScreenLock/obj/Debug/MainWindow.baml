   M S B A M L   `   `   `  ����J  FPhoneScreenLock, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:PhoneScreenLockPhoneScreenLock  5   	        PhoneScreenLock.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:PhoneScreenLock     5   	     � Title$  BlueToothLock��5	   	   $	��350��6   $	��525��6,   
������� � DataContext 5   	   �� *
MainWindow+   Locator �� Source# [  .��5
      �  � ColumnDefinitions 5   
   �� 5      $	��200 �6   6-   �� 5      $	��200 �6   6-   �� 5      $��* �6   6+    � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $	��100 �6   .+�5   
   �� $
��14px(�6   $��10,0,0,0q�6$   
�������Available Devices6c   �� 5   
   -   5         ��Name$ lbBluetoothList��5   3   $��0��6   $��2��6   $��Stretch=�6L   $��10,20,10,10q�6q   ��6�   �� *blueToothDevices+ �� SelectedIndex 6�   �� *EndpointIndex+��5      �� 5      .R�5      � .+�5      �� ��6$   ��  �� Path$ 
DeviceName�5      5      5      �� 5   
   $��0��6   $��2��6   $	��Top=�6.   $��	0,10,10,0q�6F   $��Right=�6Y   $��25��6u   $��50��6�   ��6�   �� *refreshList+.��6�   Sync5       �� 5!   
   $��1��6   $��25��6   $	��100��6*   $��Right=�6U   $��0,0,10,0q�6q   ��66   �� *
screenLock+.��6�   Lock Screen5#      �� 5$   
   $��1��6   $��1��6   $��25��6.   $	��100��6�   $
��Left=�6�   $��10,0,0,0q�6�   ��6:   �� *connectDevice+��6\   �� *SelectedItem+ �� ElementName$ lbBlueToothList��.��6�   Sync With Device5&      5'      5(      