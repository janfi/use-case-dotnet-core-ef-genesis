using rest_api.ibusiness;
using rest_api.idal;
using rest_api.models;
using System;
using System.Collections.Generic;

namespace rest_api.business
{
    public class EntrepriseBL : IEntrepriseBL
    {
        private IEntrepriseDAL _entrepriseDAL { get; }

        public EntrepriseBL(IEntrepriseDAL EntrepriseDAL)
        {
            _entrepriseDAL = EntrepriseDAL;
        }

        public IEnumerable<Entreprise> GetAll()
        {
            return _entrepriseDAL.GetAll();
        }

        public Entreprise Get(int id)
        {
            return _entrepriseDAL.Get(id);
        }

        public Entreprise Add(Entreprise entity)
        {
            return _entrepriseDAL.Add(entity);
        }

        public void Update(Entreprise entity)
        {
            Entreprise dBentity = Get(entity.EntrepriseId);
            _entrepriseDAL.Update(dBentity, entity);
        }

        public void Delete(int id)
        {
            Entreprise dbEntity = Get(id);
            _entrepriseDAL.Delete(dbEntity);
        }

        public void Remove(int id)
        {
            Entreprise dbEntity = Get(id);
            _entrepriseDAL.Remove(dbEntity);
        }
    }
}
  