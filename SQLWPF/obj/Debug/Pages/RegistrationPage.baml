   M S B A M L   `   `   `  ????A  =SQLWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:SQLWPFSQLWPF  5          SQLWPF.RegistrationPage   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      &localclr-namespace:SQLWPF     5      _ [MaterialDesignThemes.Wpf, Version=4.6.1.0, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	         MaterialDesignBody#???   5
      $??Medium"?5      $??14(?5        N? Title$  RegistrationPage??5      $	??700??6    $	??500??60    N? 
Background
 ????  N? 
FontFamily 5      :  4MaterialDesignThemes.Wpf.MaterialDesignFontExtension  .??5      ?  ? ColumnDefinitions 5   
   ?? 5      $	??31* ?6   ?? 5      $
??237* ?6   ?? 5      $	??32* ?6    ? RowDefinitions 5   
   ?? 5      $	??56* ?6   ?? 5      $
??611* ?6   ?? 5      $	??67* ?6   .+?5   
   ?? -   5         ??Name$ 
mainBorder??5      $	??250??6%   $	??450??64   ???	#FFF8FFFF ?? Padding$ 40q?6[    ?? CornerRadius$ 20??6h   $??1??6z   $??10,10,10,10q?6?   $??1??6?    J? Effect 5       3  -System.Windows.Media.Effects.DropShadowEffect  5!      	   
BlurRadius$	 30Q?6#   
   Color$
 	LightGray??63      ShadowDepth$ 0Q?6E   ._?5#      ?  5$      ?? 5%      $	??72* ?6$   ?? 5&      $	??61* ?6$   ?? 5'      $
??323* ?6$   ?? 5(      $	??55* ?6$    5*      ?? 5+      $
??124* ?6'   ?? 5,      $
??351* ?6'   ?? 5-      $
??136* ?6'   .+?50      ?? $??1??6     MaterialDesignLabel#??[ 6(   $??24(?6U   $
??Bold"?6c   $??Center=?6u   $??0,2,0,0q?6?   $??1??6?   .??51      ??  ?? TextWrapping$
 Wrap=?6!   .??65   Registration53      54      ?? 56      $??1??6   $??1??6-   $??0,61,0,0q?6:   $??2??6L   .+?57      ?? -   5        $??AccountNameField??57      )  #MaterialDesignThemes.Wpf.HintAssist   Hint$ Account name??66    % !MaterialDesignFloatingHintTextBox#??[ 6d   $??1??6?   $??2??6?    ?? TextWrapping$
 Wrap=?6?   $?? ??6?   $??48??6?   $	??Top=?6?   $??0,58,0,0q?6?   G? 58      -   5        $??PasswordField??58   "   $ Enter password??67    ) %MaterialDesignFloatingHintPasswordBox#??[ 6g   $??1??6?   $??3??6?   $??48??6?   $??Center=?6?   G? 59      -   5        $??RepeatPasswordField??59   "   $ Repeat password??6=   #??[ 6n   $??1??6?   $??3??6?   $??48??6?   $??Center=?6?   ? 5:      $??50??6   .+?5;      ?? -   5        $??Right=?5;   !   $??Registratoin??6=   
??? ?????6l   Z? 6?   5<      ?? 5=      $??Already have account???6   $??Center=?6<   ???	#660000006Y   ?? 5>      -   5        $??LogInButton??5>        MaterialDesignFlatButton#??[ 60   $??Log in??6b   $	??115??6s   6   5?      5B      5C      5D      5E      