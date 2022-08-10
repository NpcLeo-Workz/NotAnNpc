using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DndCharacterCreation_Model;
using DndCharacterCreation_WPF.ViewModels;
using DndCharacterCreation_WPF.Views;

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
            this.DataContext = vm;
            vm.AddButtonsToNavbar();
            foreach (var item in vm.Navbarbuttons)
            {
                navbar.Children.Add(item);
            }
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            Session.logintype = "";
            MainView view = new MainView();
            MainViewModel vm = new MainViewModel();
            view.DataContext = vm;
            Session.ClosePreviousWindow(view);
            view.Show();
        }

        private void btnRace_Click(object sender, RoutedEventArgs e)
        {
            RaceView view = new RaceView();
            RaceViewModel vm = new RaceViewModel();
            view.DataContext = vm;
            Session.ClosePreviousWindow(view);
            view.Show();
        }
    }
}
