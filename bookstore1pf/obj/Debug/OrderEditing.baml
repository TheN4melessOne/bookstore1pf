   M S B A M L   `   `   `  ����G  Cbookstore1pf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:bookstore1pfbookstore1pf  5          bookstore1pf.OrderEditing   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:bookstore1pf     5        N� Title$  OrderEditing��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   .+�5   
   �� $	��Top=�6   $��0��6-   .+�5      ��  �� Orientation$ 
Horizontal=�6   .+�5      &   System.Windows.Controls.DataGrid  -   5          Name$ 
OrderTable��5   2      SelectionMode$ Single=�6   $
��auto��6F   $��	0 0 20 20q�6T      AutoGenerateColumns .  $
��auto��6�      
IsReadOnly .    Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ ID заказа��6-   	   Width5  /System.Windows.Controls.DataGridLengthConverter$
	 Auto 6W   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6@   �� *id+6W     5      $ Дата��6-   $
	 Auto 6T   
 6;   �� *date+6T     5      $, &Пункт выдачи заказов��6-   $
	 Auto 6j   
 6K   �� *
orderPoint+6j     5      $ ID покупателя��6-   $
	 Auto 6c   
 6D   �� *
customerId+6c     5      $ Статус заказа��6-   $
	 Auto 6_   
 6D   �� *status+6_   5      �� 5      $
��auto��6   $��Right=�6*   $��20 0 0 0q�6F   .+�5      �� -   5         ��Name$ ComboPoints��5      $��0 0 0 10q�64   6H   �� 5      -   5        $ ComboStatuses��5      $��0 0 0 10q�66   6J   �� 5      -   5         ��Name$ 	EditOrder��5      $ ��Редактировать��60   $��0 0 0 10q�6`   6t   5      5       �� 5!      $ 
Horizontal=�6   $��1��62   .+�5"        -   5        $ OrderCompositionTable��5"   2   $ Single=�6   $
��auto��6Q    .   .  5#        5$      $4 .ID записи о составе заказа��6)   $
	 Auto 6d      
IsReadOnly . 
 6M   �� *id+6q     5%      $ ID заказа��6)   $
	 Auto 6X    . 
 6<   �� *	orderId+6e     5&      $! Название книги��6)   $
	 Auto 6A   
 6N   �� *
bookName+6m     5'      $ Количество��6)   $
	 Auto 6=   
 6J   �� *amount+6g   5)      �� 5+      $
��auto��6   $��20 0 0 0q�6&   .+�5,      �� -   5        $ 
ComboTitle��5,      $��0 0 0 10q�6/   6C   �� 5-      -   5         ��Name$ 	BoxAmount��5-      $��0 0 0 10q�6R   6f   �� 5.      -   5        $ EditComp��5.      $ ��Редактировать��6+   $��0 0 0 10q�6Z   6n   5/      50      51      �� 52   
   $ 
Horizontal=�6   $��Bottom=�6.   $��Center=�6I   $��1��6f   $��	0 20 0 20q�6s   .+�53      �� -	   5        $
 Save��53      $+��%Сохранить изменения��6#   $��0 0 10 0q�6T   6h   �� 54      -
   5        $ Delete��54      $��Удалить��6%   $��0 0 10 0q�6L   6`   �� 55      -   5        $ GoBack��55      $��
Назад��6%   $��0 0 10 0q�6J   6^   56      57      58      