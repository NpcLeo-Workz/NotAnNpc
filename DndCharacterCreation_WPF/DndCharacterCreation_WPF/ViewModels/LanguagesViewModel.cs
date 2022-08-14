using System;
using DndCharacterCreation_DAL.DomainModels;
using DndCharacterCreation_DAL.Data.UnitOfWork;
using DndCharacterCreation_DAL.Data;
using DndCharacterCreation_Model;
using System.Collections.ObjectModel;

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
