   M S B A M L   `   `   `  ����G  Cbookstore1pf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:bookstore1pfbookstore1pf  5          bookstore1pf.tablePage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:bookstore1pf     5        N� Title$  	tablePage��5	      .��5      �  � RowDefinitions 5   
   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   �� 5      $
��auto �6   6,   .+�5   
   �� -   5         ��Name$ pageName��5      $��Каталог��6&   $��Center=�65   6T   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ 	mainTable��5       $��1��6   $	��300��63      AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�6n      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Название��6%   	   Width5  /System.Windows.Controls.DataGridLengthConverter$
	 Auto 6Q   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 67   �� *title+6Q     5      $ 
Автор��6%   $
	 Auto 6O   
 64   �� *author+6O     5      $ Описание��6%   $		 200 6W   
 67   �� *description+6W     5      $ Цена��6%   $
	 Auto 6M   
 63   �� *price+6M     5      $ Издательство��6%   $
	 Auto 6_   
 6;   �� *publishingHouse+6_     5      $ Год издания��6%   $
	 Auto 6^   
 6:   �� *publicationDate+6^   5      �� 5   
    �� Orientation$ 
Horizontal=�6   $��2��6.   $��Center=�6;   $��Center=�6X   $��0 20 0 0q�6s   .+�5      �� -   5         ��Name$ 
CartButton��5      $(��"Добавить в корзину��6)   $��0 0 30 0q�6_   6s   �� 5      -   5        $ Remove��5      $&�� Убрать из корзины��6%   $��0 0 30 0q�6W   6k   �� 5      -   5        $ GoToCart��5      $#��Открыть корзину��6'   $��0 0 30 0q�6X   6l   �� 5       -   5        $ CreateOrder��5       $!��Оформить заказ��6*   $��0 0 30 0q�6]   6q   �� 5!      -   5        $ ExitTheCart��5!      $,��&Вернуться к каталогу��6*   $��0 0 30 0q�6c   6w   �� 5"      -   5        $ GoBack��5"      $��
Назад��6%   6L   5#      5$      5%      