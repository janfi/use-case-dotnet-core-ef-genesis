using rest_api.models;
using System;
using System.Collections.Generic;
using System.Text;

namespace rest_api.ibusiness
{
    public interface IContactBL
    {
        IEnumerable<Contact> GetAll();
        Contact Get(int id);
        Contact Add(Contact entity);
        void Update(Contact entity);
        void Delete(int id);
        void Remove(int id);
    }
}
