   M S B A M L   `   `   `  ����N  JWpfPageTransitions, Version=40.0.0.1, Culture=neutral, PublicKeyToken=nullS<clr-namespace:WpfPageTransitions;assembly=WpfPageTransitionsWpfPageTransitions  5      I ESection8System, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:Section8SystemSection8System 5   7   !   Section8System.ctlDashboard   5      Dmy1<clr-namespace:WpfPageTransitions;assembly=WpfPageTransitions  \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      +myclr-namespace:Section8System     5   7   
�������.��5	      �   � RowDefinitions  5
   
   �� 5      $��50 �6   �� 5       � ColumnDefinitions 5   
   �� 5      �� 5      .+�5   
   �� .+�5      �� -   5        $��lblTitle��5      $��COUNTY-HERE��5      $
��Left=�6*   $��0,0,0,0q�6E   $��Center=�5       
����  �$��16(�6M   $��Arial)�6[   �� 5      -   5        $��lblDate��5      $��Today��5      $
��Left=�6$   $��0,0,0,0q�6?   $��Center=�5      
����  �$��12(�6L   $��Arial)�6Z   5      �� 5   
   -   5        $��
Rectangle1��5   t   $��0��6   $��0��6$   $��2��61   $��Stretch=�6E   $��0,0,0,0q�6c   
���   �$��Bottom=�5      $��2��6/   
���   �6:   �� 5   
   $��1��6   $��0��6%    �� Orientation$ 
Horizontal=�62   $��Right=�6K   .+�5      �� -   5        $��imgExit��5   A   $��Right=�6   $��0,0,0,0q�60   $
��Fill=�6P   $��Center=�6_   $��25��6z   $��25��6�   $P��J/Section8System;component/Presentation%20Layer/Images/system-log-out-3.png��6�   �� 5      -   5        $��lblExit��5   O   $
��Exit��6   $
��Left=�6#   $��0,0,0,0q�6>   $��Center=�6^   $��Arial)�6y   5      � 5    
   $��1��6   $��0��6   $��2��6,    5!      �� 5"      $	��200 �6#   �� 5#      .+�5%      �� $��0��6   $��0��6)   .+�5&      #  Section8System.ctlContentItem  -   5          Name$ Item_InputModify��5&   $   $��10q�6>      ContentHeader$ Input/Modify Unit(s)��6J   $��50��6o      	ItemImage$O I/Section8System;component/Presentation%20Layer/Images/document-open-8.png��6{     5'      -   5        $ Item_UnitRecertification��5'   $   $��10q�6F   $ Unit Recertification List��6R   $��50��6|   $O I/Section8System;component/Presentation%20Layer/Images/bookmark-folder.png��6�     5(      -   5        $ Item_SystemMaintenance��5(   $   $��10q�6D   $ System Maintenance��6P   $��50��6s   $M G/Section8System;component/Presentation%20Layer/Images/system-run-31.png��6   5)      '   !WpfPageTransitions.PageTransition  5*      -	   5        $��pgPlugin��5*   I   $��0��6!   $��1��6.   $��5q�6>   6I   5+      5,      5-      