   M S B A M L   `   `   `  ����G  Cbookstore1pf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:bookstore1pfbookstore1pf  5          bookstore1pf.OrderPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      ,localclr-namespace:bookstore1pf     5        N� Title$  	OrderPage��5	      .��5      �  � ColumnDefinitions 5   
   �� 5      $
��Auto �6   6.   �� 5      $
��Auto �6   6.   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ 	mainTable��5   5   $��10 0 0 0q�6   $��0��6%   $	��300��6H      AutoGenerateColumns .     
IsReadOnly .    SelectionMode$ Single=�6�      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Название��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6Q   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 67   �� *title+6Q     5      $ 
Автор��6%   $
 Auto 6O   	 64   �� *author+6O     5      $ Описание��6%   $	 100 6W   	 67   �� *description+6W     5      $ Цена��6%   $
 Auto 6M   	 63   �� *price+6M     5      $ Издательство��6%   $
 Auto 6_   	 6;   �� *publishingHouse+6_     5      $ Год издания��6%   $
 Auto 6^   	 6:   �� *publicationDate+6^   5      �� 5   
   $��Center=�6   $��1��60   $��20 0 0 0q�6@   .+�5      �� $=��7Выберите пункт выдачи заказов��6   6?   �� 5      -   5        
 ��Name$
 
ComboPoint��5      $��0 0 0 10q�6+   6?   �� 5       �� Orientation$ 
Horizontal=�6   $��0 0 0 10q�62   .+�5      �� $��Итого: ��6   6-   �� 5      -   5         ��Name$ SumBlock��5      60   5       �� 5!      -   5         ��Name$ 
CartButton��5!      $(��"Добавить в корзину��6)   $��0 0 0 10q�6_   6s   �� 5"      -   5        $ Remove��5"      $&�� Убрать из корзины��6%   $��0 0 0 10q�6W   6k   �� 5#      -   5        $ CreateOrder��5#      $!��Оформить заказ��6*   $��0 0 0 10q�6]   6q   �� 5$      -   5        $ GoBack��5$      $��
Выйти��6%   6L   5%      5&      5'      