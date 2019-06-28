using Newtonsoft.Json;
using rest_api.domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace rest_api.identities
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

        public static TypeContractBL? enumToModel(TypeContract? type)
        {
            if (type == TypeContract.Employee) return TypeContractBL.Employee;
            else if (type == TypeContract.FreeLance) return TypeContractBL.FreeLance;
            else return null;
        }

        public static TypeContract? enumFromModel(TypeContractBL? type)
        {
            if (type == TypeContractBL.Employee) return TypeContract.Employee;
            else if (type == TypeContractBL.FreeLance) return TypeContract.FreeLance;
            else return null;
        }

        public static ContractModel toModel(Contract entity)
        {
            return new ContractModel
            {
                ContactId = entity.ContactId,
                ContractType = enumToModel(entity.ContractType),
                EntrepriseId = entity.EntrepriseId,
                TVA = entity.TVA,
                UpdatedDate = entity.UpdatedDate,
                CreatedDate = entity.CreatedDate,
                DeletedDate = entity.DeletedDate
            };
        }

        public static Contract formModel(ContractModel address)
        {
            return new Contract
            {
                ContactId = address.ContactId,
                ContractType = enumFromModel(address.ContractType),
                CreatedDate = address.CreatedDate,
                DeletedDate = address.DeletedDate,
                EntrepriseId = address.EntrepriseId,
                TVA = address.TVA,
                UpdatedDate = address.UpdatedDate
            };
        }
    }
}
