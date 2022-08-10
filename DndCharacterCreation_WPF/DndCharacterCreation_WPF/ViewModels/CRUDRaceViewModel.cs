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
    public class CRUDRaceViewModel : BaseViewModel
    {
        public List<Button> Crudbuttons = new List<Button>();
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
        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {           
                case "Edit": return true;
                case "Delete": return true;
            }
            return true;
        }
        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                // case "Languages": ShowLanguages(); break;
                case "Edit": ShowEditRaceView(); break;
                case "Delete": DeleteRace(); break;

            }
        }
        public void AddButtonsToCrudbar()
        {
            switch (Session.logintype)
            {
                case "Admin":
                    AddEditbutton();
                    AddDeletebutton();
                    break;
            }
            
        }
        private void AddDeletebutton()
        {
            Button btnDelete = new Button();
            btnDelete.Content = "Delete";
            btnDelete.FontSize = 30;
            btnDelete.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD0A85C"));
            btnDelete.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD0A85C"));
            btnDelete.BorderThickness = new System.Windows.Thickness(1);
            btnDelete.Background = null;
            btnDelete.CommandParameter = "Delete";
            btnDelete.Command = ExecuteButtonCommand;
            Grid.SetColumn(btnDelete, 2);
            Crudbuttons.Add(btnDelete);
        }
        private void AddEditbutton()
        {
            Button btnEdit = new Button();
            btnEdit.Content = "Edit";
            btnEdit.FontSize = 30;
            btnEdit.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD0A85C"));
            btnEdit.BorderBrush = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#FFD0A85C"));
            btnEdit.BorderThickness = new System.Windows.Thickness(1);
            btnEdit.Background = null;
            btnEdit.CommandParameter = "Edit";
            btnEdit.Command = ExecuteButtonCommand;
            Grid.SetColumn(btnEdit, 1);
            Crudbuttons.Add(btnEdit);
        }

        public void ShowEditRaceView()
        {
            EditRaceView view = new EditRaceView();
            EditRaceViewModel vm = new EditRaceViewModel();
            view.DataContext = vm;
            view.Show();
        }
        public void DeleteRace()
        {

        }
        public override string this[string columnName] => throw new NotImplementedException();
    }
}
