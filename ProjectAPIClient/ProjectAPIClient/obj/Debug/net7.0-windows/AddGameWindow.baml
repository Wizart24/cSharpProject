   M S B A M L   `   `   `  ����K  GProjectAPIClient, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:ProjectAPIClientProjectAPIClient  5   	   $    ProjectAPIClient.AddGameWindow   5   	   W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:ProjectAPIClient     5   	     � Title$  Add Game��5   	   $	��475��6   $	��400��6'   ���	#FF132E32.��5	      � .+�5
   
   �� -   5         ��Name$ txtTitle��5
       �� TextAlignment$
 Left=�6$   $��Center=�69   $
��Left=�6[   $��
160,77,0,0q�6v    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��189��6�   $��25��6�   $��Yu Gothic Light)�6�   $��14(�6�   �� 5   
   -   5         ��Name$ lblTitle��5      $��Title:��6"   $
��Left=�63   $��
100,73,0,0q�6N   $	��Top=�6b   $��14(�6z   $��Yu Gothic Light)�6�   ���	#FFFDFCFC6�   �� 5   
   -   5        $ txtGenre��5      $
 Left=�6$   $��Center=�69   $
��Left=�6[   $��160,126,0,0q�6v   $
 Wrap=�6�   $	��Top=�6�   $	��189��6�   $��25��6�   $��Yu Gothic Light)�6�   $��14(�6�   �� 5   
   -   5        $ lblGenre��5      $��Genre:��6"   $
��Left=�63   $��
90,122,0,0q�6N   $	��Top=�6b   $��14(�6z   $��Yu Gothic Light)�6�   ���	#FFFDFCFC6�   �� 5   
   -   5        $ txtYear��5      $
 Left=�6#   $��Center=�68   $
��Left=�6Z   $��160,178,0,0q�6u   $
 Wrap=�6�   $	��Top=�6�   $	��189��6�   $��25��6�   $��Yu Gothic Light)�6�   $��14(�6�   �� 5   
   -   5        $ lblYear��5      $��Realease Year:��6!   $
��Left=�6:   $��
42,174,0,0q�6U   $	��Top=�6i   $��14(�6�   $��Yu Gothic Light)�6�   ���	#FFFDFCFC6�   �� 5   
   -   5        $ txtPublisher��5      $
 Left=�6(   $��Center=�6=   $
��Left=�6_   $��159,230,0,0q�6z   $
 Wrap=�6�   $	��Top=�6�   $	��189��6�   $��25��6�   $��Yu Gothic Light)�6�   $��14(�6�   �� 5   
   -   5        $ lblPublisher��5      $��Game Publisher:��6&   $
��Left=�6@   $��
30,226,0,0q�6[   $	��Top=�6o   $��14(�6�   $��Yu Gothic Light)�6�   ���	#FFFDFCFC6�   �� 5   
   -	   5        $ txtPrice��5      $
 Left=�6$   $��Center=�69   $
��Left=�6[   $��159,280,0,0q�6v   $
 Wrap=�6�   $	��Top=�6�   $	��189��6�   $��25��6�   $��Yu Gothic Light)�6�   $��14(�6�   �� 5   
   -
   5        $ lblPrice��5      $��Game Price:��6"   $
��Left=�68   $��
56,276,0,0q�6S   $	��Top=�6g   $��14(�6   $��Yu Gothic Light)�6�   ���	#FFFDFCFC6�   �� 5   
   -   5        $ 	lblStatus��5      $��	In Stock:��6#   $
��Left=�67   $��
77,324,0,0q�6R   $	��Top=�6f   $��14(�6~   $��Yu Gothic Light)�6�   ���	#FFFDFCFC6�   �� 5   
   -   5         ��Name$ txtTitl��5      $��Center=�6%   $��0,20,0,0q�6B   $
��Wrap=�6T   $��Add Game��6h   $	��Top=�6x   $��Yu Gothic Light)�6�   $��24(�6�   
�������6�   �� 5   
   -   5         ��Name$ btnAdd��5      $��Add Game��6!   $
��Left=�64   $��200,386,0,0q�6O   $	��Top=�6d   $	��148��6|   $��32��6�   ���	#FF132E32���	#FFFDFDFD���	#FFFDF9F96�   �� 5   
   -   5         ��Name$ chStatus��5      $
��Left=�6%   $��160,333,0,0q�6@   $	��Top=�6U   5      5      