using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using DndCharacterCreation_DAL.DomainModels;
using DndCharacterCreation_DAL.Data.UnitOfWork;
using DndCharacterCreation_DAL.Data;
using DndCharacterCreation_Model;
using System.Collections.ObjectModel;
using DndCharacterCreation_WPF.Views;
using DndCharacterCreation_WPF.ViewModels;

namespace DndCharacterCreation_WPF.ViewModels
{
    internal class LanguagesViewModel: BaseViewModel, IDisposable
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new DndCharacterCreationEntities());
        public ObservableCollection<Language> Languages { get; set; }
        private Language _selectedLanguage;
        public Language SelectedLanguage { get { return _selectedLanguage; } set { _selectedLanguage = value; 
                Session.SelectedItemId = _selectedLanguage.LanguageID;           
                NotifyPropertyChanged();
            }
        }
        public LanguagesViewModel()
        {
            Languages = new ObservableCollection<Language>(unitOfWork.LanguageRepo.Download());
        }
        public override string this[string columnName] => throw new NotImplementedException();
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {

            }
        }
        public void Dispose()
        {
            unitOfWork?.Dispose();
        }
    }
}
