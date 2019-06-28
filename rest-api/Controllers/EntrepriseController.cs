using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using rest_api.dto;
using rest_api.Filters;
using rest_api.ibusiness;

namespace rest_api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntrepriseController : ControllerBase
    {
        private readonly IEntrepriseBL _entrepriseBL;

        public EntrepriseController(IEntrepriseBL entrepriseBL)
        {
            _entrepriseBL = entrepriseBL ?? throw new ArgumentNullException(nameof(entrepriseBL));
        }

        // GET api/entreprise
        [HttpGet]
        public IEnumerable<EntrepriseDTO> GetAll()
        {
            return _entrepriseBL.GetAll();
        }

        // GET api/entreprise/5
        [HttpGet("{id}")]
        public EntrepriseDTO Get(int id)
        {
            return _entrepriseBL.Get(id);
        }

        // POST api/entreprise
        [HttpPost]
        public EntrepriseDTO Add([FromBody] EntrepriseDTO entity)
        {
            return _entrepriseBL.Add(entity);
        }

        // PUT api/entreprise/5
        [HttpPut()]
        public bool Update([FromBody] EntrepriseDTO entity)
        {
            _entrepriseBL.Update(entity);
            return true;
        }

        // DELETE api/entreprise/5
        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            _entrepriseBL.Delete(id);
            return true;
        }

        // Remove api/entreprise/5
        [HttpPut("{id}")]
        public bool Remove(int id)
        {
            _entrepriseBL.Remove(id);
            return true;
        }
    }
}
