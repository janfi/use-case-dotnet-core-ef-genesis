using Microsoft.EntityFrameworkCore;
using rest_api.domain;
using rest_api.idal;
using rest_api.identities;
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

        public IEnumerable<ContactModel> GetAll()
        {
            return _ctx.Contact.ToList().Select(c => Contact.toModel(c));
        }

        public ContactModel Get(long id)
        {
            return Contact.toModel(_ctx.Contact
                  .Include(e => e.Contracts)
                  .FirstOrDefault(c => c.ContactId == id));
        }

        public ContactModel Add(ContactModel contact)
        {
            Contact entity = Contact.formModel(contact);
            _ctx.Contact.Add(entity);
            _ctx.SaveChanges();

            return Contact.toModel(entity);
        }

        public void Update(ContactModel dBcontact, ContactModel contact)
        {
            Contact dBentity = Contact.formModel(dBcontact);
            Contact entity = Contact.formModel(contact);

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

        public void Delete(ContactModel contact)
        {
            Contact entity = Contact.formModel(contact);
            foreach (var child in entity.Contracts)
            {
                _ctx.Contract.Remove(child);
            }
            _ctx.Contact.Remove(entity);
            _ctx.SaveChanges();
        }

        public void Remove(ContactModel contact)
        {
            Contact entity = Contact.formModel(contact);
            entity.DeletedDate = DateTime.UtcNow;
            foreach (var child in entity.Contracts)
            {
                child.DeletedDate = DateTime.UtcNow;
            }
            _ctx.SaveChanges();
        }
    }
}
