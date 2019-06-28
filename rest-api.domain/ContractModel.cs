using rest_api.dto;

namespace rest_api.domain
{
    public enum TypeContractBL
    {
        FreeLance,
        Employee
    }

    public class ContractModel : BaseClassModel
    {
   
        public int ContactId { get; set; }
        public int EntrepriseId { get; set; }
        public TypeContractBL? ContractType { get; set; }
        public string TVA { get; set; } = "";


        public static TypeContractDTO? enumToDTO(TypeContractBL? type)
        {
            if (type == TypeContractBL.Employee) return TypeContractDTO.Employee;
            else if (type == TypeContractBL.FreeLance) return TypeContractDTO.FreeLance;
            else return null;
        }

        public static TypeContractBL? enumFromDTO(TypeContractDTO? type)
        {
            if (type == TypeContractDTO.Employee) return TypeContractBL.Employee;
            else if (type == TypeContractDTO.FreeLance) return TypeContractBL.FreeLance;
            else return null;
        }

        public static ContractDTO toDTO(ContractModel entity)
        {
            return new ContractDTO
            {
                ContactId = entity.ContactId,
                ContractType = enumToDTO(entity.ContractType),
                EntrepriseId = entity.EntrepriseId,
                TVA = entity.TVA,
                UpdatedDate = entity.UpdatedDate,
                CreatedDate = entity.CreatedDate,
                DeletedDate = entity.DeletedDate
            };
        }



        public static ContractModel formDTO(ContractDTO address)
        {
            return new ContractModel
            {
                ContactId = address.ContactId,
                ContractType = enumFromDTO(address.ContractType),
                CreatedDate = address.CreatedDate,
                DeletedDate = address.DeletedDate,
                EntrepriseId = address.EntrepriseId,
                TVA = address.TVA,
                UpdatedDate = address.UpdatedDate
            };
        }
    }
}
