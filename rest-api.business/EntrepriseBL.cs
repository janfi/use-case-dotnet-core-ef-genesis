using rest_api.dto;
using rest_api.ibusiness;
using rest_api.idal;
using System.Linq;
using System.Collections.Generic;
using rest_api.domain;

namespace rest_api.business
{
    public class EntrepriseBL : IEntrepriseBL
    {
        private IEntrepriseDAL _entrepriseDAL { get; }

        public EntrepriseBL(IEntrepriseDAL EntrepriseDAL)
        {
            _entrepriseDAL = EntrepriseDAL;
        }

        public IEnumerable<EntrepriseDTO> GetAll()
        {
            return _entrepriseDAL.GetAll().Select(c => EntrepriseModel.toDTO(c));
        }

        public EntrepriseDTO Get(int id)
        {
            return EntrepriseModel.toDTO(_entrepriseDAL.Get(id));
        }

        public EntrepriseDTO Add(EntrepriseDTO entity)
        {
            EntrepriseModel entreprise = EntrepriseModel.formDTO(entity);
            return EntrepriseModel.toDTO(_entrepriseDAL.Add(entreprise));
        }

        public void Update(EntrepriseDTO entity)
        {
            EntrepriseModel dBentity = _entrepriseDAL.Get(entity.EntrepriseId);
            _entrepriseDAL.Update(dBentity, EntrepriseModel.formDTO(entity));

        }

        public void Delete(int id)
        {
            EntrepriseModel dBentity = _entrepriseDAL.Get(id);
            _entrepriseDAL.Delete(dBentity);
        }

        public void Remove(int id)
        {
            EntrepriseModel dBentity = _entrepriseDAL.Get(id);
            _entrepriseDAL.Remove(dBentity);
        }
    }
}
  