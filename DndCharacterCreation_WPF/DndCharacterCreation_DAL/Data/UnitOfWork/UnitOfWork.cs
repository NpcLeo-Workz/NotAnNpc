using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DndCharacterCreation_DAL.Data.Repositories;
using DndCharacterCreation_DAL.DomainModels;

namespace DndCharacterCreation_DAL.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IRepository<AbilityScoreBonus> _abilityScoreBonusRepo;
        private IRepository<Language> _languageRepo;
        private IRepository<LanguageRace> _languageRaceRepo;
        private IRepository<Race> _raceRepo;
        private IRepository<RaceTrait> _raceTraitRepo;
        private IRepository<Trait> _traitRepo;

        private DndCharacterCreationEntities DndCharacterCreationEntities { get; }
        public UnitOfWork(DndCharacterCreationEntities dndCharacterCreationEntities)
        {
            this.DndCharacterCreationEntities = dndCharacterCreationEntities;
        }

        public IRepository<AbilityScoreBonus> AbilityScoreBonusRepo
        {
            get
            {
                if (_abilityScoreBonusRepo == null)
                {
                    _abilityScoreBonusRepo = new Repository<AbilityScoreBonus>(this.DndCharacterCreationEntities);
                }
                return _abilityScoreBonusRepo;
            }
        }
        public IRepository<Language> LanguageRepo
        {
            get
            {
                if (_languageRepo == null)
                {
                    _languageRepo = new Repository<Language>(this.DndCharacterCreationEntities);
                }
                return _languageRepo;
            }
        }
        public IRepository<LanguageRace> LanguageRaceRepo
        {
            get
            {
                if (_languageRaceRepo == null)
                {
                    _languageRaceRepo = new Repository<LanguageRace>(this.DndCharacterCreationEntities);
                }
                return _languageRaceRepo;
            }
        }
        public IRepository<Race> RaceRepo
        {
            get
            {
                if (_raceRepo == null)
                {
                    _raceRepo = new Repository<Race>(this.DndCharacterCreationEntities);
                }
                return _raceRepo;
            }
        }
        public IRepository<RaceTrait> RaceTraitRepo
        {
            get
            {
                if (_raceTraitRepo == null)
                {
                    _raceTraitRepo = new Repository<RaceTrait>(this.DndCharacterCreationEntities);
                }
                return _raceTraitRepo;
            }
        }
        public IRepository<Trait> TraitRepo
        {
            get
            {
                if (_traitRepo == null)
                {
                    _traitRepo = new Repository<Trait>(this.DndCharacterCreationEntities);
                }
                return _traitRepo;
            }
        }

        public void Dispose()
        {
            DndCharacterCreationEntities.Dispose();
        }

        public int Save()
        {
            return DndCharacterCreationEntities.SaveChanges();
        }
    }
}
