using System;
using System.Linq;
using DndCharacterCreation_DAL.Data.UnitOfWork;
using DndCharacterCreation_DAL.Data;
using DndCharacterCreation_DAL.DomainModels;
using DndCharacterCreation_Model;
using DndCharacterCreation_WPF.Views;

namespace DndCharacterCreation_WPF.ViewModels
{
    class EditLanguageViewModel: BaseViewModel , IDisposable
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new DndCharacterCreationEntities());
        public string Name { get; set; }
        public string Description { get; set; }
        public Language SelectedLanguage;
        public EditLanguageViewModel()
        {
            SelectedLanguage = unitOfWork.LanguageRepo.Download(x => x.LanguageID == Session.SelectedItemId).SingleOrDefault();
            Name = SelectedLanguage.Name;
            Description = SelectedLanguage.Description;
        }
        private void EditCurrentLanguage()
        {
            if(!unitOfWork.LanguageRepo.Download(x=>x.Name == Name).Any() || unitOfWork.LanguageRepo.Download(x => x.Name == Name).SingleOrDefault().LanguageID == SelectedLanguage.LanguageID)
            {
                SelectedLanguage.Name = Name;
                SelectedLanguage.Description = Description;
                if (IsValid())
                {
                    unitOfWork.LanguageRepo.Edit(SelectedLanguage);
                    unitOfWork.Save();
                }
            }
            LanguagesView view = new LanguagesView();
            LanguagesViewModel vm = new LanguagesViewModel();
            view.DataContext = vm;
            Session.ClosePreviousWindow(view);
            view.Show();
            
        }
        public override string this[string columnName]
        {
            get
            {
                if (columnName == "Name" && string.IsNullOrWhiteSpace(Name))
                {
                    return "Name is empty!" + Environment.NewLine;
                }
                return "";
            }
        }
        public void CancelEdit()
        {
            LanguagesView view = new LanguagesView();
            LanguagesViewModel vm = new LanguagesViewModel();
            view.DataContext = vm;
            Session.ClosePreviousWindow(view);
            view.Show();
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "EditCurrentLanguage": EditCurrentLanguage(); break;
                case "CancelEdit": CancelEdit(); break;
            }
        }
        public void Dispose()
        {
            unitOfWork?.Dispose();
        }
    }
}
