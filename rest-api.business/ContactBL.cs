using rest_api.domain;
using rest_api.dto;
using rest_api.ibusiness;
using rest_api.idal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace rest_api.business
{

    public class ContactBL: IContactBL
    {
        private IContactDAL _contactDAL { get; }

        public ContactBL(IContactDAL ContactDAL)
        {
            _contactDAL = ContactDAL;
        }

        public IEnumerable<ContactDTO> GetAll()
        {
            return _contactDAL.GetAll().Select(c => ContactModel.toDTO(c)); ;
        }

        public ContactDTO Get(int id)
        {
            return ContactModel.toDTO(_contactDAL.Get(id));
        }

        public ContactDTO Add(ContactDTO entity)
        {
            ContactModel contact = ContactModel.formDTO(entity);
            return ContactModel.toDTO(_contactDAL.Add(contact));
        }

        public void Update(ContactDTO entity)
        {
            ContactModel dBentity = _contactDAL.Get(entity.ContactId);

            _contactDAL.Update(dBentity, ContactModel.formDTO(entity));
        }

        public void Delete(int id)
        {
            ContactModel dBentity = _contactDAL.Get(id);
            _contactDAL.Delete(dBentity);
        }

        public void Remove(int id)
        {
            ContactModel dBentity = _contactDAL.Get(id);
            _contactDAL.Remove(dBentity);
        }
    }
}
