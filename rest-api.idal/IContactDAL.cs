using rest_api.domain;
using rest_api.identities;
using System;
using System.Collections.Generic;
using System.Text;

namespace rest_api.idal
{
    public interface IContactDAL : IDataRepository<ContactModel>
    {}
}
