using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DndCharacterCreation_DAL.DomainModels;

namespace DndCharacterCreation_DAL.Data
{
    public class DndCharacterCreationEntities : DbContext
    {
        public DndCharacterCreationEntities() : base("name=NotAnNpcDbConnectionString")
        {
            
        }
        public DbSet<Language> Languages { get; set; }
        public DbSet<Race> Races { get; set; }
        public DbSet<Trait> Traits { get; set; }
        public DbSet<AbilityScoreBonus> abilityScoreBonuses { get; set; }
        public DbSet<LanguageRace> languageRaces { get; set; }
        public DbSet<RaceTrait> RaceTraits { get; set; }
    }
}
