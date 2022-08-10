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
            Session.logintype = "User";
            RaceView view = new RaceView();
            RaceViewModel vm = new RaceViewModel();
            view.DataContext = vm;
            Session.ClosePreviousWindow(view);
            view.Show();
        }

        private void btnRaceAdmin_Click(object sender, RoutedEventArgs e)
        {
            Session.logintype = "Admin";
            RaceView view = new RaceView();
            RaceViewModel vm = new RaceViewModel();
            view.DataContext = vm;
            Session.ClosePreviousWindow(view);
            view.Show();
        }
    }
}
