   M S B A M L   `   `   `  ����  
VirtualPet    VirtualPet.MainWindow   5   	   W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	     � Title$  Virtuelles Haustier��5   	   $	��450��6%   $	��800��62   .��5      �  � RowDefinitions 5   
   �� 5      $
��Auto �6   �� 5      $��* �6   �� 5	      $
��Auto �6   .+�5   
   �� $��0��6   $��10q�6"   .+�5      �� -   5         ��Name$ 	NameLabel��5      $��24(�6+   5      �� 5   
   -   5         ��Name$ HaustierBild��5      $��1��6&   $��10q�63   $��img/bello.jpg��6?   �� 5   
   $��2��6    �� Orientation$ Vertical=�6"   $��10q�69   .+�5      �� $ 
Horizontal=�6   $��0,0,0,10q�62   .+�5      �� $��	Energie: ��6   �� 5      -   5        $ EnergieLabel��5      �� 5      $�� | Hunger: ��6   $
��10,0q�6/   �� 5      -   5        $ HungerLabel��5      �� 5      $�� | Stimmung: ��6   $
��10,0q�61   �� 5      -   5        $ StimmungLabel��5      �� 5      $�� | Gesundheit: ��6   $
��10,0q�63   �� 5      -   5        $ GesundheitLabel��5      5      �� 5      $ 
Horizontal=�6   .+�5      �� -   5         ��Name$ FutterButton��5      $��Füttern��6/   $	��100��6A   $��5q�6M   6X   �� 5       -   5        $ SchlafenButton��5       $��Schlafen��61   $	��100��6D   $��5q�6P   6[   �� 5!      -	   5        $ SpaziergangButton��5!      $��Spaziergang��64   $	��100��6J   $��5q�6V   6a   5"      5#      5$      5%      