   M S B A M L   `   `   `  ����S  OprenoBUS_amministrazione, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:prenoBUS_amministrazioneprenoBUS_amministrazione  5   	   $    prenoBUS_amministrazione.WCrea   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   8local&clr-namespace:prenoBUS_amministrazione     5   	     � Title$  WCrea��5   	   $	��450��6   $	��800��6$    � WindowStartupLocation$ CenterScreen=�60    � 	Resources 5	         FocusVisual �� Property �� Value �� StrokeDashArray J� SnapsToDevicePixels  Button.Static.Background �� Color  Button.Static.Border  Button.MouseOver.Background  Button.MouseOver.Border  Button.Pressed.Background  Button.Pressed.Border  Button.Disabled.Background  Button.Disabled.Border 	 Button.Disabled.Foreground 
 rounded �� 
TargetType	 �� 
TargetType
 ��Name �� CornerRadius ��Name �� Triggers P� Property P� Value �� 
TargetName��%�  &	        &	 �     &	 �     &	 �     &	     &	 ?    &	 b    &	 �    &	 �    &		 �    &	
 �    7   7  7  7  7  7  7  7  7  7 	 �� 5
   
   .�5      ��  � �� 5      �� 5      .R�5      �� $��2q�6$   $	 1 2R�6/   $
 true��6E   $��1��6`   #��� ��6t   5      5      5      �� 5   
   $ 	#FFDDDDDD��6;   �� 5   
   $ 	#FF707070��67   �� 5   
   $ 	#FFBEE6FD��6>   �� 5   
   $ 	#FF3C7FB1��6:   �� 5   
   $ 	#FFC4E5F6��6<   �� 5   
   $ 	#FF2C628B��68   �� 5   
   $ 	#FFF4F4F4��6=   �� 5   
   $ 	#FFADB2B5��69   �� 5   
   $ 	#FF838383��6=   �� 5   
   " ��6    .�5      ��  �@�FocusVisualStyle8   61   �� 5       � ��8  6+   �� 5       � ��8  6,   �� 5        � ��# � ��6+   �� 5!       � ��$ 1q�60   �� 5"       � ��$ Center=�6;   �� 5#       � ��$ Center=�69   �� 5$       � ��$ 1q�6(   �� 5%       � �� 5&      �� 5'      "	 ��6&   .R�5(      �� $
 border��6!   $ 8��61   #��z��6B   #��z��6l   #��z��6�   $
 true��6�   ._�5)      �� $ contentPresenter��6/   $|�False��6I   #��z��6[   #��z��6�   $
��True��6�   # z 6�   #��z��6  5*       5+      P� 5,       �@��IsDefaulted$
 true��6=   . �5-   "   �� $ border��6@   # � ��6T    � ��5.      P� 5/       �@J�IsMouseOver$
 true��6=   . �50   "   �� $ border��6?   8   � ��6S   �� 51   "   $ border��6@   8   � ��6T   52      P� 53       � ��$
 true��6;   . �54   "   �� $ border��6?   8   � ��6S   �� 55   "   $ border��6@   8   � ��6T   56      P� 57       � {�$ false��6;   . �58   "   �� $ border��6?   8   � ��6S   �� 59   "   $ border��6@   8   � ��6T   �� 5:   "   $ contentPresenter��6K   8 	  � ��6i   5;      5=      5?      5@      5A      .��5B      � .+�5C   
   �� $��Center=�6   $	��434��6.   $��Center=�6;   $	��800��6V   ��5D      �� 5E       �� EndPoint$ 0.5,1&�6&    �� 
StartPoint$ 0.5,0&�67   .��5F      �  � Color$ 	#FF289EFF��6#    � Offset$ 0Q�65   � 5G      $ 	#FF20E3FF��6#   $ 1Q�65   5H      .+�5J      �� $	��246��6    �� Left$	 125��6"   
 �� Top$	 100��64   $	��547��6E   
������� K� ZIndex$	 100��6d   .+�5K      �� -   5         ��Name$ username��5K      $��30��6,   $	 154��68    �� TextWrapping$
 Wrap=�6J   $ 51��6^   $	��238��6n   ���	#FF8B8B8B$��2q�6�    �� TextAlignment$ Center=�6�   $��Verdana)�6�   $��0,5,0,0q�6�   $��Username��6�   ��6�   Z� 6+  �� 5L      -   5        $ password��5L      $��30��6,   $	 154��68   $
 Wrap=�6J   $ 99��6^   $	��238��6n   ���	#FF8B8B8B$��2q�6�   $ Center=�6�   $��Verdana)�6�   $��0,5,0,0q�6�   $��Password��6�   ��6�   Z� 6+  �� 5M      -   5         ��Name$ btnCrea��5M      $��CREA ACCOUNT��6*   $	 154��6A   $	 154��6S   $	��238��6d   $��32��6p   ���	#FF2A9FFF$��Verdana)�6�   $��15(�6�   
�������#��� 
 6�   6�   5N      �� 5O      $��Inserisci credenziali��6   $	 295��64   $ 59��6F   $��36��6V   $	��244��6b   
�������$��Verdana)�6�   $��20(�6�   �� 5P      -   5        $ btnEsci��5P      $'��!Torna alla
schermata
principale��6&   $	 635��6b   $	 360��6t   $	��148��6�   $��60��6�   ���	#FFFF4D4D#��� 
 6�   $��Verdana)�6�   $��15(�6�    � Cursor$
 Hand��6�   6  5Q      5R      5S      