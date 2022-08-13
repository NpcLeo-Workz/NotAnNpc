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
using DndCharacterCreation_WPF.Views;
using DndCharacterCreation_WPF.ViewModels;
using DndCharacterCreation_Model;

namespace DndCharacterCreation_WPF.UserControls
{
    /// <summary>
    /// Interaction logic for CRUDRace.xaml
    /// </summary>
    public partial class CRUDRace : UserControl
    {
        public CRUDRace()
        {
            InitializeComponent();
        }
        CRUDRaceViewModel vm = new CRUDRaceViewModel();
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            //Adds the dynamically created buttons to the user control
            this.DataContext = vm;
            vm.AddButtonsToCrudbar();
            foreach (var item in vm.Crudbuttons)
            {
                crudbar.Children.Add(item);
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            switch (Session.activewindowname)
            {
                case "RaceView":
                    //Opens the Create Race Window
                    CreateRaceView view = new CreateRaceView();
                    CreateRaceViewModel vm = new CreateRaceViewModel();
                    Session.ClosePreviousWindow(view);
                    view.DataContext = vm;
                    view.Show();
                    break;
                case "LanguageView":
                    CreateLanguageView view1 = new CreateLanguageView();
                    CreateLanguageViewModel vm1 = new CreateLanguageViewModel();
                    Session.ClosePreviousWindow(view1);
                    view1.DataContext = vm1;
                    view1.Show();
                    break;
            }
            
        }
    }
}
