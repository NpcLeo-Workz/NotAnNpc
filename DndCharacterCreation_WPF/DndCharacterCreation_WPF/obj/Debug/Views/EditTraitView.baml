   M S B A M L   `   `   `  ????S  ODndCharacterCreation_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:DndCharacterCreation_WPF.ViewsDndCharacterCreation_WPF.Views  5   	   2    ,DndCharacterCreation_WPF.Views.EditTraitView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:DndCharacterCreation_WPF.Views     5   	     ? Title$  NotAnNpc??5   	   $	??300??6   $	??630??6'   .??5	      ?  ? RowDefinitions 5   
   ?? 5      $??1* ?6   ?? 5      $??1* ?6   ?? 5      $??1* ?6    ? ColumnDefinitions 5   
   ?? 5      ?? 5      ??5   
   ?? 5       ?? ImageSource$; 5D:\dndproject\DndCharacterCreation_WPF\background.png??6    j? Stretch$ UniformToFill=?6]   .+?5   
   ?? $??2??6   $??10??6(   ??5      ?? 5       ?? Color$ Black??6"    ?? Opacity$
 0.65Q?60   5      ?? 5"   
   $??0??6   $??0??6!   $??Name:??61   ???	#FFD0A85C$??30(?6U   $??Right=?6c   $??Center=?6   $??10q?6?   ?? 5#   
   $??1??6   $??0??6!   $??Description:??61   ???	#FFD0A85C$??30(?6\   $??Right=?6j   $??Center=?6?   $??10q?6?   ?? 5$   
   -   5         ??Name$
 Name??5$      $??0??66   $??1??6C   $??10q?6S   ???	#FFD0A85C$??30(?6w   ???	#FFD0A85C$??Center=?6?   ??6    ?? *Name+??6?   Z? 6?   ?? 5(   
   -   5        $ Description??5(      $??1??6D   $??1??6Q   $??10q?6a   ???	#FFD0A85C$??30(?6?   ???	#FFD0A85C$??Center=?6?   ??6'   ?? *Description+??6?   Z? 6?   ?? 5-   
   -   5         ??Name$ btnEdit??5-   /   $??10??6   $??0??6   $??
Edit Trait??6@   $??EditCurrentTrait??6i   $??30(?6?   ???	#FFD0A85C???	#FFD0A85C$??2q?6?   $??10q?6?   $
??Auto??6?   ??6U   ?? ??5.      ?? 5/      $ Black??6"   $
 0.65Q?60   51      ?? 52   
   -   5        $ 	btnCancel??52   /   $??10??6   $??1??6   $??Cancel??6B   $??Cancel??6g   $??30(?6?   ???	#FFD0A85C???	#FFD0A85C$??2q?6?   $??10q?6?   $
??Auto??6?   ??6S   ?? ??53      ?? 54      $ Black??6"   $
 0.65Q?60   56      57      58      