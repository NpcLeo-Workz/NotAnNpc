using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DndCharacterCreation_DAL.DomainModels
{
    public class Language
    {
        [Key]
        public int LanguageID { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
