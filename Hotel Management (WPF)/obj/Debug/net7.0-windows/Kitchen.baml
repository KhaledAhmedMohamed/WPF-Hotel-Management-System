   M S B A M L   `   `   `  ����T  PMahApps.Metro, Version=2.0.0.0, Culture=neutral, PublicKeyToken=51482d6f650b2b3fV;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.MetroMahApps.Metro.Controls  5   	   Q MHotel Management (WPF), Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:Hotel_Management__WPF_Hotel_Management__WPF_ 5   	   $   Hotel_Management__WPF_.Kitchen   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Kmah;clr-namespace:MahApps.Metro.Controls;assembly=MahApps.Metro     5   	   6local$clr-namespace:Hotel_Management__WPF_     5   	   -   5        $��
WinKitchen��5
   	     � Title$  Kitchen��5	   	   $	��550��6   $
��1000��6&    � WindowStartupLocation$ CenterScreen=�5   	   .��5      ��  �� Orientation$ Vertical=�6   .+�5   
   �� $��10q�6   $��30(�6    Room Service6<   �� 5   
    �� SelectedIndex$ 1��6   .@�5      �� $��15(�6   $��TODO*��6$   .��5      �  � ColumnDefinitions 5      �� 5      $��1.25* �6+   6;   �� 5      $��1.22* �6+   6;   �� 5      $��* �6+   67    � RowDefinitions 5      �� 5      6*   .+�5      �� $��0��6!   $��0,50,5,0q�61   .+�5      �� $ 
Horizontal=�6%   .+�5       �� $��	20,30,0,0q�6(   Name6A   5!      �� 5#      $ 
Horizontal=�6%   .+�5$      �� -   5        $��TboxFirstName��5$   &    �� 
IsReadOnly$
 True��6;   *   $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ First��6M   $��20,5,0,0q�6q   $	��156��6�   6�   �� 5%      -   5        $��TboxLastName��5%   &   $
 True��6:   $
 Last��6L   $��15,5,0,0q�6o   $	��155��6�   6�   5&      �� 5(      $
��Left=�6$   $��	20,20,0,0q�6@   $	��132��6S   Phone Number6m   �� 5)      -   5        $��TboxPhoneNumber��5)   "   $
 True��69   $ Phone Number��6K   $
��Left=�6v   $��20,5,0,0q�6�   $	��320��6�   6�   �� 5+      $ 
Horizontal=�6%   .+�5,      �� $��	20,10,0,0q�6(   	Room Type6F   �� 5-      $��	95,10,0,0q�6(   Floor*6C   5.      �� 50      $ 
Horizontal=�6%   .+�51      �� -   5        $��TboxRoomType��51   &   $
 True��6:   $ 	Room Type��6L   $��20,5,0,0q�6u   $	��152��6�   6�   �� 52      -   5        $��	TboxFloor��52   &   $
 True��67   $ Floor��6I   $��15,5,0,0q�6m   $	��154��6   6�   53      �� 55      $
��Left=�6$   $��	20,20,0,0q�6@   $	��132��6S   Room#6f   �� 56      -   5        $��TboxRoom��56   "   $
 True��62   $ Room#��6D   $
��Left=�6h   $��20,5,0,0q�6�   $	��320��6�   6�   59      �� 5;      $��0,40,0,0q�6   $
��Todo��61   $��1��6?   .��5=      �� $ Vertical=�6%   .+�5>      �� $ 
Horizontal=�6)   .+�5?   "   �� $��	20,20,0,0q�6,   Breakfast [QTY]6P   �� 5@   "   $��	50,20,0,0q�6,   Lunch [QTY]6L   5A      �� 5C      $ 
Horizontal=�6)   .+�5D   "   �� -   5        $��TboxBreakfastQTY��5D   *   $
 True��6B   $ 	Breakfast��6T   $��20,5,0,0q�6|   $	��132��6�   6�   �� 5E   "   -	   5        $��TboxLunchQTY��5E   *   $
 True��6>   $ Lunch��6P   $��15,5,0,0q�6t   $	��149��6�   6�   5F      �� 5H      $
��Left=�6(   $��	20,20,0,0q�6D   $	��132��6W   Dinner [QTY]6q   �� 5I      -
   5        $��TboxDinnerQTY��5I   &   $
 True��6;   $ Dinner��6M   $
��Left=�6r   $��20,5,0,0q�6�   $	��297��6�   6�   �� 5K      $��0,30,0,0q�6)   $
��Left=�6;   $ 
Horizontal=�6V   .+�5L   "   �� -   5        $��checkBoxCleaning��5L   +   ${�False��6C   $��7,0,10,0q�6U   .��6g   
Cleaning6q   �� 5M   "   -   5        $��checkBoxTowels��5M   +   ${�False��6A   $��7,0,10,0q�6S   .��6e   Towels6m   �� 5N   "   -   5        $��checkBoxSweettestSurprise��5N   +   ${�False��6L   $��7,0,0,0q�6^   .��6o   Sweettest Surprise6�   5O      �� 5Q      -   5        $��checkBoxFoodSupplyStatus��5Q   '   $��Center=�6r   $��0,30,0,0q�6�   .��6�   Food/Supply status ?6�   �� 5S      -   5        $��btnChangeFoodSelection��5S   %   $��Center=�6_   $��30��6|   $��0,20,0,0q�6�   $
��Bold"�6�   
��� � �$	��287��6�   .��6�   Change Food Selection6�   5U      5W      �� 5Y      $��5,0,0,0q�6!   $ Vertical=�62   $��2��6I   .+�5[      �� $��0,0,0,10q�6$   $��20(�66   On the line6Q   �� 5\      -   5        $��lstOnTheLine��5\   5   $��	0,0,30,10q�6"   $	��310��6z   6�   �� 5]      -   5        $��btnUpdateChanges��5]   !   $��30��6O   $��	0,0,30,10q�6[   $
��Bold"�6n   
��� � �.��6�   Update Changes6�   5_      5`      5b      �� 5d      $��15(�6   $��	Over View��6$   .��5e      &   System.Windows.Controls.DataGrid  -   5        $��gridOverView��5e      $
��Left=�6/   $��10q�6J   $	��955��6V   $	��350��6b   6q   5f      5g      5i      5j      