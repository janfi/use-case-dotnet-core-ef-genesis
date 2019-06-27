using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace rest_api.models
{
    public class Entreprise : BaseClass, IValidatableObject
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EntrepriseId { get; set; }
        public string Name { get; set; }
        [Required]
        public string Tva { get; set; }

        public List<Entity> Entities { get; set; } = new List<Entity>();
        public List<Contract> Contracts { get; set; } = new List<Contract>();

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            
            if (Entities.Count > 0 && !Entities.Any(e => e.isSiegeCentral))
            {
                yield return new ValidationResult
                 ("Entreprise must have a Siege social", new[] { "error" });
            } else if (Entities.Count > 0 && Entities.Count(e => e.isSiegeCentral) >1 ){
                    yield return new ValidationResult
                     ("Entreprise must have only one Siege social", new[] { "error" });
            } else if (Entities.Count == 0)
            {
                yield return new ValidationResult
                ("Entreprise must have an entity", new[] { "error" });
            }
        }
    }
}
