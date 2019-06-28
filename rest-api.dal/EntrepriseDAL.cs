using Microsoft.EntityFrameworkCore;
using rest_api.domain;
using rest_api.idal;
using rest_api.identities;
using System;
using System.Collections.Generic;
using System.Linq;


namespace rest_api.dal
{
    public class EntrepriseDAL : IEntrepriseDAL
    {
        private readonly DbCtx _ctx;

        public EntrepriseDAL(DbCtx dbCtx)
        {
            _ctx = dbCtx;
        }

        public IEnumerable<EntrepriseModel> GetAll()
        {
            return _ctx.Entreprise.ToList().Select(e => Entreprise.toModel(e));
        }

        public EntrepriseModel Get(long id)
        {
            return Entreprise.toModel(_ctx.Entreprise
                  .Include(e => e.Entities)
                  .Include(e => e.Contracts)
                  .FirstOrDefault(e => e.EntrepriseId == id));
        }

        public EntrepriseModel Add(EntrepriseModel entreprise)
        {
            Entreprise entity = Entreprise.formModel(entreprise);
            _ctx.Entreprise.Add(entity);
            _ctx.SaveChanges();
            return Entreprise.toModel(entity);
        }

        public void Update(EntrepriseModel dBentreprise, EntrepriseModel entreprise)
        {
            Entreprise dBentity = Entreprise.formModel(dBentreprise);
            Entreprise entity = Entreprise.formModel(entreprise);

            _ctx.Entry(dBentity).CurrentValues.SetValues(entity);

            // Delete Entities
            foreach (var child in dBentity.Entities.ToList())
            {
                if (!entity.Entities.Any(c => c.EntityId == child.EntityId))
                    _ctx.Entity.Remove(child);
            }

            //update or insert
            foreach (var child in entity.Entities)
            {
                if (child == null) continue;

                var existingChild = dBentity.Entities
                    .Where(c => c.EntityId == child.EntityId)
                    .SingleOrDefault();

                if (existingChild != null)
                {
                    // Update child
                    _ctx.Entry(existingChild).CurrentValues.SetValues(child);
                    _ctx.Entry(existingChild.Address).CurrentValues.SetValues(child.Address);
                }
                else
                {
                    // Insert child
                    var newChild = new Entity
                    {
                        isSiegeCentral = child.isSiegeCentral,
                        Address = new Address
                        {
                            City = child.Address.City,
                            Street = child.Address.Street
                        }
                    };
                    dBentity.Entities.Add(newChild);
                }
            }

            // Delete Contracts
            foreach (var child in dBentity.Contracts.ToList())
            {
                if (!entity.Contracts.Any(c => c.ContactId == child.ContactId && c.EntrepriseId == child.EntrepriseId))
                    _ctx.Contract.Remove(child);
            }

            //update or insert
            foreach (var child in entity.Contracts)
            {
                var existingChild = dBentity.Contracts
                    .Where(c => c.ContactId == child.ContactId && c.EntrepriseId == child.EntrepriseId)
                    .SingleOrDefault();

                if (existingChild != null)
                    // Update child
                    _ctx.Entry(existingChild).CurrentValues.SetValues(child);
                else
                {
                    // Insert child
                    var newChild = new Contract
                    {
                        ContractType = child.ContractType,
                        TVA = child.TVA,
                        ContactId = child.ContactId
                    };
                    dBentity.Contracts.Add(newChild);
                }
            }

            _ctx.SaveChanges();
        }

        public void Delete(EntrepriseModel entreprise)
        {
            Entreprise entity = Entreprise.formModel(entreprise);
            foreach (var child in entity.Entities)
            {
                _ctx.Entity.Remove(child);
            }
            foreach (var child in entity.Contracts)
            {
                _ctx.Contract.Remove(child);
            }
            _ctx.Entreprise.Remove(entity);
            _ctx.SaveChanges();
        }

        public void Remove(EntrepriseModel entreprise)
        {
            Entreprise entity = Entreprise.formModel(entreprise);
            entreprise.DeletedDate = DateTime.UtcNow;
            foreach (var child in entity.Entities)
            {
                child.DeletedDate = DateTime.UtcNow;
            }
            foreach (var child in entity.Contracts)
            {
                child.DeletedDate = DateTime.UtcNow;
            }
            _ctx.SaveChanges();
        }

    }
}
