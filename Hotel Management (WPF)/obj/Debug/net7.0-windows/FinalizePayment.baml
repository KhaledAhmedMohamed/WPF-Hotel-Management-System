   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   Q MHotel Management (WPF), Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Hotel_Management__WPF_Hotel_Management__WPF_ 5   	   ,   &Hotel_Management__WPF_.FinalizePayment   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Kmah;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   6local$clr-namespace:Hotel_Management__WPF_     5   	   -   5        $��WinFinalizePayment��5
   	     � Title$  FinalizePayment��5	   	   $	��290��6!   $	��450��6.    � WindowStartupLocation$ CenterScreen=�5   	   .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,    � ColumnDefinitions 5   
   �� 5      6!   �� 5      6!   .+�5    
   �� $��10q�6   $��0��6    $��0��60   Reservation6J   �� 5!   
   $��Right=�6   $��10q�60   $��1��6<   $��0��6L   Price6`   �� 5#   
   $��10,0,0,5q�6   $��0��6&   $��1��66   Current bill6Q   �� 5$   
   -   5        $��lblCurentBill��5$      $��0,0,70,5q�6)   $��Right=�6;   $��1��6W   $��1��6g   $6w   �� 5'   
   $��10,0,0,5q�6   $��0��6&   $��2��66   	Food bill6N   �� 5(   
   -   5        $��lblFoodBill��5(      $��0,0,70,5q�6'   $��Right=�69   $��1��6U   $��2��6e   $6u   �� 5+   
   $��	0,0,120,5q�6   $��Right=�6'   $��1��6D   $��3��6T   Tax6f   �� 5,   
   -   5        $��lblTax��5,      $��0,0,40,5q�6"   $��Right=�64   $
��auto��6P   $��1��6]   $��3��6m   $6}   �� 5.   
   $��	0,0,132,5q�6   $��Right=�6'   $��1��6C   $��4��6S   $
��Bold"�6`   Total6y   �� 5/   
   -   5        $��lblTotal��5/      $��0,0,40,5q�6$   $��Right=�66   $
��auto��6R   $��1��6_   $��4��6o   $6   �� 51   
    �� Orientation$ Vertical=�6   $��0��6,   $��5��6<   .+�52      �� $
��10,5q�6   	Payment6/   �� 53      -   5        $��comboBoxPaymentMethod��53      *   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Payment Type��64   $
��Left=�6_   $
��10,5q�6z   $	��132��6�   6�   54      �� 55   
   -   5        $��TboxCardNumber��55      $ 9999 - 9999 - 9999 - 9999��6M   $��159,31,10,6q�6�   $��5��6�   $��22��6�   $��2��6�   �� 57   
   -   5        $��
comboBoxMM��57      $ MM��6%   $��10,5,0,0q�6F   $��75��6X   $
��Left=�6c   $��0��6~   $��6��6�   $��2��6�   �� 58   
   $��15(�6   $��90,5,0,0q�6"   $��40��64   $
��Left=�6?   $��0��6Z   $��6��6j   $��2��6w   /6�   �� 59   
   -	   5        $��
comboBoxYY��59      $ YY��6%   $��	100,5,0,0q�6F   $��68��6Y   $
��Left=�6d   $��0��6   $��6��6�   $��2��6�   �� 5:   
   -
   5        $��TboxCVV��5:      $	 CVV��6!   $��	200,5,0,0q�6C   $��60��6V   $
��Left=�6a   $��0��6|   $��6��6�   $��2��6�   6�   �� 5;   
   $��	290,5,0,0q�6   $��0��6'   $��6��67   $��2��6D   
Card type:6d   �� 5<   
   -   5        $��lblCardType��5<      $��	350,5,0,0q�6'   $��0��6:   $��6��6J   $��2��6W   	Unknown6t   �� 5>   
   -   5        $��btnNext��5>      $��	0,10,20,0q�6-   $��Right=�6@   $��1��6\   $��7��6l   $��83��6y   .��6�   Next6�   5?      5A      