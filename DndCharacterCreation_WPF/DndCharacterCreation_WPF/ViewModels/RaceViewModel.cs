using System;
using System.Linq;
using DndCharacterCreation_DAL.DomainModels;
using DndCharacterCreation_DAL.Data.UnitOfWork;
using DndCharacterCreation_DAL.Data;
using DndCharacterCreation_Model;
using System.Collections.ObjectModel;

namespace DndCharacterCreation_WPF.ViewModels
{
    internal class RaceViewModel : BaseViewModel, IDisposable
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new DndCharacterCreationEntities());
        private Race _SelectedRace;
        public string Language1 { get; set; }
        public string Language2 { get; set; }
        public string Language3 { get; set; }
        public AbilityScoreBonus AbilityScoreBonus { get; set; }
        public ObservableCollection<RaceTrait> RaceTraits { get; set; }
        public ObservableCollection<Trait> Traits { get; set; }
        public ObservableCollection<LanguageRace> LanguageRace1 { get; set; }
        private ObservableCollection<Race> _races;
        public ObservableCollection<Race> Races { get { return _races; } set { _races = value; NotifyPropertyChanged(); } }
        public ObservableCollection<LanguageRace> LanguageRaces { get; set; }
        public Race SelectedRace { get { return _SelectedRace; } set {
                _SelectedRace = value;
                Session.SelectedItemId = _SelectedRace.RaceID;
                if(SelectedRace != null)
                {
                    AbilityScoreBonus = unitOfWork.AbilityScoreBonusRepo.Download(x => x.AbilityScoreBonusID == SelectedRace.AbilityScoreBonusID).SingleOrDefault();
                    LanguageRace1 = new ObservableCollection<LanguageRace>(unitOfWork.LanguageRaceRepo.Download(x => x.RaceID == SelectedRace.RaceID, y => y.Language));
                    RaceTraits = new ObservableCollection<RaceTrait>(unitOfWork.RaceTraitRepo.Download(x => x.RaceID == SelectedRace.RaceID, y => y.Trait));
                    Traits = new ObservableCollection<Trait>();
                    foreach(var item in RaceTraits)
                    {
                        Traits.Add(item.Trait);
                    }
                    Language1 = LanguageRace1[0].Language.Name;
                    Language2 = LanguageRace1[1].Language.Name;
                    Language3 = LanguageRace1[2].Language.Name;
                }
                else
                {
                    AbilityScoreBonus = null;
                    LanguageRace1 = null;
                }
                NotifyPropertyChanged();
            } }
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
