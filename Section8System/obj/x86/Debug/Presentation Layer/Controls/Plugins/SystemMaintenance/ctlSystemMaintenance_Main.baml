   M S B A M L   `   `   `  ����I  ESection8System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null.    (Section8System.ctlSystemMaintenance_Main   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      .��5      �   � ColumnDefinitions  5	   
   �� 5
      $	��450 �6   �� 5       � RowDefinitions 5   
   �� 5      $��40 �6   �� 5      .+�5   
   �� -   5        $��StackPanel1��5   K   $��0��6   $��Stretch=�6"   $��5q�6@   $��Stretch=�6^    �� Orientation$ 
Horizontal=�6z   .+�5      �� -   5        $��Label1��5   5   $��
Type Code:��6   $��28��6)   65   �� 5      -   5        $��cmbTypeCode��5   #   $��23��6   $	��200��66   �� 5      -   5        $��txtAddNewValue��5   a   $��1��6   $��0��6%   $
��Left=�65   $��5,0,0,0q�6P   $��Add New Type Code Value��6w   $��Center=�5      
����  �6/   5      �� 5   
   -   5        $��
imgRefresh��5   V   $��0��6   $��1��6   $��20��6.   $��Right=�6:   $
��Fill=�6h   $��Center=�6w   $��20��6�   $��0,0,10,0q�6�   $9��3/Section8System;component/Images/view-refresh-7.png��6�   &   System.Windows.Controls.DataGrid  5   
   -   5        $��
dgTypeCode��5   �      AutoGenerateColumns .  $��1��6/   $��0��6<   $��2��6L   $��Stretch=�6`   $��10q�6~   $��Stretch=�6�      
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Description��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 200 6:   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6F   �� 6\     5      $ Points��6%   $
 200* 65   6D   5      5      5      