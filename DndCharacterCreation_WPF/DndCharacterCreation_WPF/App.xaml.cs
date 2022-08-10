using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DndCharacterCreation_WPF.ViewModels;
using System.Windows;
using DndCharacterCreation_Model;

namespace DndCharacterCreation_WPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            MainViewModel viewmodel = new MainViewModel();
            Views.MainView view = new Views.MainView();
            Session.ClosePreviousWindow(view);
            view.DataContext = viewmodel;
            view.Show();
        }
    }

}
