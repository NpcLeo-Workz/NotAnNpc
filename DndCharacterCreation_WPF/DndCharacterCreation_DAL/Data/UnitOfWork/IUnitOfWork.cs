using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DndCharacterCreation_DAL.DomainModels;
using DndCharacterCreation_DAL.Data.Repositories;

namespace DndCharacterCreation_DAL.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<AbilityScoreBonus> AbilityScoreBonusRepo { get; }
        IRepository<Language> LanguageRepo { get; }
        IRepository<LanguageRace> LanguageRaceRepo { get; }
        IRepository<Race> RaceRepo { get; }
        IRepository<RaceTrait> RaceTraitRepo { get; }
        IRepository<Trait> TraitRepo { get; }
        int Save();
    }
}
