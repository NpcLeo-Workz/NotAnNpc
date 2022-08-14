using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Controls;
using DndCharacterCreation_Model;
using System.Windows.Media;
using System.Windows.Input;
using DndCharacterCreation_WPF.Views;
using DndCharacterCreation_DAL.Data.UnitOfWork;
using DndCharacterCreation_DAL.Data;
using DndCharacterCreation_DAL.DomainModels;

namespace DndCharacterCreation_WPF.ViewModels
{
    public class CRUDRaceViewModel : BaseViewModel, IDisposable
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new DndCharacterCreationEntities());
        // the CRUDRaceViewModel is responsible for adding the needed buttons to the Crudbuttons list
        public List<Button> Crudbuttons = new List<Button>();
        public RelayCommand _executeButtonCommand;
        public Race SelectedRace { get; set; }
        public Language SelectedLanguage { get; set; }
        public Trait SelectedTrait { get; set; }
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
                case "Edit": return true;
                case "Delete": return true;
                case "Create": return true;
            }
            return true;
        }
        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Edit": ShowEditView(); break;
                case "Delete": DeleteRace(); break;
                case "Create": Create(); break;
            }
        }
        public void Create()
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
                case "TraitView":
                    CreateTraitView view2 = new CreateTraitView();
                    CreateTraitViewModel vm2 = new CreateTraitViewModel();
                    Session.ClosePreviousWindow(view2);
                    view2.DataContext = vm2;
                    view2.Show();
                    break;
            }
        }
        public void AddButtonsToCrudbar()
        {
            // creates the correct buttons according to the session.logintype
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
            btnDelete.Height = double.NaN;
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
            btnEdit.Height = double.NaN;
            btnEdit.CommandParameter = "Edit";
            btnEdit.Command = ExecuteButtonCommand;
            Grid.SetColumn(btnEdit, 1);
            Crudbuttons.Add(btnEdit);
        }

        public void ShowEditView()
        {
            switch(Session.activewindowname){
                case "RaceView":
                    EditRaceView view = new EditRaceView();
                    EditRaceViewModel vm = new EditRaceViewModel();
                    Session.ClosePreviousWindow(view);
                    view.DataContext = vm;
                    view.Show();
                    break;
                case "LanguageView":
                    EditLanguageView view1 = new EditLanguageView();
                    EditLanguageViewModel vm1 = new EditLanguageViewModel();
                    Session.ClosePreviousWindow(view1);
                    view1.DataContext = vm1;
                    view1.Show();
                    break;
                case "TraitView":
                    EditTraitView view2 = new EditTraitView();
                    EditTraitViewModel vm2 = new EditTraitViewModel();
                    Session.ClosePreviousWindow(view2);
                    view2.DataContext = vm2;
                    view2.Show();
                    break;
            }
            
        }
        public void DeleteRace()
        {
            switch (Session.activewindowname)
            {
                case "RaceView":
                    SelectedRace = unitOfWork.RaceRepo.Download(x => x.RaceID == Session.SelectedItemId, y => y.abilityScoreBonus).SingleOrDefault();
                    unitOfWork.RaceRepo.Delete(SelectedRace);
                    unitOfWork.Save();
                    break;
                case "LanguageView":
                    SelectedLanguage = unitOfWork.LanguageRepo.Download(x => x.LanguageID == Session.SelectedItemId).SingleOrDefault();
                    unitOfWork.LanguageRepo.Delete(SelectedLanguage);
                    unitOfWork.Save();
                    break;
                case "TraitView":
                    SelectedTrait = unitOfWork.TraitRepo.Download(x => x.TraitID == Session.SelectedItemId).SingleOrDefault();
                    unitOfWork.TraitRepo.Delete(SelectedTrait);
                    unitOfWork.Save();
                    break;
            }
            
            
        }
        public override string this[string columnName] => throw new NotImplementedException();
        public void Dispose()
        {
            unitOfWork?.Dispose();
        }
    }
}
