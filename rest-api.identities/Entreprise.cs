using rest_api.domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace rest_api.identities
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

        public static EntrepriseModel toModel(Entreprise entity)
        {
            return new EntrepriseModel
            {
                EntrepriseId = entity.EntrepriseId,
                Name = entity.Name,
                Tva = entity.Tva,
                Contracts = entity.Contracts.Select(c => Contract.toModel(c)).ToList(),
                Entities = entity.Entities.Select(e => Entity.toModel(e)).ToList(),
                UpdatedDate = entity.UpdatedDate,
                CreatedDate = entity.CreatedDate,
                DeletedDate = entity.DeletedDate,

            };
        }

        public static Entreprise formModel(EntrepriseModel address)
        {
            return new Entreprise
            {
                EntrepriseId = address.EntrepriseId,
                Name = address.Name,
                Tva = address.Tva,
                Contracts = address.Contracts.Select(c => Contract.formModel(c)).ToList(),
                Entities = address.Entities.Select(e => Entity.formModel(e)).ToList(),
                UpdatedDate = address.UpdatedDate,
                CreatedDate = address.CreatedDate,
                DeletedDate = address.DeletedDate,
            };
        }
    }
}
