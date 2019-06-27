using rest_api.models;
using System.Collections.Generic;

namespace rest_api.ibusiness
{
    public interface IEntrepriseBL
    {
        IEnumerable<Entreprise> GetAll();
        Entreprise Get(int id);
        Entreprise Add(Entreprise entity);
        void Update(Entreprise entity);
        void Delete(int id);
        void Remove(int id);
    }
}
