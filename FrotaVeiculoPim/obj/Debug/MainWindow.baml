   M S B A M L   `   `   `  ����J  FFrotaVeiculoPim, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null1clr-namespace:FrotaVeiculoPimFrotaVeiculoPim  5   	        FrotaVeiculoPim.MainWindow   5   	   U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   /localclr-namespace:FrotaVeiculoPim     5   	   $	��800��5
   	   $
��1200��6     � WindowStyle$
  None=�6#   $��0q�66    � WindowStartupLocation$ CenterScreen=�6J    � WindowState$ 	Maximized=�6o    � 	Resources 5         MenuOpen �� TargetProperty �� 
TargetName9  3System.Windows.Media.Animation.EasingDoubleKeyFrame O� KeyTime O� Value  	MenuClose��%�  &	        &	 �     �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $ GridMenu��6a   .\�5        $ 0��6'   $ 50Q�63     5      $ 0:0:0.2��6'   $	 230Q�69   5      5      �� 5   
   .��5      U� $ (FrameworkElement.Width)�6,   $ GridMenu��6a   .\�5        $ 0��6'   $	 230Q�63     5      $ 0:0:0.2��6'   $ 50Q�69   5      5      5       � Triggers 5      :� 5   
   	 :� RoutedEvent$	 ButtonBase.Click��6   
 :� 
SourceName$
 ButtonOpenMenu��66   .[�5      �� #��[  6   5      :� 5   
   $	 ButtonBase.Click��6   $
 ButtonCloseMenu��66   .[�5       �� #��[ 6   5!      .��5$      � .+�5%   
   �� -   5         ��Name$ imgFundo��5%      $��images\fundo3.jpg��6"   $��UniformToFill=�6=   � 5'   
   $��80��6   $	��Top=�6   .+�5(      �� -   5         ��Name$ btnFecharAplicacao��5(      $	��Top=�61   $��Right=�6I   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth1=�6	  ��6e   Z� ��6{   Z� .��5)      '  !MaterialDesignThemes.Wpf.PackIcon  -   5          Name$ fechar��5)   *   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ Close=�6:   
�������5*   )   5+      5,      � 5-   
   -   5         �Name$ GridPrincipal��5-      $��Center=�6&   $��Center=�6C   $	��800��5.      $
��1112��6   $��55,28,25,22q�6)   � 51   
   -   5        $ GridMenu��51      $	��230��6!   $
��Left=�6-   ���#364EFF.+�52      �� .+�53      � .+�54      �� -   5        $ ButtonCloseMenu��54      $
��Left=�66   $��60��6Q   $��60��6\     ButtonStyle1#���  6�   ��6h   Z� ��6~   Z� .��55        $ 	ArrowLeft=�62   
�������$��25��6V   $��25��6a   56      �� 57      -   5        $ ButtonOpenMenu��57      $
��Left=�65   $��60��6P   $��60��6[     ButtonStyle2#���  6�   $y�	Collapsed=�6�   ��6g   Z� ��6}   Z� .��58        $
 Menu=�63   
�������$��25��6R   $��25��6]   $	��-20q�6i   59      5:      �� 5<      -   5        $��Disabled=�5<      $	��603��6~   .@�5=      �� -	   5         ��Name$ 	Principal��5=   #   $��60��66    � Cursor$
 Hand��6B     ListViewItemStyle1#���  6P   .��5>      ��  �� Orientation$ 
Horizontal=�6%   .+�5?        $
 Home=�66   $��25��6B   $��25��6N   $��Center=�6Y   
�������6t   �� 5@      $��Tela Principal��6(   $��Center=�6>   $��10q�6Y   
�������$��18(�6x   5A      5B      �� 5C      -
   5        $ 
cadVeiculo��5C   #   $��60��67   $
 Hand��6C   #���  6Q   .��5D      �� $ 
Horizontal=�6%   .+�5E        $	 Car=�66   $��25��6A   $��25��6M   $��Center=�6X   
�������6s   �� 5F      $��Veículo��6(   $��Center=�67   $��10q�6R   
�������$��18(�6q   5G      5H      �� 5I      -   5        $ 	cadSeguro��5I   #   $��60��66   $
 Hand��6B     ListViewItemStyle2#���  6P   .��5J      �� $ 
Horizontal=�6%   .+�5K        $ FileDocument=�66   $��25��6J   $��25��6V   $��Center=�6a   
�������6|   �� 5L      $��Cadastrar Seguro��6(   $��Center=�6@   $��10q�6[   
�������$��18(�6z   5M      5N      �� 5O      -   5        $ 	cadMultas��5O   #   $��60��66   $
 Hand��6B     ListViewItemStyle3#���  6P   .��5P      �� $ 
Horizontal=�6%   .+�5Q        $ NoteAdd=�66   $��25��6E   $��25��6Q   $��Center=�6\   
�������6w   �� 5R      $��Multas��6(   $��Center=�66   $��10q�6Q   
�������$��18(�6p   5S      5T      �� 5U      -   5        $ cadManutencao��5U   #   $��60��6:   $
 Hand��6F     ListViewItemStyle4#���  6T   .��5V      �� $ 
Horizontal=�6%   .+�5W        $ Toolbox=�66   $��25��6E   $��25��6Q   $��Center=�6\   
�������6w   �� 5X      $��Manutenção��6(   $��Center=�6:   $��10q�6U   
�������$��18(�6t   5Y      5Z      �� 5[      -   5        $ cadMotorista��5[   #   $��60��69   $
 Hand��6E     ListViewItemStyle5#���  6S   .��5\      �� $ 
Horizontal=�6%   .+�5]        $ 	PersonAdd=�66   $��25��6G   $��25��6S   $��Center=�6^   
�������6y   �� 5^      $��Cadastrar Motorista��6(   $��Center=�6C   $��10q�6^   
�������$��18(�6}   5_      5`      �� 5a      -   5        $ 	cadViagem��5a   #   $��60��66   $
 Hand��6B    	 ListViewItemStyle6#��� 	 6P   .��5b      �� $ 
Horizontal=�6%   .+�5c        $ AddLocation=�66   $��25��6I   $��25��6U   $��Center=�6`   
�������6{   �� 5d      $��Cadastrar Viagem��6(   $��Center=�6@   $��10q�6[   
�������$��18(�6z   5e      5f      �� 5g      -   5        $ cadAbastecimento��5g   #   $��60��6=   $
 Hand��6I    
 ListViewItemStyle7#��� 
 6W   .��5h      �� $ 
Horizontal=�6&   .+�5i        $ LocalGasStation=�66   $��25��6M   $��25��6Y   $��Center=�6d   
�������6   �� 5j      $��Abastecimento��6(   $��Center=�6=   $��10q�6X   
�������$��18(�6w   5k      5l      �� 5m      -   5        $ cadPecas��5m   #   $��60��65   $
 Hand��6A     ListViewItemStyle8#���  6O   .��5n      �� $ 
Horizontal=�6%   .+�5o        $ Build=�66   $��25��6C   $��25��6O   $��Center=�6Z   
�������6u   �� 5p      $��Cadastrar Peça��6(   $��Center=�6>   $��10q�6Y   
�������$��18(�6x   $��23��6�   $	��120��6�   5q      5r      �� 5s      -   5        $ cadMovimento��5s   #   $��60��69   $
 Hand��6E     ListViewItemStyle9#���  6S   .��5t      �� $ 
Horizontal=�6%   .+�5u        $ SwapHorizontal=�66   $��25��6L   $��25��6X   $��Center=�6c   
�������6~   �� 5v      $��Movim. Estoque��6(   $��Center=�6>   $��10q�6Y   
�������$��18(�6x   5w      5x      5z      �� 5|      -   5        $��Disabled=�5|      .@�5~      �� -   5        $ CloseApplication��5~   #   $��60��6=   $
 Hand��6I     ListViewItemStyle10#���  6W   .��5      �� $ 
Horizontal=�6%   .+�5�        $ Shutdown=�66   $��25��6F   $��25��6R   $��Center=�6]   
�������6x   �� 5�      $
��Sair��6(   $��Center=�64   $��10q�6O   
�������$��18(�6n   5�      5�      5�      5�      5�      5�      5�      