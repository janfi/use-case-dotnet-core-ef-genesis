using Microsoft.EntityFrameworkCore;
using rest_api.idal;
using rest_api.models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace rest_api.dal
{
    public class ContactDAL: IContactDAL
    {
        private readonly DbCtx _ctx;

        public ContactDAL(DbCtx dbCtx)
        {
            _ctx = dbCtx;
        }

        public IEnumerable<Contact> GetAll()
        {
            return _ctx.Contact.ToList();
        }

        public Contact Get(long id)
        {
            return _ctx.Contact
                  .Include(e => e.Contracts)
                  .FirstOrDefault(c => c.ContactId == id);
        }

        public Contact Add(Contact entity)
        {
            _ctx.Contact.Add(entity);
            _ctx.SaveChanges();

            return entity;
        }

        public void Update(Contact dBentity, Contact entity)
        {
            _ctx.Entry(dBentity).CurrentValues.SetValues(entity);
            _ctx.Entry(dBentity.Address).CurrentValues.SetValues(entity.Address);

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
                        EntrepriseId = child.EntrepriseId
                    };
                    dBentity.Contracts.Add(newChild);
                }
            }
            _ctx.SaveChanges();
        }

        public void Delete(Contact contact)
        {
            foreach (var child in contact.Contracts)
            {
                _ctx.Contract.Remove(child);
            }
            _ctx.Contact.Remove(contact);
            _ctx.SaveChanges();
        }

        public void Remove(Contact contact)
        {
            contact.DeletedDate = DateTime.UtcNow;
            foreach (var child in contact.Contracts)
            {
                child.DeletedDate = DateTime.UtcNow;
            }
            _ctx.SaveChanges();
        }
    }
}
