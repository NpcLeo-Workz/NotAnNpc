   M S B A M L   `   `   `  ????S  ODndCharacterCreation_WPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullO,clr-namespace:DndCharacterCreation_WPF.ViewsDndCharacterCreation_WPF.Views  5   	   3    -DndCharacterCreation_WPF.Views.CreateRaceView   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   >local,clr-namespace:DndCharacterCreation_WPF.Views     5   	     ? 
ResizeMode$  CanMinimize=?5   	    ? Title$ NotAnNpc??5	   	   $	??850??6   $	??860??6'   .??5
      ?  ? RowDefinitions 5   
   ?? 5      $??1* ?6   ?? 5      $??5* ?6   ?? 5      $??1* ?6   ?? 5      $??1* ?6   ?? 5      $??1* ?6   ?? 5      $??1* ?6   ?? 5      $??1* ?6   ?? 5      $??1* ?6   ?? 5      $??2* ?6   ?? 5      $
??1.3* ?6    ? ColumnDefinitions 5   
   ?? 5      $??1* ?6   ?? 5      $??1* ?6   ?? 5      $
??1.5* ?6   ??5   
   ?? 5        ?? ImageSource$; 5D:\dndproject\DndCharacterCreation_WPF\background.png??6    j? Stretch$ UniformToFill=?6]   .+?5"   
   ?? $??3??6   $??10??6(   ??5#      ?? 5$       ?? Color$ Black??6"    ?? Opacity$
 0.65Q?60   5&      ?? 5)   
   $??0??6   $??0??6!   $??Name:??61   ???	#FFD0A85C$??30(?6U   $??Right=?6c   $??Center=?6   $??10q?6?   ?? 5*   
   $??1??6   $??0??6!   $??AbilityScores:??61   ???	#FFD0A85C$??30(?6^   $??Right=?6l   $??Center=?6?   $??10q?6?   ?? 5+   
   $??2??6   $??0??6!   $??Size:??61   ???	#FFD0A85C$??30(?6U   $??Right=?6c   $??Center=?6   $??10q?6?   ?? 5,   
   $??3??6   $??0??6!   $??
WalkSpeed:??61   ???	#FFD0A85C$??30(?6Z   $??Right=?6h   $??Center=?6?   $??10q?6?   ?? 5-   
   $??4??6   $??0??6!   $??
SwimSpeed:??61   ???	#FFD0A85C$??30(?6Z   $??Right=?6h   $??Center=?6?   $??10q?6?   ?? 5.   
   $??5??6   $??0??6!   $??	FlySpeed:??61   ???	#FFD0A85C$??30(?6Y   $??Right=?6g   $??Center=?6?   $??10q?6?   ?? 5/   
   $??6??6   $??0??6!   $??ClimbSpeed:??61   ???	#FFD0A85C$??30(?6[   $??Right=?6i   $??Center=?6?   $??10q?6?   ?? 50   
   $??7??6   $??0??6!   $??CreatureType:??61   ???	#FFD0A85C$??30(?6]   $??Right=?6k   $??Center=?6?   $??10q?6?   ?? 51   
   $??8??6   $??0??6!   $??
Languages:??61   ???	#FFD0A85C$??30(?6Z   $??Right=?6h   $??Center=?6?   $??10q?6?   ?? 52   
   -   5         ??Name$
 Name??52      $??0??66   $??1??6C   $??10q?6S   ???	#FFD0A85C???	#FFD0A85C??6    ?? *Name+??6?   Z? ? 55   
   -   5        	 ?Name$	 AbilityScoresgrid??55      $??1??6*   $??1??67    56      ?? 57      ?? 58      ?? 59      ?? 5:      ?? 5;      ?? 5<       5>      ?? 5?      $??2* ?6#   ?? 5@      $??3* ?6#   .+?5D      ?? $??0??6   $??0??6%   $
??Str:??65   ???	#FFD0A85C$??30(?6X   $??Right=?6f   $??Center=?6?   $??10q?6?   ?? 5E      $??1??6   $??0??6%   $
??Dex:??65   ???	#FFD0A85C$??30(?6X   $??Right=?6f   $??Center=?6?   $??10q?6?   ?? 5F      $??2??6   $??0??6%   $
??Con:??65   ???	#FFD0A85C$??30(?6X   $??Right=?6f   $??Center=?6?   $??10q?6?   ?? 5G      $??3??6   $??0??6%   $
??Int:??65   ???	#FFD0A85C$??30(?6X   $??Right=?6f   $??Center=?6?   $??10q?6?   ?? 5H      $??4??6   $??0??6%   $
??Wis:??65   ???	#FFD0A85C$??30(?6X   $??Right=?6f   $??Center=?6?   $??10q?6?   ?? 5I      $??5??6   $??0??6%   $
??Cha:??65   ???	#FFD0A85C$??30(?6X   $??Right=?6f   $??Center=?6?   $??10q?6?   ?? 5J      -   5        $	 str??5J      $??0??68   $??1??6E   ???	#FFD0A85C$??5,5,10,5q?6l   ???	#FFD0A85C??6#   ?? *Str+??6?   Z? ?? 5K      -   5        $	 dex??5K      $??1??68   $??1??6E   ???	#FFD0A85C$??5,5,10,5q?6l   ???	#FFD0A85C??6#   ?? *Dex+??6?   Z? ?? 5L      -   5        $	 con??5L      $??2??68   $??1??6E   ???	#FFD0A85C$??5,5,10,5q?6l   ???	#FFD0A85C??6#   ?? *Con+??6?   Z? ?? 5M      -   5        $	 int??5M      $??3??68   $??1??6E   ???	#FFD0A85C$??5,5,10,5q?6l   ???	#FFD0A85C??6#   ?? *Int+??6?   Z? ?? 5N      -   5        $	 wis??5N      $??4??68   $??1??6E   ???	#FFD0A85C$??5,5,10,5q?6l   ???	#FFD0A85C??6#   ?? *Wis+??6?   Z? ?? 5O      -   5        $	 Cha??5O      $??5??68   $??1??6E   ???	#FFD0A85C$??5,5,10,5q?6l   ???	#FFD0A85C??6#   ?? *Cha+??6?   Z? 5P      ?? 5S   
   -	   5        $
 Size??5S      $??2??66   $??1??6C   $??10q?6S   ???	#FFD0A85C???	#FFD0A85C??6    ?? *Size+??6?   Z? ?? 5T   
   -
   5        $ 	WalkSpeed??5T      $??3??6@   $??1??6M   $??10q?6]   ???	#FFD0A85C???	#FFD0A85C??6%   ?? *	WalkSpeed+??6?   Z? ?? 5U   
   -   5        $ 	SwimSpeed??5U      $??4??6@   $??1??6M   $??10q?6]   ???	#FFD0A85C???	#FFD0A85C??6%   ?? *	SwimSpeed+??6?   Z? ?? 5V   
   -   5        $ FlySpeed??5V      $??5??6>   $??1??6K   $??10q?6[   ???	#FFD0A85C???	#FFD0A85C??6$   ?? *
FlySpeed+??6?   Z? ?? 5W   
   -   5        $ 
ClimbSpeed??5W      $??6??6B   $??1??6O   $??10q?6_   ???	#FFD0A85C???	#FFD0A85C??6&   ?? *
ClimbSpeed+??6?   Z? ?? 5X   
   -   5        $ CreatureType??5X      $??7??6F   $??1??6S   $??10q?6c   ???	#FFD0A85C???	#FFD0A85C??6(   ?? *CreatureType+??6?   Z? ? 5[   
   -   5        $	 Languagesgrid??5[      $??8??6&   $??1??63    5\      ?? 5]      ?? 5^      ?? 5_      .+?5a      ?? -   5        
 ??Name$
 cbxLanguages1??5a      $??0??6.    ?? DisplayMemberPath$
 Name??6;   $??5,5,10,5q?6?   ???	#FFD0A85C???	#FFD0A85C??6T   ?? *	Languages+ ?? SelectedItem 6v   ?? *SelectedLanguage1+??6?   Z? ?? 5b      -   5        $
 cbxLanguages2??5b      $??1??6.   $
 Name??6;   $??5,5,10,5q?6?   ???	#FFD0A85C???	#FFD0A85C??6T   ?? *	Languages+ 6v   ?? *SelectedLanguage2+??6?   Z? ?? 5c      -   5        $
 cbxLanguages3??5c      $??2??6.   $
 Name??6;   $??5,5,10,5q?6?   ???	#FFD0A85C???	#FFD0A85C??6T   ?? *	Languages+ 6v   ?? *SelectedLanguage3+??6?   Z? 5d      ? 5e   
   $??0??6   $??2??6    5f      ?? 5g      $??1* ?6#   ?? 5h      $??2* ?6#   .+?5j      ?? $??0??6   $??0??6%   $??Traits:??65   ???	#FFD0A85C$??30(?6[   $??Right=?6i   $??Center=?6?   $??10q?6?   ?? 5k      -   5        $
 	cbxTraits??5k      $??0??6*   $??1??67   $
 Name??6G   $??5,5,10,5q?6?   ???	#FFD0A85C???	#FFD0A85C??6`   ?? *Traits+ 6   ?? *SelectedTraitcbx+??6?   Z? 5l      &   System.Windows.Controls.DataGrid  5m   
   -   5          Name$ 
DataTraits??5m      $??1??6'   $??3??64   $??3??6D      AutoGenerateColumns .     
IsReadOnly . ???	#FFD0A85C???	#FFD0A85C$??20(?6  ??6U   ?? *SelectedTraits+ 6|   ?? *SelectedTrait+??6?   Z?    Columns 5n      0  *System.Windows.Controls.DataGridTextColumn  5p      ,  &System.Windows.Controls.DataGridColumn   Header$ 
Trait Name??6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ 5* 6R      
Foreground ?	#FFD0A85C1  +System.Windows.Controls.DataGridBoundColumn   Binding 69   ?? *Name+   HeaderStyle 5q      ?? 5r       ?? 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6    .?5s      ??  ?? Property ? ?? ?? Value
 ???? 6;   ?? 5t       ? ??$ 10q?67   5u      5w        5x      $ Description??6%   $ 5* 6Z    ?	#FFD0A85C 6:   ?? *Description+ 5y      ?? 5z      "  6    .?5{      ??  ? ??
 ???? 6;   ?? 5|       ? ??$ 10q?67   5}      5      5?      ? 5?   
   $??4??6   $??2??6    5?      ?? 5?      ?? 5?      .+?5?      ?? -   5         ??Name$ btnAddTrait??5?   %   $??0??6   $	??Add??6:   $??AddTraitToRace??6\   $??20(?6~   ???	#FFD0A85C???	#FFD0A85C$??2q?6?   $??10q?6?   $
??Auto??6?   ??6H   ?? ??5?      ?? 5?      $ Black??6"   $
 0.65Q?60   5?      ?? 5?      -   5        $ btnRemoveTrait??5?   %   $??1??6   $??Remove??6=   $??RemoveTraitFromRace??6b   $??20(?6?   ???	#FFD0A85C???	#FFD0A85C$??2q?6?   $??10q?6?   $
??Auto??6?   ??6N   ?? ??5?      ?? 5?      $ Black??6&   $
 0.65Q?64   5?      5?      ?? 5?   
   -   5        $ 	btnCreate??5?   /   $??10??6   $??0??6   $??Create Race??6B   $??AddRace??6l   $??30(?6?   ???	#FFD0A85C???	#FFD0A85C$??2q?6?   $??10q?6?   $
??Auto??6?   ??6X   ?? ??5?      ?? 5?      $ Black??6"   $
 0.65Q?60   5?      ?? 5?   
   -   5        $ 	btnCancel??5?   /   $??10??6   $??1??6   $??Cancel??6B   $??Cancel??6g   $??30(?6?   ???	#FFD0A85C???	#FFD0A85C$??2q?6?   $??10q?6?   $
??Auto??6?   ??6S   ?? ??5?      ?? 5?      $ Black??6"   $
 0.65Q?60   5?      5?      5?      