   M S B A M L   `   `   `  ����I  ESection8System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Section8SystemSection8System  5   7   '    !Section8System.ctlInputModify_GUI   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +myclr-namespace:Section8System     5   7   .��5      �   � RowDefinitions  5	   
   �� 5
      �� 5      �� 5      �� 5      $��30 �6   .+�5   
   � $��0��6    � ColumnDefinitions 5      �� 5      $
��289* �6#   �� 5      $
��129* �6#   �� 5      $	��125 �6#   .+�5      0   *Section8System.ctlInputModify_LocationInfo  -   5          Name$" CtlInputModify_LocationInfo1��5   [   $��0��6-   $��Stretch=�6=   $��5q�6�   $��Stretch=�6�   
���   �6�   ,   &Section8System.ctlInputModify_UnitType  5      -   5          Name$ CtlInputModify_UnitType1��5   W   $��1��6)   $��Stretch=�69   $��5q�6y   $��Stretch=�6�   
���   �$��1q�6�   �� 5      $��2��6   
������ 
���   �$��1q�6R   $��5q�6f   ._�5      �� -   5        $��StackPanel1��5   K   $��2��6   $��Stretch=�6-   $��Stretch=�6^   .+�5      �� -   5        $��lblRecordLockStatus��5   @   $��Record Locked��6   $��28��64   $��Center=�6[   �� 5      -   5        $��btnUnlockRecord��5   F   $��Unlock this record��6   $��23��6:   $	��110��6]   $��	0,10,0,10q�6i   �� 5      -   5        $��btnAddNewRecord��5   B   $��Add new record��6   $��23��66   $	��110��6Y   5      5      5      � 5!   
   $��1��6    5"      �� 5#      �� 5$      �� 5%      �� 5&        5(      �� 5)      $��30 �6    �� 5*      .+�5,      �� -   5        $��Label1��5,   a   $��
Ammenities��6   $��0��6)   $��0��66   $
��Left=�6F   $	��Top=�6o   &   System.Windows.Controls.DataGrid  5-      -   5        $��dgAmmenities��5-         AutoGenerateColumns .  $��0��63   $��1��6C   $��Stretch=�6P   $��5,0,5,0q�6n   $��Stretch=�6�      HeadersVisibility$
 None=�6�   �� 5.      -	   5        $��Label2��5.   a   $��
Facilities��6   $��0��6)   $��1��66   $
��Left=�6F   $	��Top=�6o     5/      -
   5        $��dgFacilities��5/       .  $��1��63   $��1��6C   $��Stretch=�6P   $��5,0,5,0q�6n   $��Stretch=�6�   $
 None=�6�   �� 50      -   5        $��Label3��50   Y   $��2��6   $��Accessibilities��6$   $
��Left=�6>   $	��Top=�6g     51      -   5        $��dgAccessibilites��51   m   $��2��6   $��1��6'    . $��Stretch=�6O   $��Stretch=�6�   $
 None=�6�   �� 52      -   5        $��Label4��52   j   $��Management Services��6   $��0��62   $��3��6?   $
��Left=�6O   $	��Top=�6x     53      -   5        $��dgManagement��53       .  $��3��63   $��1��6C   $��Stretch=�6P   $��5,0,5,0q�6n   $��Stretch=�6�   $
 None=�6�   54      � 56   
   $��2��6    57      �� 58      $
��286* �6#   �� 59      $
��282* �6#   �� 5:      $
��182* �6#     5<      �� 5=      $��20 �6    �� 5>      .+�5A      �� -   5        $��Label5��5A   O   $��	Utilities��6   $��28��6(   $
��Left=�64   $��Center=�6]   $
��Bold"�6x   -   'Section8System.ctlInputModify_Utilities  5B      -   5          Name$ CtlInputModify_Utilities1��5B   q   $��0��6*   $��1��6:   $��Stretch=�6G   $��5q�6e   $��Stretch=�6�   
���   �$��1q�6�   �� 5D      -   5        $��Label6��5D   d   $��Points Summary��6   $��1��6-   $��28��6=   $
��Left=�6I   $��Center=�6r   $
��Bold"�6�   1   +Section8System.ctlInputModify_PointsSummary  5E      -   5          Name$# CtlInputModify_PointsSummary1��5E   t   $��1��6.   $��1��6>   $��Stretch=�6K   $��5q�6i   $��Stretch=�6�   $��1q�6�   
���   �6�   �� 5F      $��2��6   $��1��6%   
������ 
���   �$��1q�6_   $��5q�6s   ._�5G      �� -   5        $��StackPanel2��5G   X   $��1��6   $��2��6*   $��Stretch=�6:   $��Stretch=�6k   .+�5H      �� -   5        $��	btnRecalc��5H   ;   $��Re-Calc��6   $��23��6/   $��75��6L   $��0,5,0,5q�6W   �� 5I      -   5        $��
btnCompare��5I   ;   $��Compare��6   $��23��6/   $��75��6M   $��0,5,0,5q�6X   �� 5J      -   5        $��btnCloseForm��5J   >   $��
Close Form��6   $��23��62   $��75��6R   $��0,5,0,5q�6]   5K      5L      5M      �� 5O   
   -   5        $��StackPanel3��5O   @   $��3��6   $��Stretch=�6"   $��Stretch=�6S    �� Orientation$ 
Horizontal=�6o   .+�5P      �� -   5        $��Label7��5P   2   $��Record:��6   $��28��6&   62   �� 5Q      -   5        $��imgMoveFirst��5Q       $��25��6   $
��Fill=�64   $��25��6C   $��5,0,5,0q�6N   $Q��K/Section8System;component/Presentation%20Layer/Images/arrow-left-double.png��6_   �� 5R      -   5        $��imgMoveBack��5R       $��25��6   $
��Fill=�63   $��25��6B   $��5,0,5,0q�6M   $J��D/Section8System;component/Presentation%20Layer/Images/arrow-left.png��6^   �� 5S      -   5        $��txtRecordNumber��5S   "   $��23��6   $��60��69   $��5,0,5,0q�6D   �� 5T      -   5        $��imgMoveNext��5T       $��25��6   $
��Fill=�63   $��25��6B   $��5,0,5,0q�6M   $K��E/Section8System;component/Presentation%20Layer/Images/arrow-right.png��6^   �� 5U      -   5        $��imgMoveLast��5U       $��25��6   $
��Fill=�63   $��25��6B   $��5,0,5,0q�6M   $R��L/Section8System;component/Presentation%20Layer/Images/arrow-right-double.png��6^   �� 5V      -   5        $��lblRecordCount��5V   /   $
��of 1��6   $��28��6#   6/   5W      5X      5Y      