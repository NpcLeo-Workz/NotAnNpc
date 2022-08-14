using System;
using System.Linq;
using DndCharacterCreation_DAL.Data.UnitOfWork;
using DndCharacterCreation_DAL.Data;
using DndCharacterCreation_DAL.DomainModels;
using DndCharacterCreation_Model;
using DndCharacterCreation_WPF.Views;

namespace DndCharacterCreation_WPF.ViewModels
{
    internal class EditTraitViewModel: BaseViewModel, IDisposable
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new DndCharacterCreationEntities());
        public string Name { get; set; }
        public string Description { get; set; }
        private Trait SelectedTrait;
        public EditTraitViewModel()
        {
            SelectedTrait = unitOfWork.TraitRepo.Download(x => x.TraitID == Session.SelectedItemId).SingleOrDefault();
            Name = SelectedTrait.Name;
            Description = SelectedTrait.Description;
        }
        public void EditCurrentTrait()
        {
            if(!unitOfWork.TraitRepo.Download(x=>x.Name == Name).Any() || unitOfWork.TraitRepo.Download(x=>x.Name ==Name).SingleOrDefault().TraitID == SelectedTrait.TraitID)
            {
                SelectedTrait.Name = Name;
                SelectedTrait.Description = Description;
                if (IsValid())
                {
                    unitOfWork.TraitRepo.Edit(SelectedTrait);
                    unitOfWork.Save();
                }
            }
            TraitsView view = new TraitsView();
            TraitsViewModel vm = new TraitsViewModel();
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
            TraitsView view = new TraitsView();
            TraitsViewModel vm = new TraitsViewModel();
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
                case "EditCurrentTrait": EditCurrentTrait(); break;
                case "CancelEdit": CancelEdit(); break;
            }
        }
        public void Dispose()
        {
            unitOfWork?.Dispose();
        }
    }
}
