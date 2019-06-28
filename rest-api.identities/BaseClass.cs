using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace rest_api.identities
{
    public class BaseClass
    {
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime? UpdatedDate { get; set; }
        public DateTime? DeletedDate { get; set; }

    }
}
