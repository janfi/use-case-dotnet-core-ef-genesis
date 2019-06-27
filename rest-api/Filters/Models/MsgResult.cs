using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace rest_api.Filters.Models
{
    public class MsgResult
    {
        public object data { get; set; }

        public MsgException exception { get; set; }

    }
}
