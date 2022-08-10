using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DndCharacterCreation_DAL.DomainModels
{
    public class LanguageRace
    {
        [Key]
        public int LanguageRaceID { get; set; }
        [Index("IX_LanguageIDRaceID", 1, IsUnique =true)]
        public int LanguageID { get; set; }
        [Index("IX_LanguageIDRaceID", 2, IsUnique = true)]
        public int RaceID { get; set; }

        
        public Language Language { get; set; }
        public Race Race { get; set; }
    }
}
