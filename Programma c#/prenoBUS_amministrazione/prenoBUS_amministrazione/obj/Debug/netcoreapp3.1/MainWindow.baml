   M S B A M L   `   `   `  ����S  OprenoBUS_amministrazione, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:prenoBUS_amministrazioneprenoBUS_amministrazione  5   	   )    #prenoBUS_amministrazione.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:prenoBUS_amministrazione     5   	     � Title$  
MainWindow��5   	   $	��450��6   $	��800��6)    � WindowStartupLocation$ CenterScreen=�65    � 	Resources 5	         Button.MouseOver.Background �� Color  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border  Button.Disabled.Foreground  rounded �� 
TargetType ��Name �� CornerRadius J� SnapsToDevicePixels ��Name	 �� Triggers
 P� Property P� Value �� 
TargetName �� Value �� Property��%�  &	        &	 #     &	 F     &	 i     &	 �     &	 �     &	 �     &	 �     7   7  7  7  7  7  7  �� 5
   
   $ 	#FFBEE6FD��6>   �� 5   
   $ 	#FF3C7FB1��6:   �� 5   
   $ 	#FFC4E5F6��6<   �� 5   
   $ 	#FF2C628B��68   �� 5   
   $ 	#FFF4F4F4��6=   �� 5   
   $ 	#FFADB2B5��69   �� 5   
   $ 	#FF838383��6=   �� 5   
   " ��6*   .R�5      �� $ border��6   $ 8��6%   #��z��66   #��z��6`   #��z��6�   $
 true��6�   ._�5      �� $ contentPresenter��6#   $|�False��6=   #��z��6O   #��z��6�   $
��True��6�   # z 6�   #��z��6  5      	 5      P� 5      
 �@��IsDefaulted$
 true��68   . �5      �� $ border��64   # � ��6H    � ��5      P� 5      
 �@J�IsMouseOver$
 true��61   . �5      �� $ border��63   8    � ��6G   �� 5      $ border��64   8   � ��6H   5      P� 5      
 � ��$
 true��6/   . �5      �� $ border��63   8   � ��6G   �� 5      $ border��64   8   � ��6H   5       P� 5!      
 � {�$ false��6/   . �5"      �� $ border��63   8   � ��6G   �� 5#      $ border��64   8   � ��6H   �� 5$      $ contentPresenter��6?   8   � ��6]   5%      5'      5(      .��5)      � .+�5*   
   �� $��Center=�6   $	��434��6.   $��Center=�6;   $	��800��6V   ��5+      �� 5,       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5-      �  � Color$ 	#FF289EFF��6#    � Offset$ 0Q�65   � 5.      $ 	#FF20E3FF��6#   $ 1Q�65   5/      .+�51      �� $	��246��6    �� Left$	 125��6"   
 �� Top$	 100��64   $	��547��6E   
������� K� ZIndex$	 100��6d   .+�52      �� -   5         ��Name$ btnCrea��52   >   #���  6   $��CREA PROFILO
CONDUCENTE��6O   $ 37��6z   $ 74��6�   $	��207��6�   $��98��6�   ���	#FF2A9FFF$��Verdana)�6�   $��15(�6�   
�������6  �� 53      -   5        $ 
btnElimina��53   >   #���  6   $$��ELIMINA PROFILO
   CONDUCENTE��6R   $	 303��6�   $ 74��6�   $	��207��6�   $��98��6�   ���	#FF2A9FFF$��Verdana)�6�   $��15(�6�   
�������6
  54      �� 55      $��Bentornato!��6   $	 323��6*   $ 59��6<   $��36��6L   $	��163��6X   
�������$��Verdana)�6w   $��20(�6�   56      58      59      