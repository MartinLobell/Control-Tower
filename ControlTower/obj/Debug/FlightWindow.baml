   M S B A M L   `   `   `  ����G  CControlTower, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:ControlTowerControlTower  5   	       ControlTower.FlightWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:ControlTower     5   	     � Title$  Flight��5   	   $	��450��6   $��471.238��6%   .��5	      �  � RowDefinitions 5
   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6    � ColumnDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��* �6   .+�5   
   �� -   5         ��Name$ planeImg��5      $��6��6"   $
��Left=�66   $	��308��6Q   $��	34,32,0,0q�6^   $��5��6q   $	��Top=�6�   $	��396��6�   �� 5   
   -   5         ��Name$ StartBtn��5      $��Start��6#   $
��Left=�63   $��10,25.6,0,0q�6N   $��5��6c   $	��Top=�6p   $��96��6�    J� RenderTransformOrigin$ 1.285,0.247&�6�   $��34��6�   6�   �� 5   
   -   5        $ LandBtn��5      $
��Land��6"   $
��Left=�61   $��10.2,25.6,0,0q�6L   $��5��6c   $	��Top=�6p   $��96��6�   $ 1.285,0.247&�6�   $��34��6�   $��3��6�   6�   �� 5   
   -   5         ��Name$ 	RouteList��5      $��1��6&   $
��Left=�66   $��34��6Q   $��10,25.6,0,0q�6]   $��5��6r   $	��Top=�6   $	��213��6�   $ 0.34,-0.652&�6�   $��2��6�   6�   5      5      