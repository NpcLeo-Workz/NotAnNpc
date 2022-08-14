using System;
using DndCharacterCreation_WPF.Views;
using DndCharacterCreation_Model;

namespace DndCharacterCreation_WPF.ViewModels
{
    class MainViewModel: BaseViewModel
    {
        public MainViewModel()
        {
        }
        public void ShowRaceView(string logintype)
        {
            Session.logintype = logintype;
            Session.activewindowname = "RaceView";
            RaceView view = new RaceView();
            RaceViewModel vm = new RaceViewModel();
            view.DataContext = vm;
            // closes previous window
            Session.ClosePreviousWindow(view);
            view.Show();
        }
        public override string this[string columnName] => throw new NotImplementedException();
        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "LoginUser": return true;
                case "LoginAdmin": return true;
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "LoginUser": ShowRaceView("User"); break;
                case "LoginAdmin": ShowRaceView("Admin"); break;
            }
        }      
    }
}
