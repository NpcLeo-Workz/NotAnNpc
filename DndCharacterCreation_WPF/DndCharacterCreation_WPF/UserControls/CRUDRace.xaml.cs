using System.Windows;
using System.Windows.Controls;
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
            //Adds the dynamically created buttons to the user control
            this.DataContext = vm;
            vm.AddButtonsToCrudbar();
            foreach (var item in vm.Crudbuttons)
            {
                crudbar.Children.Add(item);
            }
        }
      
    }
}
