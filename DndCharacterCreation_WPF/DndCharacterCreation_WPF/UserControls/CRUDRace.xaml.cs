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
            this.DataContext = vm;
            vm.AddButtonsToCrudbar();
            foreach (var item in vm.Crudbuttons)
            {
                crudbar.Children.Add(item);
            }
        }

        private void btnCreate_Click(object sender, RoutedEventArgs e)
        {
            CreateRaceView view = new CreateRaceView();
            CreateRaceViewModel vm = new CreateRaceViewModel();
            view.DataContext = vm;
            view.Show();
        }
    }
}
