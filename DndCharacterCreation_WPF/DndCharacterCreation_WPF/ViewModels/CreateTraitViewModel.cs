using System;
using System.Linq;
using DndCharacterCreation_DAL.Data.UnitOfWork;
using DndCharacterCreation_DAL.Data;
using DndCharacterCreation_DAL.DomainModels;
using DndCharacterCreation_Model;
using DndCharacterCreation_WPF.Views;

namespace DndCharacterCreation_WPF.ViewModels
{
    internal class CreateTraitViewModel: BaseViewModel, IDisposable
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new DndCharacterCreationEntities());
        public string Name { get; set; }
        public string Description { get; set; }
        public void AddTrait()
        {
            //checks if item already exists
            if(!unitOfWork.TraitRepo.Download(x=>x.Name == Name).Any())
            {
                // creates new trait
                Trait trait = new Trait()
                {
                    Name = Name,
                    Description = Description
                };
                if (IsValid())
                {
                    unitOfWork.TraitRepo.Add(trait);
                    unitOfWork.Save();
                }
                // creates new trait view
                TraitsView view = new TraitsView();
                TraitsViewModel vm = new TraitsViewModel();
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
                case "AddTrait": AddTrait(); break;
                case "Cancel": Cancel(); break;
            }
        }
        public void Dispose()
        {
            unitOfWork?.Dispose();
        }
    }
}
