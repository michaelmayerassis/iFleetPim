   M S B A M L   `   `   `  ����J  FFrotaVeiculoPim, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null=#clr-namespace:FrotaVeiculoPim.ViewsFrotaVeiculoPim.Views  5      Q MCurrencyTextBoxControl, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null_Dclr-namespace:CurrencyTextBoxControl;assembly=CurrencyTextBoxControlCurrencyTextBoxControl 5      )    #FrotaVeiculoPim.Views.CadManutencao   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      U QMaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      /local#clr-namespace:FrotaVeiculoPim.Views  5      aCurrencyTextBoxControlDclr-namespace:CurrencyTextBoxControl;assembly=CurrencyTextBoxControl  5      $	��742��5	      $��1190.684��6   .��5
      � .+�5   
   ?  9MaterialDesignThemes.Wpf.Transitions.TransitioningContent  -   5           Name$  TrainsitionigContentSlide��5   .   $��1,17,-1,-17q�6�   C  =MaterialDesignThemes.Wpf.Transitions.TransitioningContentBase   OpeningEffect 6Q   D  >MaterialDesignThemes.Wpf.Transitions.TransitionEffectExtension  *SlideInFromLeft+   Duration$ 0:0:0.3X�.��5      �� 
�������$��	0,-18,0,0q�6,   .+�5      �� -   5         ��Name$ tbTitulo��5   N    
  titulo#��[  6   $��0,30,0,0q�6<   �� 6a   $�MANUTENÇÃO��6e   6z   �� 5      � 5      .+�5      �� -   5         ��Name$ spInManutencao��5   !   $��0,60,0,0q�69   .+�5      �� -   5         ��Name$ btnCadManutencao��5   !   $	��400��5   !   $��0,0,0,30q�6-   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth2=�6@   
�������$
��auto��5   L   $
��20px(�6Z   ��64   Z� ��5      �� 5   "    �� EndPoint$ 0.5,1&�66    �� 
StartPoint$ 0.5,0&�6G   .��5   &   � 	 � Color$	 	#FF52E6FD��63   
 � Offset$
 0Q�6E   � 5   &   $	 	#FF3157FF��63   $
 0.799Q�6E   5   #   .��5      ��  �� Orientation$ 
Horizontal=�6)   $��Center=�6B   .+�5   "   '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.6.0.325, Culture=neutral, PublicKeyToken=null]]   Kind$ VanPassenger=�6:   $��0,0,10,0q�6N   $
��20px��6`   $��26��6m   �� 5   "   �� 6-   $�Cadastrar Manutenção��61   6P   5      5      �� 5       -   5        $ btnFinalizar��5"   !   $	��400��5    !   $��0,0,0,30q�6-   $ Depth2=�6@   
�������$
��20px(�5!   K   $
��auto��6[   ��64   Z� ��5#      �� 5$   "   $ 0.5,1&�66   $ 0.5,0&�6G   .��5%   &   � $	 	#FF52E6FD��63   $
 0Q�6E   � 5&   &   $	 	#FF3157FF��63   $
 0.799Q�6E   5'   #   .��5)      �� $ 
Horizontal=�6)   .+�5*   "     $ VanPassenger=�6:    J� RenderTransformOrigin$ 0.5,0.5&�6N   $��0,0,10,0q�6n   $��27��6�   $
��20px��6�   z�5+   &   V� 5,   *   .~�5-   .   ��  �� ScaleY$ 1Q�6=    �� ScaleX$ -1Q�6H   �� 5.   .    �� AngleY$ 0Q�6<    �� AngleX$ 0Q�6G   �� 5/   .    �� Angle$ 0Q�6>   T� 50   .   51   +   53   #   �� 54   "   �� 6-   $�Finalizar manutenção��61   6P   55      56      �� 57      -   5        $ btnConsultar��59   !   $	��400��57   !   $��0,0,0,30q�6-   $ Depth2=�6?   
�������$
��20px(�58   K   $
��auto��6[   ��64   Z� ��5:      �� 5;   "   $ 0.5,1&�66   $ 0.5,0&�6G   .��5<   &   � $	 	#FF52E6FD��63   $
 0Q�6E   � 5=   &   $	 	#FF3157FF��63   $
 0.799Q�6E   5>   #   .��5@      �� $ 
Horizontal=�6)   .+�5A   "     $ Highway=�6:   $��0,0,10,0q�6I   $��27��6[   $
��20px��6g   �� 5B   "   �� 6-   $�Veículos em manutenção��61   6R   5C      5D      5E      �� 5G      -   5        $ spCadManutencao��5G   !   $y�	Collapsed=�6:   .+�5H      � $��
60,30,60,0q�6   .+�5I      �� $��Placa do veiculo:��6$   $��	0,0,660,0q�6@   �� 5J      -   5         ��Name$ cbPlacaManutencao��5J   <   $��209,3,0,149q�6'   $
��Left=�6W   $	��250��6r   �� 5K      -	   5         ��Name$ lblData��5K   $   $!��Manutenção prevista para:��65   $��477,2,303,136q�6Y   (  "System.Windows.Controls.DatePicker  5L      -
   5          Name$ dpData��5L   )   $��777,-3,72,141q�69   $��16(�6P   5M      � 5O      -   5         �Name$ gridVeiculo��5O   3   $��
60,30,60,0q�6   63   � 5P      -   5        $ gridCadViagem��5P   3   $��
60,30,60,0q�6    � ColumnDefinitions 5Q      �� 5R   "   $	��22* �63   �� 5S   "   $	��17* �63   �� 5T   "   $
��497* �63   �� 5U   "   $
��535* �63    � RowDefinitions 5W      �� 5X   "   $��* �60   �� 5Y   "   $��* �60   �� 5Z   "   $��* �60   .+�5]      �� $��1��6)   $��	0,0,30,30q�66   $��3��6I   .+�5^   "   �  5_   &   �� 5`   *   $	��13* �6;   �� 5a   *   $��9* �6;    5c   &   �� 5d   *   $��* �68   �� 5e   *   $��* �68   .+�5g   &   �� $��Descrição:��6,   $��0��6A   $��
0,-28,0,44q�6Q   $��2��6e   �� 5h   &   -   5         ��Name$ txtDescricao��5h   .   $��3,12,-494,-89q�6^   $��2��6u   $��2��6�   $��3,3,3,3q�6�    �� TextWrapping$
 Wrap=�6�    �� AcceptsReturn . 6�   5i   #   5j      �� 5l      $��0��6)   $��0��66   $��3��6F   $��0,0,0,85q�6Z   $��2��6l   .+�5m   "   �  5n   &   �� 5o   *   $��* �68   �� 5p   *   $��* �68   5r   #   5s      �� 5t      $��3��6)   $��4��69   .+�5u   "   �  5v   &   �� 5w   *   �� 5x   *   .+�5{   &   �� -   5        $ btnCadastrar��5{   -   $��1��6C   
�������$ Depth2=�5|   )   $��6,74,73,-129q�5}   )   $
��Auto��5~   @   $��SALVAR��6N   ��6)   Z� ��5   *   �� 5�   .   $ 0.5,1&�6B   $ 0.5,0&�6S   .��5�   2   � $	 	#FF4413C7��6?   $
 0Q�6Q   � 5�   2   $	 	#FF0C0C6A��6?   $
 0.799Q�6Q   5�   /   5�   '   5�   #   5�      �� 5�      -   5        $ btnVoltarSaindo��5�   %   
�������$ Depth2=�5�   %   $��9,77,338,-132q�5�   %   $
��Auto��5�   <   $��VOLTAR��6J   $��2��6[   $��3��6h   ��6%   Z� ��5�   "   �� 5�   &   $ 0.5,1&�6:   $ 0.5,0&�6K   .��5�   *   � $	 	#FF4413C7��67   $
 0Q�6I   � 5�   *   $	 	#FF0C0C6A��67   $
 0.799Q�6I   5�   '   5�      5�      5�      �� 5�      -   5        $ spFinalizarManutencao��5�   !   $y�	Collapsed=�6@   .+�5�      � $��
60,30,60,0q�6    5�      �� 5�   "   $	��43* �63   �� 5�   "   $	��20* �63   .+�5�      �� $!��Informe a placa do veiculo:��6$   $��0,0,428,141q�6J   �� 5�      -   5        $ cbPlaca��5�   <   $��311,0,0,171q�6'   $
��Left=�6M   $	��250��6h   �� 5�      -   5        $ lblDataSaida��5�   $   $��Valor Manutenção:��6:   $��576,6,279,157q�6V   $��2��6m   �� 5�      $��10,59,70,-111q�6'   $��24(�6>   
���   ����	#FFF0F0F0���	#FF130A0A$��2��6�   $��Peças utilizadas��5�   T   .��5�   "   � .+�5�   &   �� $��Peça:��6,   $��3,0,848,122q�6<   �� 5�   &   -   5        $ cbPeca��5�   F   $��81,-2,534,141q�6/   6F   �� 5�   &   -   5        $ txtQtd��5�   F   $��638,11,186,138q�6.   ��6V   Z� 6l   �� 5�   &   $��Quantidade:��6,   $��465,4,344,116q�6B   �� 5�   &   -   5        $ btnAdicionar��5�   -   $��Right=�6C   $��55��6_   $��0,8,101,137q�6j    � Cursor$
 Hand��6   $
��Auto��6�   ��5�   *   �� 5�   .   $ 0.5,1&�6B   $ 0.5,0&�6S   .��5�   2   � $	 	#FFF9DD7F��6?   $
 0Q�6Q   � 5�   2   $	 	#FFB3942B��6?   $	
 0.8Q�6Q   5�   /   .��5�   *     $	 Add=�6B   $��30��6M   $��25��6Y   ���	#FFFBFBFB6d   5�   '   &   System.Windows.Controls.DataGrid  5�   &   -   5          Name$ dgPeca��5�   /   $��	5,60,-1,1q�6?   $	��122��6R      ColumnWidth5	  /System.Windows.Controls.DataGridLengthConverter$	 475	 6_   ���	#FFFAFAFA"   VerticalScrollBarVisibility$ Visible=�6�   $    HorizontalScrollBarVisibility$  Disabled=�6�   !   
IsReadOnly! . 6�   �� 5�   &   -   5        $ 
btnDeletar��5�   -   $��Right=�6A   $��55��6]   $��
0,8,20,137q�6h   $
 Hand��6|   $
��Auto��6�   ��5�   *   �� 5�   .   $ 0.5,1&�6B   $ 0.5,0&�6S   .��5�   2   � $	 	#FFFD4B42��6?   $
 0Q�6Q   � 5�   2   $	 	#FFB60D05��6?   $	
 0.8Q�6Q   5�   /   .��5�   *     $ Delete=�6B   $��30��6P   $��25��6\   
�������6g   5�   '   5�   #   5�      ,
  &CurrencyTextBoxControl.CurrencyTextBox
  5�      -   5        " 
 Name$" txtValor��5�   E   )  #MaterialDesignThemes.Wpf.HintAssist#   Hint$# Valor��6W   $��24(�6   $��IBM Plex Sans)�6�   $��66,-2,77,165q�6�   $��1��6�   $��Bottom=�6�   .��6�   ��5�   "   �� 5�   &   $
 0,20&�6:   $ � MappingMode$$ Absolute=�6J   $	 0,0&�6a   .��5�   *   � $	 	#FFABADB3��67   $

 0.05Q�6I   � 5�   *   $	 	#FFE2E3EA��67   $

 0.07Q�6I   � 5�   *   $	 	#FFABADB3��67   $
 1Q�6I   5�   '   .��5�   V   5�      5�      � 5�      -   5        $ gridVeiculo1��5�   3   $��
60,30,60,0q�6   63   � 5�      -   5        $ gridFinalizarManutencao��5�   3   $��
60,30,60,0q�6    5�      �� 5�   "   $	��22* �63   �� 5�   "   $	��17* �63   �� 5�   "   $
��497* �63   �� 5�   "   $
��535* �63    5�      �� 5�   "   $��* �60   �� 5�   "   $��* �60   �� 5�   "   $��* �60   .+�5�      �� $��1��6)   $��	0,0,30,30q�66   $��3��6I   .+�5�   "   �  5�   &   �� 5�   *   $	��79* �6;   �� 5�   *   $
��220* �6;   �� 5�   *   $
��207* �6;    5�   &   �� 5�   *   $��* �68   �� 5�   *   $��* �68   .+�5�   &   �� $��Observação(ões):��6,   $��0��6G   $��
0,49,0,-61q�6W   $��3��6k   $��1��6   �� 5�   &   -   5        $ txtDescricao1��5�   .   $��3,92,-494,-174q�6_   $��3��6w   $��3,3,3,3q�6�   $��1��6�   $
 Wrap=�6�    . 6�   5�   #   5�      �� 5�      $��0��6)   $��0��66   $��3��6F   $��0,0,0,85q�6Z   $��2��6l   .+�5�   "   �  5�   &   �� 5�   *   $��* �68   �� 5�   *   $��* �68   5�   #   5�      �� 5�      $��3��6)   $��4��69   .+�5�   "   �  5�   &   �� 5�   *   �� 5�   *   .+�5�   &   �� -   5        $ btnSalvarFim��5�   -   $��1��6C   
�������$ Depth2=�5�   )   $��6,159,73,-214q�5�   )   $
��Auto��5�   @   $��SALVAR��6N   ��6)   Z� ��5�   *   �� 5�   .   $ 0.5,1&�6B   $ 0.5,0&�6S   .��5�   2   � $	 	#FF4413C7��6?   $
 0Q�6Q   � 5�   2   $	 	#FF0C0C6A��6?   $
 0.799Q�6Q   5�   /   5�   '   5  #   5     �� 5     -   5        $ btnVoltarSaindo1��5  %   
�������$ Depth2=�5  %   $��20,162,327,-217q�5  %   $
��Auto��5  <   $��VOLTAR��6J   $��2��6[   $��3��6h   ��6%   Z� ��5  "   �� 5  &   $ 0.5,1&�6:   $ 0.5,0&�6K   .��5	  *   � $	 	#FF4413C7��67   $
 0Q�6I   � 5
  *   $	 	#FF0C0C6A��67   $
 0.799Q�6I   5  '   5     5     5     �� 5     -   5        $ spListarVeiculos��5  !   $��	10,0,10,0q�6;   $y�	Collapsed=�6N   .+�5     �� $��	10,0,0,10q�6$     tituloFiltro#��[ 67   	FILTROS6f   � 5     $��0,0,0,30q�6   .+�5     �� -   5        $ 	lblFiltro��5  $   $��	0,0,849,0q�67   $��Informe a placa do carro:��6J   6p   �� 5     -    5        $ 	txtBuscar��5  ;   $��346,0,567,0q�6&   6N   �� 5     -!   5        $ 	btnBuscar��5  F   $��652,0,363,0q�5  %   ���#364EFF
�������$ Depth2=�5  !   $
��Auto��5  8   ��6!   Z� .��6Y   BUSCAR5     5       5     -"   5        $ 	dgVeiculo��5  5   $��0,0,0,30q�6#   ! . %   CanUserResizeColumns% .  &   MinColumnWidth$	& 100Q�6�   6�   �� 5     -#   5        $ 	btnVoltar��5  !   
�������$ Depth2=�5  %   $��0,0,964,-55q�5   %   $
��Auto��5!  <   $��VOLTAR��6J   ��6%   Z� ��5"     �� 5#  "   $ 0.5,1&�66   $ 0.5,0&�6G   .��5$  &   � $	 	#FF4413C7��63   $
 0Q�6E   � 5%  &   $	 	#FF0C0C6A��63   $
 0.799Q�6E   5&  #   5(     5)     5*     5+     5,     5-     5.     