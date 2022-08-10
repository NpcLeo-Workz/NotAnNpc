using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DndCharacterCreation_DAL.DomainModels
{
    public class RaceTrait
    {
        [Key]
        public int RaceTraitID { get; set; }
        [Index("IX_RaceIDTraitID", 1, IsUnique =true)]
        public int RaceID { get; set; }
        [Index("IX_RaceIDTraitID", 2, IsUnique = true)]
        public int TraitID { get; set; }
      
        public Race Race { get; set; }
        
        public Trait Trait { get; set; }
    }
}
