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
    internal class RaceViewModel : BaseViewModel, IDisposable
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new DndCharacterCreationEntities());    
        public ObservableCollection<Race> Races { get; set; }
        public ObservableCollection<LanguageRace> LanguageRaces { get; set; }
        public RaceViewModel()
        {         
            Races = new ObservableCollection<Race>(unitOfWork.RaceRepo.Download(x => x.abilityScoreBonus));           
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
