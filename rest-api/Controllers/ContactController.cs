using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rest_api.Filters;
using rest_api.ibusiness;
using rest_api.models;

namespace rest_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactBL _contactBL;

        public ContactController(IContactBL contactBL)
        {
            _contactBL = contactBL ?? throw new ArgumentNullException(nameof(contactBL));
        }

        // GET api/contact
        [HttpGet]
        public IEnumerable<Contact> GetAll()
        {
            return _contactBL.GetAll();
        }

        // GET api/contact/5
        [HttpGet("{id}")]
        public Contact Get(int id)
        {
            return _contactBL.Get(id);
        }

        // POST api/contact
        [HttpPost]
        public Contact Add([FromBody] Contact entity)
        {
            return _contactBL.Add(entity);
        }

        // PUT api/contact
        [HttpPut()]
        public bool Update([FromBody] Contact entity)
        {
            _contactBL.Update(entity);
            return true;
        }

        // DELETE api/contact/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            _contactBL.Delete(id);
            return true;
        }

        // Remove api/contact/5
        [HttpPut("{id}")]
        public bool Remove(int id)
        {
            _contactBL.Remove(id);
            return true;
        }
    }
}
