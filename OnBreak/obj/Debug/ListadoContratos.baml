   M S B A M L   `   `   `  ����B  >OnBreak, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null!clr-namespace:OnBreakOnBreak  5   	   %    OnBreak.VentanaListadoContratos   5      H DMahApps.Metro, Version=1.6.5.1, Culture=neutral, PublicKeyToken=null;Controls,http://metro.mahapps.com/winfx/xaml/controls  R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   'localclr-namespace:OnBreak     5   	     � Title$  Listado de Contratos��5	   	   $��378.883��6&   $��611.357��67   .��5
      � $��0,0,2,1q�6    � ColumnDefinitions 5   
   �� 5      �� 5      $��0* �6   .+�5   
   �� $��50��6   $��50��6   $��
10,5,20,10q�6'   $	��Top=�6;   $��Right=�6S   $)��#img\logo_transparent_background.png��6o   �� 5   
   $��Listado de Contratos��6   $
��Left=�6/   $��	24,10,0,0q�6J   $	��Top=�6]   $	��369��6u   $��18(�6�   $��34��6�   �� 5   
   -   5           AccentedSquareButtonStyle#��[  5      $��Filtrar��6E   $
��Left=�6W   $��
470,80,0,0q�6r   $	��Top=�6�   $	��116��6�    J� RenderTransformOrigin$ 0.5,0.5&�6�   $��28��6�   ��6�   Z� �� 5   
   *  $MahApps.Metro.Controls.TextBoxHelper   	Watermark$ Numero de Contrato��6   $
��Left=�6H   $��26��6c   $��	24,81,0,0q�6o    �� TextWrapping$
 Wrap=�6�   $	��Top=�6�   $	��140��6�   �� 5   
   -   5          SquareButtonStyle#���  5      $��Volver��6>   $
��Left=�6O   $��366,289,0,0q�6j   $	��Top=�6   $	��214��6�   $ 0.5,0.5&�6�   $��28��6�   ���	#FFEEEEEE��6�   Z� �� 5   
   $ Rut del Cliente��6   $
��Left=�6E   $��26��6`   $��
347,81,0,0q�6l   $
 Wrap=�6�   $	��Top=�6�   $	��100��6�   &   System.Windows.Controls.DataGrid  5   
     AzureDataGrid#��[ 6   $��24,131,198,104q�6:      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Numero de Contrato��6%     5      $ RUT Cliente��6%     5      $ Tipo de Contrato��6%   5      �� 5   
   -   5         ��Name$ cboTipoContrato��5      $ Tipo de Contrato��6,   $
��Left=�6`   $��
183,81,0,0q�6{   $	��Top=�6�   $	��131��6�   5      5      