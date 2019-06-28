using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;
using rest_api.domain;

namespace rest_api.identities
{
    public class Entity: BaseClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EntityId { get; set; }
        public Address Address { get; set; }
        public bool isSiegeCentral { get; set; }

        public int EntrepriseId { get; set; }
        public virtual Entreprise Entreprise { get; set; }

        public static EntityModel toModel(Entity entity)
        {
            return new EntityModel
            {
                Address = Address.toModel(entity.Address),
                EntityId = entity.EntityId,
                EntrepriseId = entity.EntrepriseId,
                isSiegeCentral = entity.isSiegeCentral,
                UpdatedDate = entity.UpdatedDate,
                CreatedDate = entity.CreatedDate,
                DeletedDate = entity.DeletedDate
                 
            };
        }

        public static Entity formModel(EntityModel address)
        {
            return new Entity
            {
                Address = Address.formModel(address.Address),
                EntityId = address.EntityId,
                EntrepriseId = address.EntrepriseId,
                isSiegeCentral = address.isSiegeCentral,
                UpdatedDate = address.UpdatedDate,
                CreatedDate = address.CreatedDate,
                DeletedDate = address.DeletedDate
            };
        }
    }
}
