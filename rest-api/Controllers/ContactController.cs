using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using rest_api.dto;
using rest_api.ibusiness;

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
        public IEnumerable<ContactDTO> GetAll()
        {
            return _contactBL.GetAll();
        }

        // GET api/contact/5
        [HttpGet("{id}")]
        public ContactDTO Get(int id)
        {
            return _contactBL.Get(id);
        }

        // POST api/contact
        [HttpPost]
        public ContactDTO Add([FromBody] ContactDTO entity)
        {
            return _contactBL.Add(entity);
        }

        // PUT api/contact
        [HttpPut()]
        public bool Update([FromBody] ContactDTO entity)
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
