using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace rest_api.models
{
    public enum TypeContract
    {
        FreeLance,
        Employee
    }

    public class Contract : BaseClass, IValidatableObject
    {
   
        public int ContactId { get; set; }
        public int EntrepriseId { get; set; }
        public TypeContract? ContractType { get; set; }
        public string TVA { get; set; } = "";

        [JsonIgnore]
        public virtual Contact Contact { get; set; }
        [JsonIgnore]
        public virtual Entreprise Entreprise { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ContractType == TypeContract.FreeLance && TVA == "")
            {
                yield return new ValidationResult
                 ("FreeLance must have a TVA number", new[] { "error" });
            }
        }
    }
}
