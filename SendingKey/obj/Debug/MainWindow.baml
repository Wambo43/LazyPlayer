   M S B A M L   `   `   `  ����  
SendingKey    SendingKey.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	     � Title$  AFK Bot��5   	   $	��450��5   	   $	��800��5	   	   .��5
      ]� $��10q�6   .+�5   
   �� $��	0,10,0,10q�6   ._�5      �� .+�5      �� $��Working Process��6   �� 5      -   5         ��Name$ WorkingProcess��5      $��2q�5       � ToolTip$_ YBitte geben Sie den Processnamen ein, der Name ist zu finden in dem TaskManager Processes��5      ��5      �� *ProcessName+5      �� 5      -   5         ��Name$ StartAfkService��5      $��100px��5      $
��50px��5      $
��Left=�5      $��klick me��5      $��2q�5      ��5      �� *CommandAfkProcess+5      �� 5      $��
Loop Timer��6   �� 5      -   5        $ 	LoopTimer��5      $= 7die Zeit ist in millisecond einzutragen z.B 1sec = 1000��5      ��5      �� *	LoopTimer+5      �� 5      $��Thats Fisch Testing��6   �� 5      -   5        $ 
StartFisch��5      $��100px��5       $
��50px��5!      $
��Left=�5"      $��	FischTest��5%      $��2q�5&      ��5#      �� *Color+��5$      �� *CommandFishing+5&      5'      5(      �� 5)   
   $��	0,10,0,10q�6   ._�5*      �� .+�5+      �� $��14��6   $
��Wrap=�5,      $��Command Line��5-      $	��Top=�5.      $	��118��5/      �� 50      -   5        $ CommandLine��50      $��	0,10,0,10q�51      $	��300��52       �� TextWrapping$
 Wrap=�53      $N HHier können sie Kommandos eingeben die nacheinander ausgeführt werden.��57      $	��120��58      ��54      �� *
KeyWords+58      59      5:      5;      5<      