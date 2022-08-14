using System;
using System.Collections.Generic;
using System.Linq;
using DndCharacterCreation_DAL.Data.UnitOfWork;
using DndCharacterCreation_DAL.Data;
using DndCharacterCreation_DAL.DomainModels;
using DndCharacterCreation_Model;
using System.Collections.ObjectModel;
using DndCharacterCreation_WPF.Views;

namespace DndCharacterCreation_WPF.ViewModels
{
    internal class CreateRaceViewModel : BaseViewModel, IDisposable
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new DndCharacterCreationEntities());
        public ObservableCollection<Language> Languages { get; set; }
        public ObservableCollection<AbilityScoreBonus> AbilityScoreBonus { get; set; }
        public ObservableCollection<Race> Races { get; set; }
        private ObservableCollection<Trait> _traits;
        public ObservableCollection<Trait> Traits { get { return _traits; } set {_traits = value; NotifyPropertyChanged(); } }
        private ObservableCollection<Trait> _selectedtraits;
        public ObservableCollection<Trait> SelectedTraits { get { return _selectedtraits; } set { _selectedtraits = value; NotifyPropertyChanged(); } }
        public string Name { get; set; }
        public string Str { get; set; }
        public string Dex { get; set; }
        public string Con { get; set; }
        public string Int { get; set; }
        public string Wis { get; set; }
        public string Cha { get; set; }
        public string Size { get; set; }
        public string WalkSpeed { get; set; }
        public string SwimSpeed { get; set; }
        public string FlySpeed { get; set; }
        public string ClimbSpeed { get; set; }
        public string CreatureType { get; set;}
        public Trait SelectedTraitcbx { get; set; }
        public Trait SelectedTrait { get; set; }
        public Race RaceCheck { get; set; }
        public Language SelectedLanguage1 { get; set; }
        public Language SelectedLanguage2 { get; set; }
        public Language SelectedLanguage3 { get; set; }

        public CreateRaceViewModel()
        {
            //loads all languages
            Languages = new ObservableCollection<Language>(unitOfWork.LanguageRepo.Download());
            //loads all abilityscores
            AbilityScoreBonus = new ObservableCollection<AbilityScoreBonus>(unitOfWork.AbilityScoreBonusRepo.Download());
            //loads all traits
            Traits = new ObservableCollection<Trait>(unitOfWork.TraitRepo.Download());
            //creates empty traits observable collection
            SelectedTraits = new ObservableCollection<Trait>();
        }

        private void AddRace()
        {
            //checks if Race exists
            if(!unitOfWork.RaceRepo.Download(x => x.Name == Name).Any()){
                //creates new race
                Race race = new Race()
                {
                    Name = Name,
                    AbilityScoreBonusID = CheckAbilityScores(),
                    Size = Size,
                    SpeedWalk = int.Parse(WalkSpeed),
                    SpeedSwim = int.Parse(SwimSpeed),
                    SpeedClimb = int.Parse(ClimbSpeed),
                    SpeedFly = int.Parse(FlySpeed),
                    CreatureType = CreatureType

                };
                if (IsValid())
                {
                    unitOfWork.RaceRepo.Add(race);
                    unitOfWork.Save();
                    //checks and creates links with race and language
                    AddLanguageRace(race);
                    //checks and creates links with race and trait
                    AddRaceTrait(race);
                }
                //creates new RaceView
                RaceView view = new RaceView();
                RaceViewModel vm = new RaceViewModel();
                view.DataContext = vm;
                Session.ClosePreviousWindow(view);
                view.Show();
            }   
        }
        public void AddRaceTrait(Race race)
        {
            //downloads just created Race
            RaceCheck = unitOfWork.RaceRepo.Download(r => r.Name == race.Name).SingleOrDefault();
            // checks for each selected trait if a link between the trait and race exists
            foreach(var item in SelectedTraits)
            {
                if(!unitOfWork.RaceTraitRepo.Download(x=>x.RaceID == RaceCheck.RaceID , x=>x.TraitID == item.TraitID).Any())
                {
                    //Creates new race trait link
                    RaceTrait raceTrait = new RaceTrait()
                    {
                        RaceID = RaceCheck.RaceID,
                        TraitID = item.TraitID
                    };
                    if (IsValid())
                    {
                        unitOfWork.RaceTraitRepo.Add(raceTrait);
                        unitOfWork.Save();
                    }
                }
                        
            }
        }
        public void AddTraitToRace()
        {
            //Adds trait to the list and removes from combobox
            SelectedTraits.Add(SelectedTraitcbx);
            Traits.Remove(SelectedTraitcbx);
        }
        public void RemoveTraitFromRace()
        {
            //adds trait to combobox and removes from list
            Traits.Add(SelectedTrait);
            SelectedTraits.Remove(SelectedTrait);
            
        }
        public void AddLanguageRace(Race race)
        {
            // creates link between languages and race
            int RaceID=0;
            Races = new ObservableCollection<Race>(unitOfWork.RaceRepo.Download());
            IEnumerable<Race> races = Races.Where(c => c.Name == race.Name);
           
            foreach (var item in races)
            {
                RaceID = item.RaceID;

            }          
            LanguageRace languageRace1 = new LanguageRace()
            {
                RaceID = RaceID,
                LanguageID = SelectedLanguage1.LanguageID
            };
            LanguageRace languageRace2 = new LanguageRace()
            {
                RaceID = RaceID,
                LanguageID = SelectedLanguage2.LanguageID
            };
            LanguageRace languageRace3 = new LanguageRace()
            {
                RaceID = RaceID,
                LanguageID = SelectedLanguage3.LanguageID
            };
            if (IsValid())
            {
                unitOfWork.LanguageRaceRepo.Add(languageRace1);
                unitOfWork.LanguageRaceRepo.Add(languageRace2);
                unitOfWork.LanguageRaceRepo.Add(languageRace3);
                int ok = unitOfWork.Save();
            }
        }
        public int CheckAbilityScores()
        {
            //creates new abilityscore object
            int AsbId=0;
            AbilityScoreBonus abilityScoreBonus = new AbilityScoreBonus()
            
            {
                strength = int.Parse(Str),
                dexterity= int.Parse(Dex),
                constitution = int.Parse(Con),
                inteligence = int.Parse(Int),
                wisdom = int.Parse(Wis),
                charisma = int.Parse(Cha)

            };
            //checks if there already exists an ability score with the same properties
            IEnumerable<AbilityScoreBonus> abilityScoreBonus1 = AbilityScoreBonus.Where(c => c.strength == abilityScoreBonus.strength)
                .Where(c => c.dexterity == abilityScoreBonus.dexterity)
                .Where(c => c.constitution == abilityScoreBonus.constitution)
                .Where(c => c.inteligence == abilityScoreBonus.inteligence)
                .Where(c => c.wisdom == abilityScoreBonus.wisdom)
                .Where(c => c.charisma == abilityScoreBonus.charisma);
            if(!abilityScoreBonus1.Any())
            {
                if (IsValid())
                {
                    unitOfWork.AbilityScoreBonusRepo.Add(abilityScoreBonus);
                    int ok = unitOfWork.Save();
                }
            }
            //returns the abilityscorebonus Id
            AbilityScoreBonus = new ObservableCollection<AbilityScoreBonus>(unitOfWork.AbilityScoreBonusRepo.Download());
            abilityScoreBonus1 = AbilityScoreBonus.Where(c => c.strength == abilityScoreBonus.strength)
                .Where(c => c.dexterity == abilityScoreBonus.dexterity)
                .Where(c => c.constitution == abilityScoreBonus.constitution)
                .Where(c => c.inteligence == abilityScoreBonus.inteligence)
                .Where(c => c.wisdom == abilityScoreBonus.wisdom)
                .Where(c => c.charisma == abilityScoreBonus.charisma);
            AsbId = abilityScoreBonus1.First().AbilityScoreBonusID;
            return AsbId;
        }
        public override string this[string columnName]
        {
            get
            {
                if(columnName == "Name" && string.IsNullOrWhiteSpace(Name))
                {
                    return "Name is empty!" + Environment.NewLine;
                }
                return "";
            }
        }
        public void Cancel()
        {
            RaceView view = new RaceView();
            RaceViewModel vm = new RaceViewModel();
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
                case "AddRace": AddRace(); break;
                case "Cancel": Cancel(); break;
                case "AddTraitToRace": AddTraitToRace(); break;
                case "RemoveTraitFromRace": RemoveTraitFromRace(); break;
            }
        }
        public void Dispose()
        {
            unitOfWork?.Dispose();
        }
    }
}
