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
     class EditRaceViewModel : BaseViewModel, IDisposable
    {
        private UnitOfWork unitOfWork = new UnitOfWork(new DndCharacterCreationEntities());
        public ObservableCollection<Language> Languages { get; set; }
        public ObservableCollection<LanguageRace> LanguageRaces { get {return _languageRaces; } set { _languageRaces = value; NotifyPropertyChanged(); } }

        public AbilityScoreBonus AbilityScoreBonus { get; set; }
        private ObservableCollection<LanguageRace> _languageRaces;
        public ObservableCollection<AbilityScoreBonus> AbilityScoreBonuses { get; set; }      
        
        public Race SelectedRace { get ; set ; }
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
        public string CreatureType { get; set; }
        public Language SelectedLanguage1 { get; set; }
        public Language SelectedLanguage2 { get; set; }
        public Language SelectedLanguage3 { get; set; }

        public EditRaceViewModel()
        {
            SelectedRace = unitOfWork.RaceRepo.Download(x => x.RaceID == Session.SelectedItemId, y => y.abilityScoreBonus).SingleOrDefault();
            Languages = new ObservableCollection<Language>(unitOfWork.LanguageRepo.Download());
            LanguageRaces = new ObservableCollection<LanguageRace>(unitOfWork.LanguageRaceRepo.Download(x => x.RaceID == SelectedRace.RaceID));
            AbilityScoreBonus = unitOfWork.AbilityScoreBonusRepo.Download(x => x.AbilityScoreBonusID == SelectedRace.AbilityScoreBonusID).SingleOrDefault();
            AbilityScoreBonuses = new ObservableCollection<AbilityScoreBonus>(unitOfWork.AbilityScoreBonusRepo.Download());
            
            Name = SelectedRace.Name;
            Str = SelectedRace.abilityScoreBonus.strength.ToString();
            Dex = SelectedRace.abilityScoreBonus.dexterity.ToString();
            Con = SelectedRace.abilityScoreBonus.constitution.ToString();
            Int = SelectedRace.abilityScoreBonus.inteligence.ToString();
            Wis = SelectedRace.abilityScoreBonus.wisdom.ToString();
            Cha = SelectedRace.abilityScoreBonus.charisma.ToString();
            Size = SelectedRace.Size;
            WalkSpeed = SelectedRace.SpeedWalk.ToString();
            SwimSpeed = SelectedRace.SpeedSwim.ToString();
            FlySpeed = SelectedRace.SpeedFly.ToString();
            ClimbSpeed = SelectedRace.SpeedClimb.ToString();
            CreatureType = SelectedRace.CreatureType;
            SelectedLanguage1 = LanguageRaces[0].Language;
            SelectedLanguage2 = LanguageRaces[1].Language;
            SelectedLanguage3 = LanguageRaces[2].Language;
        }
        
        private void EditCurrentRace()
        {
            if(!unitOfWork.RaceRepo.Download(x=>x.Name == Name).Any() || unitOfWork.RaceRepo.Download(x => x.Name == Name).SingleOrDefault().RaceID == SelectedRace.RaceID)
            {
                SelectedRace.Name = Name;           
                SelectedRace.Size = Size;
                SelectedRace.SpeedWalk = int.Parse(WalkSpeed);
                SelectedRace.SpeedSwim = int.Parse(SwimSpeed);
                SelectedRace.SpeedClimb = int.Parse(ClimbSpeed);
                SelectedRace.SpeedFly = int.Parse(FlySpeed);
                SelectedRace.CreatureType = CreatureType;
                if (IsValid())
                {
                    CheckAbilityScores();
                    CheckLanguageRace();
                    unitOfWork.RaceRepo.Edit(SelectedRace);
                    int ok = unitOfWork.Save();
              
                }
            }
            
            RaceView view = new RaceView();
            RaceViewModel vm = new RaceViewModel();
            view.DataContext = vm;
            Session.ClosePreviousWindow(view);
            view.Show();

        }
        public void CheckLanguageRace()
        {
            LanguageRaces[0].Language = SelectedLanguage1;
            LanguageRaces[1].Language = SelectedLanguage2;
            LanguageRaces[2].Language = SelectedLanguage3;
            foreach (var item in LanguageRaces)
            {
                unitOfWork.LanguageRaceRepo.Edit(item);
            }
        }
        public void CheckAbilityScores()
        {           
            AbilityScoreBonus abilityScoreBonus = new AbilityScoreBonus()

            {
                strength = int.Parse(Str),
                dexterity = int.Parse(Dex),
                constitution = int.Parse(Con),
                inteligence = int.Parse(Int),
                wisdom = int.Parse(Wis),
                charisma = int.Parse(Cha)

            };

            IEnumerable<AbilityScoreBonus> abilityScoreBonus1 = AbilityScoreBonuses.Where(c => c.strength == abilityScoreBonus.strength)
                .Where(c => c.dexterity == abilityScoreBonus.dexterity)
                .Where(c => c.constitution == abilityScoreBonus.constitution)
                .Where(c => c.inteligence == abilityScoreBonus.inteligence)
                .Where(c => c.wisdom == abilityScoreBonus.wisdom)
                .Where(c => c.charisma == abilityScoreBonus.charisma);
            if (!abilityScoreBonus1.Any())
            {
                if (IsValid())
                {
                    unitOfWork.AbilityScoreBonusRepo.Add(abilityScoreBonus);
                    int ok = unitOfWork.Save();
                    AbilityScoreBonuses = new ObservableCollection<AbilityScoreBonus>(unitOfWork.AbilityScoreBonusRepo.Download());
                    SelectedRace.AbilityScoreBonusID = AbilityScoreBonuses.Last().AbilityScoreBonusID;
                }
            }
            else
            {
                SelectedRace.AbilityScoreBonusID = abilityScoreBonus1.First().AbilityScoreBonusID;
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
        public void CancelEdit()
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
                case "EditCurrentRace": EditCurrentRace(); break;
                case "CancelEdit": CancelEdit(); break;
            }
        }
        public void Dispose()
        {
            unitOfWork?.Dispose();
        }
    }
}
