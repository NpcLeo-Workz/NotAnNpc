using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using DndCharacterCreation_Model;
using System.Windows.Media;
using System.Windows.Input;
using DndCharacterCreation_WPF.Views;

namespace DndCharacterCreation_WPF.ViewModels
{
    public class DynamicNavBarViewModel : BaseViewModel
    {
        public List<Button> Navbarbuttons = new List<Button>();
        #region Relay command
        public RelayCommand _executeButtonCommand;
        public ICommand ExecuteButtonCommand
        {
            get
            {
                if (_executeButtonCommand == null)
                    _executeButtonCommand = new RelayCommand(param => this.Execute(param));
                return _executeButtonCommand;
            }
        }
        #endregion
        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Languages": return true;
            }
            return true;
        }
        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Languages": ShowLanguages(); break;
            }
        }
        public void AddButtonsToNavbar()
        {
            switch (Session.logintype)
            {
                case "Admin":
                    AddLanguagesbutton();
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
            btnLanguages.CommandParameter = "Languages";
            btnLanguages.Command = ExecuteButtonCommand;
            Grid.SetColumn(btnLanguages, 3);
            Navbarbuttons.Add(btnLanguages);
        }
        public void ShowLanguages()
        {
            LanguagesView view = new LanguagesView();
            LanguagesViewModel vm = new LanguagesViewModel();
            view.DataContext = vm;
            Session.ClosePreviousWindow(view);
            view.Show();

        }
        public override string this[string columnName] => throw new NotImplementedException();
    }
}
