using System.Windows;
using System.Windows.Controls;
using DndCharacterCreation_WPF.ViewModels;

namespace DndCharacterCreation_WPF.UserControls
{
    /// <summary>
    /// Interaction logic for NavBar.xaml
    /// </summary>
    public partial class NavBar : UserControl
    {
        public NavBar()
        {
            InitializeComponent();
        }
        DynamicNavBarViewModel vm = new DynamicNavBarViewModel();
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //Adds the dynamically created buttons to the user control
            this.DataContext = vm;
            vm.AddButtonsToNavbar();
            foreach (var item in vm.Navbarbuttons)
            {
                navbar.Children.Add(item);
            }
        }       
    }
}
