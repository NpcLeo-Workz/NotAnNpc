using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DndCharacterCreation_DAL.DomainModels
{
    public class AbilityScoreBonus
    {
        [Key]
        public int AbilityScoreBonusID { get; set; }
        [Required]
        public int strength { get; set; }
        [Required]
        public int dexterity { get; set; }
        [Required]
        public int constitution { get; set; }
        [Required]
        public int inteligence { get; set; }
        [Required]
        public int wisdom { get; set; }
        [Required]
        public int charisma { get; set; }
    }
}
