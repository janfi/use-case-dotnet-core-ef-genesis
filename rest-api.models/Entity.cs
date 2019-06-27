using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Newtonsoft.Json;


namespace rest_api.models
{
    public class Entity: BaseClass
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int EntityId { get; set; }
        public Address Address { get; set; }
        public bool isSiegeCentral { get; set; }

        public int EntrepriseId { get; set; }
        [JsonIgnore]
        public virtual Entreprise Entreprise { get; set; }

    }
}
