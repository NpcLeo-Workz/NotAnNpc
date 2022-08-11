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
    internal class CreateRaceViewModel : BaseViewModel, IDisposable
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new DndCharacterCreationEntities());
        public ObservableCollection<Language> Languages { get; set; }
        public ObservableCollection<AbilityScoreBonus> AbilityScoreBonus { get; set; }
        public ObservableCollection<Race> Races { get; set; }
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
        public Language SelectedLanguage1 { get; set; }
        public Language SelectedLanguage2 { get; set; }
        public Language SelectedLanguage3 { get; set; }

        public CreateRaceViewModel()
        {
            Languages = new ObservableCollection<Language>(unitOfWork.LanguageRepo.Download());
            AbilityScoreBonus = new ObservableCollection<AbilityScoreBonus>(unitOfWork.AbilityScoreBonusRepo.Download());
            
        }

        private void AddRace()
        {
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
                int ok = unitOfWork.Save();

                AddLanguageRace(race);
            }
            RaceView view = new RaceView();
            RaceViewModel vm = new RaceViewModel();
            view.DataContext = vm;
            Session.ClosePreviousWindow(view);
            view.Show();
            
        }
        public void AddLanguageRace(Race race)
        {
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
            AbilityScoreBonus = new ObservableCollection<AbilityScoreBonus>(unitOfWork.AbilityScoreBonusRepo.Download());
            abilityScoreBonus1 = AbilityScoreBonus.Where(c => c.strength == abilityScoreBonus.strength)
                .Where(c => c.dexterity == abilityScoreBonus.dexterity)
                .Where(c => c.constitution == abilityScoreBonus.constitution)
                .Where(c => c.inteligence == abilityScoreBonus.inteligence)
                .Where(c => c.wisdom == abilityScoreBonus.wisdom)
                .Where(c => c.charisma == abilityScoreBonus.charisma);
            foreach(var item in abilityScoreBonus1)
            {
                
                AsbId = item.AbilityScoreBonusID;
                Console.WriteLine(AsbId);
            }
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

        public override bool CanExecute(object parameter)
        {
            return true;
        }
        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "AddRace": AddRace(); break;
            }
        }
        public void Dispose()
        {
            unitOfWork?.Dispose();
        }
    }
}
