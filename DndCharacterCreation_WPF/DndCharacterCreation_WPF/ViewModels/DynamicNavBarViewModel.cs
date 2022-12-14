using System;
using System.Collections.Generic;
using System.Windows.Controls;
using DndCharacterCreation_Model;
using System.Windows.Media;
using System.Windows.Input;
using DndCharacterCreation_WPF.Views;

namespace DndCharacterCreation_WPF.ViewModels
{
    public class DynamicNavBarViewModel : BaseViewModel
    {
        // the DynamicNavBarViewModel is responsible for adding the needed buttons to the NavBarbuttons list
        public List<Button> Navbarbuttons = new List<Button>();
        public RelayCommand _executeButtonCommand;
        //the relaycommand executebuttoncommand is used to add the executecommand to the dynamically created buttons with the right parameter
        public ICommand ExecuteButtonCommand
        {
            get
            {
                if (_executeButtonCommand == null)
                    _executeButtonCommand = new RelayCommand(param => this.Execute(param));
                return _executeButtonCommand;
            }
        }
        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Languages": return true;
                case "Traits": return true;
                case "Logout": return true;
                case "Races": return true;
            }
            return true;
        }
        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Languages": ShowLanguages(); break;
                case "Traits": ShowTraits(); break;
                case "Logout": Logout(); break;
                case "Races": ShowRaces(); break;
            }
        }
        public void ShowRaces()
        {
            Session.activewindowname = "RaceView";
            RaceView view = new RaceView();
            RaceViewModel vm = new RaceViewModel();
            view.DataContext = vm;
            Session.ClosePreviousWindow(view);
            view.Show();
        }
        public void Logout()
        {
            Session.logintype = "";
            MainView view = new MainView();
            MainViewModel vm = new MainViewModel();
            view.DataContext = vm;
            Session.ClosePreviousWindow(view);
            view.Show();
        }
        public void AddButtonsToNavbar()
        {
            // creates the correct buttons according to the session.logintype
            switch (Session.logintype)
            {
                case "Admin":
                    AddLanguagesbutton();
                    AddTraitsbutton();
                    break;
            }
        }
        private void AddLanguagesbutton()
        {
            Button btnLanguages = new Button();
            btnLanguages.Content = "Languages";
            btnLanguages.FontSize = 30;
            btnLanguages.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD0A85C"));
            btnLanguages.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD0A85C"));
            btnLanguages.BorderThickness = new System.Windows.Thickness(1,0,0,0);
            btnLanguages.Background = null;
            btnLanguages.Height = double.NaN;
            btnLanguages.CommandParameter = "Languages";
            btnLanguages.Command = ExecuteButtonCommand;
            Grid.SetColumn(btnLanguages, 3);
            Navbarbuttons.Add(btnLanguages);
        }
        private void AddTraitsbutton()
        {

            Button btnTraits = new Button();
            btnTraits.Content = "Traits";
            btnTraits.FontSize = 30;
            btnTraits.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD0A85C"));
            btnTraits.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD0A85C"));
            btnTraits.BorderThickness = new System.Windows.Thickness(1, 0, 0, 0);
            btnTraits.Background = null;
            btnTraits.Height = double.NaN;
            btnTraits.CommandParameter = "Traits";
            btnTraits.Command = ExecuteButtonCommand;
            Grid.SetColumn(btnTraits, 2);
            Navbarbuttons.Add(btnTraits);
        }
        public void ShowLanguages()
        {
            Session.activewindowname = "LanguageView";
            LanguagesView view = new LanguagesView();
            LanguagesViewModel vm = new LanguagesViewModel();
            view.DataContext = vm;
            Session.ClosePreviousWindow(view);
            view.Show();

        }
        public void ShowTraits()
        {
            Session.activewindowname = "TraitView";
            TraitsView view = new TraitsView();
            TraitsViewModel vm = new TraitsViewModel();
            view.DataContext = vm;
            Session.ClosePreviousWindow(view);
            view.Show();
        }
        public override string this[string columnName] => throw new NotImplementedException();
    }
}
