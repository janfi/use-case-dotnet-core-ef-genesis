using rest_api.ibusiness;
using rest_api.idal;
using rest_api.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace rest_api.business
{

    public class ContactBL: IContactBL
    {
        private IContactDAL _contactDAL { get; }

        public ContactBL(IContactDAL ContactDAL)
        {
            _contactDAL = ContactDAL;
        }

        public IEnumerable<Contact> GetAll()
        {
            return _contactDAL.GetAll();
        }

        public Contact Get(int id)
        {
            return _contactDAL.Get(id);
        }

        public Contact Add(Contact entity)
        {
             return _contactDAL.Add(entity);
        }

        public void Update( Contact entity)
        {
            Contact dBentity = Get(entity.ContactId);
            _contactDAL.Update(dBentity, entity);
        }

        public void Delete(int id)
        {
            Contact dbEntity = Get(id);
            _contactDAL.Delete(dbEntity);
        }

        public void Remove(int id)
        {
            Contact dbEntity = Get(id);
            _contactDAL.Remove(dbEntity);
        }
    }
}
