   M S B A M L   `   `   `  ����G  CTowerDefense, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:TowerDefenseTowerDefense  5   	       TowerDefense.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:TowerDefense     5   	   V RXamlAnimatedGif, Version=2.0.0.0, Culture=neutral, PublicKeyToken=20a987d8023d9690<gif2https://github.com/XamlAnimatedGif/XamlAnimatedGif  5   	   -   5          � Title$  
MainWindow��5	   	   $	��600��6   $
��1100��6)    � 
ResizeMode$ NoResize=�6O    � WindowStyle$ 
ToolWindow=�6e   .��5
      � -   5         �Name$ MyGrid��5
      ��5   
   �� 5       �� ImageSource$ BG.png��6   .+�5   
   �� -   5        $
��canv��5   9   $��-22,10,-23,46q�6"    K� ZIndex$ 10��6E    J� 	AllowDrop$
 True��6W   .+�5      �� -   5        $	��bow��5      $��95��6   $��
 /bowm.png��6+   
 �� Top$	 426��6\    �� Left$ 33��6m   $��Center=�6~   $	��Top=�6�   �� 5      -   5        $	��wiz��5      $��95��6   $	 147��6+   $��/wiz.jpg��6=   $	 426��6l   $��Center=�6}   $	��Top=�6�   5      �� 5   
   -   5        	 ��Name$	 place1��5      $��0q�6!   $��1��65   $y�Hidden=�6A   $
��Left=�6U   $��False��6p   $��247,197,0,0q�6�   $	��Top=�6�   $��95��6�   $��95��6�   6�   �� 5   
   -   5        $	 place2��5      $��2��6!   $y�Hidden=�6-   $
��Left=�6A   $��False��6\   $��455,245,0,0q�6n   $	��Top=�6�   $��95��6�   $��95��6�   6�   �� 5   
   -   5        $	 place3��5      $��3��6!   $y�Hidden=�6-   $
��Left=�6A   $��False��6\   $��850,388,0,0q�6n   $	��Top=�6�   $��95��6�   $��95��6�   6�   �� 5   
   -	   5        $	 place4��5      $y�Hidden=�6!   $��4��65   $
��Left=�6A   $��False��6\   $��662,431,0,0q�6n   $	��Top=�6�   $��95��6�   $��95��6�   6�   �� 5   
   -
   5        $	 place5��5      $y�Hidden=�6!   $��5��65   $
��Left=�6A   $��False��6\   $��662,431,0,0q�6n   $	��Top=�6�   $��95��6�   $��95��6�   6�   �� 5   
   -   5        $	 place6��5      $y�Hidden=�6!   $��6��65   $
��Left=�6A   $��False��6\   $��662,431,0,0q�6n   $	��Top=�6�   $��95��6�   $��95��6�   6�   �� 5   
   -   5        $	 place7��5      $y�Hidden=�6!   $��7��65   $
��Left=�6A   $��False��6\   $��662,431,0,0q�6n   $	��Top=�6�   $��95��6�   $��95��6�   6�   �� 5   
   -   5        $	 place8��5      $y�Hidden=�6!   $��8��65   $
��Left=�6A   $��False��6\   $��662,431,0,0q�6n   $	��Top=�6�   $��95��6�   $��95��6�   6�   �� 5   
   -   5        $	 place9��5      $y�Hidden=�6!   $��9��65   $
��Left=�6A   $��False��6\   $��662,431,0,0q�6n   $	��Top=�6�   $��95��6�   $��95��6�   6�   �� 5   
   -   5        $	 place10��5      $y�Hidden=�6"   $��10��66   $
��Left=�6C   $��False��6^   $��662,431,0,0q�6p   $	��Top=�6�   $��95��6�   $��95��6�   6�   �� 5   
   -   5        $	 place11��5      $y�Hidden=�6"   $��11��66   $
��Left=�6C   $��False��6^   $��662,431,0,0q�6p   $	��Top=�6�   $��95��6�   $��95��6�   6�   �� 5   
   -   5        $	 place12��5      $y�Hidden=�6"   $��12��66   $
��Left=�6C   $��False��6^   $��662,431,0,0q�6p   $	��Top=�6�   $��95��6�   $��95��6�   6�   �� 5   
   -   5        $	 place13��5      $y�Hidden=�6"   $��13��66   $
��Left=�6C   $��False��6^   $��662,431,0,0q�6p   $	��Top=�6�   $��95��6�   $��95��6�   6�   �� 5   
   -   5        $	 place14��5      $y�Hidden=�6"   $��14��66   $
��Left=�6C   $��False��6^   $��662,431,0,0q�6p   $	��Top=�6�   $��95��6�   $��95��6�   6�   �� 5    
   -   5        $	 place15��5       $y�Hidden=�6"   $��15��66   $
��Left=�6C   $��False��6^   $��662,431,0,0q�6p   $	��Top=�6�   $��95��6�   $��95��6�   6�   �� 5!   
   -   5        $	 place16��5!      $y�Hidden=�6"   $��16��66   $
��Left=�6C   $��False��6^   $��662,431,0,0q�6p   $	��Top=�6�   $��95��6�   $��95��6�   6�   �� 5"   
   -   5        $	 place17��5"      $y�Hidden=�6"   $��17��66   $
��Left=�6C   $��False��6^   $��662,431,0,0q�6p   $	��Top=�6�   $��95��6�   $��95��6�   6�   �� 5#   
   -   5        $	 place18��5#      $y�Hidden=�6"   $��18��66   $
��Left=�6C   $��False��6^   $��662,431,0,0q�6p   $	��Top=�6�   $��95��6�   $��95��6�   6�   �� 5$   
   -   5        $	 place19��5$      $y�Hidden=�6"   $��19��66   $
��Left=�6C   $��False��6^   $��662,431,0,0q�6p   $	��Top=�6�   $��95��6�   $��95��6�   6�   �� 5%   
   -   5        $	 place20��5%      $y�Hidden=�6"   $��20��66   $
��Left=�6C   $��False��6^   $��662,431,0,0q�6p   $	��Top=�6�   $��95��6�   $��95��6�   6�   �� 5&   
   -   5        $	 place21��5&      $y�Hidden=�6"   $��21��66   $
��Left=�6C   $��False��6^   $��662,431,0,0q�6p   $	��Top=�6�   $��95��6�   $��95��6�   6�   �� 5'   
   -   5        $	 place22��5'      $y�Hidden=�6"   $��22��66   $
��Left=�6C   $��False��6^   $��662,431,0,0q�6p   $	��Top=�6�   $��95��6�   $��95��6�   6�   �� 5(   
   -   5        $	 place23��5(      $y�Hidden=�6"   $��23��66   $
��Left=�6C   $��False��6^   $��662,431,0,0q�6p   $	��Top=�6�   $��95��6�   $��95��6�   6�   �� 5)   
   -   5        $	 place24��5)      $y�Hidden=�6"   $��24��66   $
��Left=�6C   $��False��6^   $��662,431,0,0q�6p   $	��Top=�6�   $��95��6�   $��95��6�   6�   �� 5*   
   -   5        $	 place25��5*      $y�Hidden=�6"   $��25��66   $
��Left=�6C   $��False��6^   $��662,431,0,0q�6p   $	��Top=�6�   $��95��6�   $��95��6�   6�   �� 5+   
   -   5        $	 place26��5+      $y�Hidden=�6"   $��26��66   $
��Left=�6C   $��False��6^   $��662,431,0,0q�6p   $	��Top=�6�   $��95��6�   $��95��6�   6�   �� 5,   
   -    5        $	 place27��5,      $y�Hidden=�6"   $��27��66   $
��Left=�6C   $��False��6^   $��662,431,0,0q�6p   $	��Top=�6�   $��95��6�   $��95��6�   6�   �� 5-   
   -!   5        $	 place28��5-      $y�Hidden=�6"   $��28��66   $
��Left=�6C   $��False��6^   $��662,431,0,0q�6p   $	��Top=�6�   $��95��6�   $��95��6�   6�   �� 5.   
   -"   5        $	 place29��5.      $y�Hidden=�6"   $��29��66   $
��Left=�6C   $��False��6^   $��662,431,0,0q�6p   $	��Top=�6�   $��95��6�   $��95��6�   6�   �� 5/   
   -#   5        $	 place30��5/      $y�Hidden=�6"   $��30��66   $
��Left=�6C   $��False��6^   $��662,431,0,0q�6p   $	��Top=�6�   $��95��6�   $��95��6�   6�   A� 50   
   -$   5        
 A�Name$
 e1��50      $y�Hidden=�6   $
��Left=�62   $	��350��6M   $��
119,71,0,0q�6Z   
���   �$	��Top=�6}   $	��350��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�    J� Opacity$	 0.1Q�6�   A� 51   
   -%   5        $
 e2��51      $y�Hidden=�6   $
��Left=�62   $	��350��6M   $��
119,71,0,0q�6Z   
���   �$	��Top=�6}   $	��350��6�   $ 0.5,0.5&�6�   $	 0.1Q�6�   A� 52   
   -&   5        $
 e3��52      $y�Hidden=�6   $
��Left=�62   $	��350��6M   $��
119,71,0,0q�6Z   
���   �$	��Top=�6}   $	��350��6�   $ 0.5,0.5&�6�   $	 0.1Q�6�   A� 53   
   -'   5        $
 e4��53      $y�Hidden=�6   $
��Left=�62   $	��350��6M   $��329,120,0,0q�6Z   
���   �$	��Top=�6~   $	��350��6�   $ 0.5,0.5&�6�   $	 0.1Q�6�   A� 54   
   -(   5        $
 e5��54      $y�Hidden=�6   $
��Left=�62   $	��350��6M   $��329,120,0,0q�6Z   
���   �$	��Top=�6~   $	��350��6�   $ 0.5,0.5&�6�   $	 0.1Q�6�   A� 55   
   -)   5        $
 e6��55      $y�Hidden=�6   $
��Left=�62   $	��350��6M   $��329,120,0,0q�6Z   
���   �$	��Top=�6~   $	��350��6�   $ 0.5,0.5&�6�   $	 0.1Q�6�   A� 56   
   -*   5        $
 e7��56      $y�Hidden=�6   $
��Left=�62   $	��350��6M   $��329,120,0,0q�6Z   
���   �$	��Top=�6~   $	��350��6�   $ 0.5,0.5&�6�   $	 0.1Q�6�   A� 57   
   -+   5        $
 e8��57      $y�Hidden=�6   $
��Left=�62   $	��350��6M   $��329,120,0,0q�6Z   
���   �$	��Top=�6~   $	��350��6�   $ 0.5,0.5&�6�   $	 0.1Q�6�   A� 58   
   -,   5        $
 e9��58      $y�Hidden=�6   $
��Left=�62   $	��350��6M   $��329,120,0,0q�6Z   
���   �$	��Top=�6~   $	��350��6�   $ 0.5,0.5&�6�   $	 0.1Q�6�   A� 59   
   --   5        $	
 e10��59      $y�Hidden=�6   $
��Left=�63   $	��350��6N   $��329,120,0,0q�6[   
���   �$	��Top=�6   $	��350��6�   $ 0.5,0.5&�6�   $	 0.1Q�6�   A� 5:   
   -.   5        $	
 e11��5:      $y�Hidden=�6   $
��Left=�63   $	��350��6N   $��329,120,0,0q�6[   
���   �$	��Top=�6   $	��350��6�   $ 0.5,0.5&�6�   $	 0.1Q�6�   A� 5;   
   -/   5        $	
 e12��5;      $y�Hidden=�6   $
��Left=�63   $	��350��6N   $��329,120,0,0q�6[   
���   �$	��Top=�6   $	��350��6�   $ 0.5,0.5&�6�   $	 0.1Q�6�   A� 5<   
   -0   5        $	
 e13��5<      $y�Hidden=�6   $
��Left=�63   $	��350��6N   $��329,120,0,0q�6[   
���   �$	��Top=�6   $	��350��6�   $ 0.5,0.5&�6�   $	 0.1Q�6�   A� 5=   
   -1   5        $	
 e14��5=      $y�Hidden=�6   $
��Left=�63   $	��350��6N   $��329,120,0,0q�6[   
���   �$	��Top=�6   $	��350��6�   $ 0.5,0.5&�6�   $	 0.1Q�6�   A� 5>   
   -2   5        $	
 e15��5>      $y�Hidden=�6   $
��Left=�63   $	��350��6N   $��329,120,0,0q�6[   
���   �$	��Top=�6   $	��350��6�   $ 0.5,0.5&�6�   $	 0.1Q�6�   A� 5?   
   -3   5        $	
 e16��5?      $y�Hidden=�6   $
��Left=�63   $	��350��6N   $��329,120,0,0q�6[   
���   �$	��Top=�6   $	��350��6�   $ 0.5,0.5&�6�   $	 0.1Q�6�   A� 5@   
   -4   5        $	
 e17��5@      $y�Hidden=�6   $
��Left=�63   $	��350��6N   $��329,120,0,0q�6[   
���   �$	��Top=�6   $	��350��6�   $ 0.5,0.5&�6�   $	 0.1Q�6�   A� 5A   
   -5   5        $	
 e18��5A      $y�Hidden=�6   $
��Left=�63   $	��350��6N   $��329,120,0,0q�6[   
���   �$	��Top=�6   $	��350��6�   $ 0.5,0.5&�6�   $	 0.1Q�6�   A� 5B   
   -6   5        $	
 e19��5B      $y�Hidden=�6   $
��Left=�63   $	��350��6N   $��329,120,0,0q�6[   
���   �$	��Top=�6   $	��350��6�   $ 0.5,0.5&�6�   $	 0.1Q�6�   A� 5C   
   -7   5        $	
 e20��5C      $y�Hidden=�6   $
��Left=�63   $	��350��6N   $��329,120,0,0q�6[   
���   �$	��Top=�6   $	��350��6�   $ 0.5,0.5&�6�   $	 0.1Q�6�   A� 5D   
   -8   5        $	
 e21��5D      $y�Hidden=�6   $
��Left=�63   $	��350��6N   $��329,120,0,0q�6[   
���   �$	��Top=�6   $	��350��6�   $ 0.5,0.5&�6�   $	 0.1Q�6�   A� 5E   
   -9   5        $	
 e22��5E      $y�Hidden=�6   $
��Left=�63   $	��350��6N   $��329,120,0,0q�6[   
���   �$	��Top=�6   $	��350��6�   $ 0.5,0.5&�6�   $	 0.1Q�6�   A� 5F   
   -:   5        $	
 e23��5F      $y�Hidden=�6   $
��Left=�63   $	��350��6N   $��329,120,0,0q�6[   
���   �$	��Top=�6   $	��350��6�   $ 0.5,0.5&�6�   $	 0.1Q�6�   A� 5G   
   -;   5        $	
 e24��5G      $y�Hidden=�6   $
��Left=�63   $	��350��6N   $��329,120,0,0q�6[   
���   �$	��Top=�6   $	��350��6�   $ 0.5,0.5&�6�   $	 0.1Q�6�   A� 5H   
   -<   5        $	
 e25��5H      $y�Hidden=�6   $
��Left=�63   $	��350��6N   $��329,120,0,0q�6[   
���   �$	��Top=�6   $	��350��6�   $ 0.5,0.5&�6�   $	 0.1Q�6�   A� 5I   
   -=   5        $	
 e26��5I      $y�Hidden=�6   $
��Left=�63   $	��350��6N   $��329,120,0,0q�6[   
���   �$	��Top=�6   $	��350��6�   $ 0.5,0.5&�6�   $	 0.1Q�6�   A� 5J   
   ->   5        $	
 e27��5J      $y�Hidden=�6   $
��Left=�63   $	��350��6N   $��329,120,0,0q�6[   
���   �$	��Top=�6   $	��350��6�   $ 0.5,0.5&�6�   $	 0.1Q�6�   A� 5K   
   -?   5        $	
 e28��5K      $y�Hidden=�6   $
��Left=�63   $	��350��6N   $��329,120,0,0q�6[   
���   �$	��Top=�6   $	��350��6�   $ 0.5,0.5&�6�   $	 0.1Q�6�   A� 5L   
   -@   5        $	
 e29��5L      $y�Hidden=�6   $
��Left=�63   $	��350��6N   $��329,120,0,0q�6[   
���   �$	��Top=�6   $	��350��6�   $ 0.5,0.5&�6�   $	 0.1Q�6�   A� 5M   
   -A   5        $	
 e30��5M      $y�Hidden=�6   $
��Left=�63   $	��350��6N   $��329,120,0,0q�6[   
���   �$	��Top=�6   $	��350��6�   $ 0.5,0.5&�6�   $	 0.1Q�6�   �� 5O   
   -B   5         ��Name$ 	God_ghost��5O      $
��Left=�6#   $�� /ghost.png��6>   $��60��6S   $��1150,410,0,0q�6_   $	��Top=�6u   $��60��6�   �� 5P   
   -C   5        $
��wiz2��5P      $
��Left=�6   $��
 /wiz2.jpg��67   $	��100��6K   $��662,594,0,0q�6X   $	��Top=�6m   $	��100��6�   �� 5Q   
   -D   5        $
��wiz3��5Q      $	��100��6   $��
 /wiz3.jpg��6)   $	��100��6=   $��402,607,598,-123q�6I   �� 5R   
   -E   5        $
��bow2��5R      $
��Left=�6   $��
/bowm2.png��67   $	��100��6K   $��612,594,0,0q�6X   $	��Top=�6m   $	��100��6�   �� 5S   
   -F   5        $
��bow3��5S      $	��100��6   $��
/bowm3.png��6)   $	��100��6=   $��264,607,736,-123q�6I   �� 5U   
   $��	/spin.gif��6   $
��Left=�6#   $��
12,534,0,0q�6>   $	��Top=�6R   $��25��6j   �� 5V   
   $��	/spin.gif��6   $
��Left=�6#   $��127,534,0,0q�6>   $	��Top=�6S   $��25��6k   �� 5W   
   $��25��6   
�������$��0,0,0,0q�60   $��20(�6B   $��26��6P   $	��Top=�6\   $
��Left=�6t   $��59��6�   $��
41,531,0,0q�6�   �� 5X   
   $��35��6   
�������$��0,0,0,0q�60   $��20(�6B   $��26��6P   $	��Top=�6\   $
��Left=�6t   $��60��6�   $��157,531,0,0q�6�   �� 5Z   
   '  !XamlAnimatedGif.AnimationBehavior   	SourceUri$ 	/spin.gif?�6   $
��Left=�6<   $��50��6W   $��50��6c   $��925,499,0,0q�6n   $	��Top=�6�   �� 5[   
   -G   5        $��money��5[      $
��Left=�6   
�������$��27(�6K   $��980,499,0,0q�6Y   $	��Top=�6n   $��52��6�   $��86��6�   5\      5]      