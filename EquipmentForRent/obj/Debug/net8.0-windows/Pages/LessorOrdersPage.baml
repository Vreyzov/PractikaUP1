   M S B A M L   `   `   `  ����K  GEquipmentForRent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:EquipmentForRent.PagesEquipmentForRent.Pages  5      -    'EquipmentForRent.Pages.LessorOrdersPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:EquipmentForRent.Pages     5        N� Title$  LessorOrdersPage��5	      .��5      � ��5   
   �� 5       �� ImageSource$f `https://img.freepik.com/premium-vector/white-backdrop-beautiful-abstract-background_36991-16.jpg��6    j� Stretch$ UniformToFill=�5   	   .+�5   
   �� $��Мои заказы��6   $��16(�6&   $
��Bold"�64   $��Center=�6F   $	��Top=�6c   $��0,10,0,0q�6{   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ OrdersDataGrid��5         AutoGenerateColumns$ False��6+   $��Stretch=�6G   $	��Top=�6e   $��10,70,10,120q�6}      SelectionMode$ Single=�5         CanUserAddRows$ False��6"      CanUserDeleteRows$ False��69      CanUserSortColumns$
 True��6S   	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Клиент��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 65   �� *
ClientName+6T     5      $
 Оборудование��6%   $ * 6]    6;   �� *EquipmentName+6]     5      $
 Начало аренды��6%   $ * 6Z    6<   �� *	StartDate+6Z     5      $
 Конец аренды��6%   $ * 6W    6;   �� *	EndDate+6W     5      $)
 #Итоговая стоимость��6%   $ * 6_    6A   �� *	TotalCost+6_   5      �� 5    
    �� Orientation$ 
Horizontal=�6   $	��Top=�6.   $
��Left=�6F   $��168,355,0,0q�6a   $	��460��6v   .+�5!      �� -   5        $��
Назад��5!      $��82��6>   $��5q�6I   �� 5"      -   5        $'��!Удалить выбранное��5"      $	��181��6L   $��5q�6X   �� 5#      -   5        $'��!Печать выбранного��5#      $	��172��6K   $��5q�6W   5$      5%      5&      