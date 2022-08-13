using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DndCharacterCreation_DAL.Data.UnitOfWork;
using DndCharacterCreation_DAL.Data;
using DndCharacterCreation_DAL.DomainModels;
using DndCharacterCreation_Model;
using System.Collections.ObjectModel;
using DndCharacterCreation_WPF.Views;
using DndCharacterCreation_WPF.ViewModels;

namespace DndCharacterCreation_WPF.ViewModels
{
    internal class CreateLanguageViewModel: BaseViewModel, IDisposable
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new DndCharacterCreationEntities());
        public string Name { get; set; }
        public string Description { get; set; }
        private void AddLanguage()
        {
            if(!unitOfWork.LanguageRepo.Download(x => x.Name == Name).Any())
            {
                Language lang = new Language()
                {
                    Name = Name,
                    Description = Description
                };
                if (IsValid())
                {
                    unitOfWork.LanguageRepo.Add(lang);
                    unitOfWork.Save();
                }
                LanguagesView view = new LanguagesView();
                LanguagesViewModel vm = new LanguagesViewModel();
                view.DataContext = vm;
                Session.ClosePreviousWindow(view);
                view.Show();
            }

            

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
        public void Cancel()
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
                case "AddLanguage": AddLanguage(); break;
                case "Cancel": Cancel(); break;
            }
        }
        public void Dispose()
        {
            unitOfWork?.Dispose();
        }
    }
}
