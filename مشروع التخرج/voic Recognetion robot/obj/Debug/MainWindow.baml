   M S B A M L   `   `   `  ����Q  Mvoic Recognetion robot, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null?$clr-namespace:voic_Recognetion_robotvoic_Recognetion_robot  5   	   '    !voic_Recognetion_robot.MainWindow   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   6local$clr-namespace:voic_Recognetion_robot     5   	     � Title$  
MainWindow��5   	   $��859.6��6   $��1296.2��6+    � WindowStartupLocation$ CenterScreen=�6:    � WindowState$ 	Maximized=�6_   .��5	      � ��5
   
   �� 5       �� ImageSource$ images/bg2.jpg��6    � RowDefinitions 5   
   �� 5      $
��auto �6    � ColumnDefinitions 5   
   �� 5      $
��auto �6   6.   .+�5   
   � $��316,144,108.8,119q�6   .+�5      �� -   5         ��Name$ btn_connect��5      $��connect the robot��6*   $
��Left=�6F   $	��Top=�6a   $	��264��6y   $��283,202,0,0q�6�   $	��127��6�   ���	#FF918D8D6�   �� 5      -   5        $ manual_control��5      $��manual control��6-   $
��Left=�6F   $	��Top=�6a   $	��241��6y   $��108,334,0,0q�6�   $	��126��6�   {�.  ���	#FF918D8D6�   �� 5      -   5        $ voice_control��5      $��voice control��6,   $
��Left=�6D   $	��Top=�6_   $	��261��6w   $��466,337,0,0q�6�   $	��126��6�   {�.  
����������	#FF918D8D��6�   Z� 5      5      5       5!      