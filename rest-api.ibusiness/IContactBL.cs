using rest_api.dto;
using System;
using System.Collections.Generic;
using System.Text;

namespace rest_api.ibusiness
{
    public interface IContactBL
    {
        IEnumerable<ContactDTO> GetAll();
        ContactDTO Get(int id);
        ContactDTO Add(ContactDTO entity);
        void Update(ContactDTO entity);
        void Delete(int id);
        void Remove(int id);
    }
}
