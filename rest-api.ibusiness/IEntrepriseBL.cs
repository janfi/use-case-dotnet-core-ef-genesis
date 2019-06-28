
using rest_api.dto;
using System.Collections.Generic;

namespace rest_api.ibusiness
{
    public interface IEntrepriseBL
    {
        IEnumerable<EntrepriseDTO> GetAll();
        EntrepriseDTO Get(int id);
        EntrepriseDTO Add(EntrepriseDTO entity);
        void Update(EntrepriseDTO entity);
        void Delete(int id);
        void Remove(int id);
    }
}
