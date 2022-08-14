using System;
using DndCharacterCreation_DAL.DomainModels;
using DndCharacterCreation_DAL.Data.UnitOfWork;
using DndCharacterCreation_DAL.Data;
using DndCharacterCreation_Model;
using System.Collections.ObjectModel;

namespace DndCharacterCreation_WPF.ViewModels
{
    internal class TraitsViewModel: BaseViewModel, IDisposable
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new DndCharacterCreationEntities());
        public ObservableCollection<Trait> Traits { get; set; }
        private Trait _selectedTrait;
        public Trait SelectedTrait { get { return _selectedTrait; } set { _selectedTrait = value;
                Session.SelectedItemId = _selectedTrait.TraitID;
                NotifyPropertyChanged();
            }
        }
        public TraitsViewModel()
        {
            Traits = new ObservableCollection<Trait>(unitOfWork.TraitRepo.Download());

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
