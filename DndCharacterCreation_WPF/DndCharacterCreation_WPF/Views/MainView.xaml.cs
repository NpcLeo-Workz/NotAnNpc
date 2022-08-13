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
using System.Windows.Shapes;
using DndCharacterCreation_WPF.Views;
using DndCharacterCreation_WPF.ViewModels;
using DndCharacterCreation_Model;
using DndCharacterCreation_WPF.UserControls;

namespace DndCharacterCreation_WPF.Views
{
    /// <summary>
    /// Interaction logic for MainView.xaml
    /// </summary>
    public partial class MainView : Window
    {
        public MainView()
        {
            InitializeComponent();
            
        }
        private void btnRace_Click(object sender, RoutedEventArgs e)
        {
            // Opens Race view as user
            Session.logintype = "User";
            Session.activewindowname = "RaceView";
            RaceView view = new RaceView();
            RaceViewModel vm = new RaceViewModel();
            view.DataContext = vm;
            // closes previous window
            Session.ClosePreviousWindow(view);
            view.Show();
        }

        private void btnRaceAdmin_Click(object sender, RoutedEventArgs e)
        {
            // Opens Race view as Admin
            Session.logintype = "Admin";
            Session.activewindowname = "RaceView";
            RaceView view = new RaceView();
            RaceViewModel vm = new RaceViewModel();
            view.DataContext = vm;
            // Closes previous window
            Session.ClosePreviousWindow(view);
            view.Show();
        }
    }
}
