using Microsoft.EntityFrameworkCore;
using rest_api.idal;
using rest_api.models;
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

        public IEnumerable<Entreprise> GetAll()
        {
            return _ctx.Entreprise.ToList();
        }

        public Entreprise Get(long id)
        {
            return _ctx.Entreprise
                  .Include(e => e.Entities)
                  .Include(e => e.Contracts)
                  .FirstOrDefault(e => e.EntrepriseId == id);
        }

        public Entreprise Add(Entreprise entity)
        {
            _ctx.Entreprise.Add(entity);
            _ctx.SaveChanges();
            return entity;
        }

        public void Update(Entreprise dBentity, Entreprise entity)
        {
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

        public void Delete(Entreprise entreprise)
        {
            foreach (var child in entreprise.Entities)
            {
                _ctx.Entity.Remove(child);
            }
            foreach (var child in entreprise.Contracts)
            {
                _ctx.Contract.Remove(child);
            }
            _ctx.Entreprise.Remove(entreprise);
            _ctx.SaveChanges();
        }

        public void Remove(Entreprise entreprise)
        {
            entreprise.DeletedDate = DateTime.UtcNow;
            foreach (var child in entreprise.Entities)
            {
                child.DeletedDate = DateTime.UtcNow;
            }
            foreach (var child in entreprise.Contracts)
            {
                child.DeletedDate = DateTime.UtcNow;
            }
            _ctx.SaveChanges();
        }

    }
}
