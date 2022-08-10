using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DndCharacterCreation_DAL.DomainModels
{
    public class Race
    {
        [Key]
        public int RaceID { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int AbilityScoreBonusID { get; set; }
        public string Size { get; set; }
        [Required]
        public int SpeedWalk { get; set; }
        public int SpeedSwim { get; set; }
        public int SpeedFly { get; set; }
        public int SpeedClimb { get; set; }
        public string CreatureType { get; set; }
        [Required]
        public bool BaseRace { get; set; }

        [ForeignKey("AbilityScoreBonusID")]
        public AbilityScoreBonus abilityScoreBonus { get; set; }
    }
}
