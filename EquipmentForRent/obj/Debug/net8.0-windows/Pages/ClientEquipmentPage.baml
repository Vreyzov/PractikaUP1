   M S B A M L   `   `   `  ����K  GEquipmentForRent, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:EquipmentForRent.PagesEquipmentForRent.Pages  5      0    *EquipmentForRent.Pages.ClientEquipmentPage   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      6local$clr-namespace:EquipmentForRent.Pages     5        N� Title$  ClientEquipmentPage��5	      .��5      � ��5   
   �� 5       �� ImageSource$f `https://img.freepik.com/premium-vector/white-backdrop-beautiful-abstract-background_36991-16.jpg��6    j� Stretch$ UniformToFill=�5   	   .+�5   
   �� $��24(�6   $
��Bold"�6"   $��Center=�64   $��10,20,10,10q�6Q   -+Доступное оборудование5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ EquipmentDataGrid��5         AutoGenerateColumns$ False��6.   $��Stretch=�6J   $	��Top=�6h   $��10,70,10,120q�6�      SelectionMode$ Single=�5         CanUserAddRows$ False��6*      CanUserDeleteRows$ False��6A      CanUserSortColumns$
 True��6[   	   Columns	 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn
   Header$
 Оборудование��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6T   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6;   �� *Name+6T     5      $
 Цена за день��6%   $ * 6l    6;   �� *PricePerDay+ �� StringFormat$ C2��6l     5      $)
 #Номер арендодателя��6%   $ * 6^    6A   �� *
LessorId+6^   5      �� 5"   
   -   5        $!��Оформить заказ��5"      $��Right=�6*   $��Bottom=�6F   $��10,10,10,20q�6a   $	��173��6v   5#      �� 5&   
   -   5        $��
Назад��5&      $
��Left=�6!   $��Bottom=�6<   $��10,10,10,20q�6W   $	��100��6l   5'      5(      5)      