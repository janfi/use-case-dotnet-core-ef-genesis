namespace rest_api.dto
{
    public enum TypeContractDTO
    {
        FreeLance,
        Employee
    }

    public class ContractDTO : BaseClassDTO
    {
   
        public int ContactId { get; set; }
        public int EntrepriseId { get; set; }
        public TypeContractDTO? ContractType { get; set; }
        public string TVA { get; set; } = "";

    }
}
