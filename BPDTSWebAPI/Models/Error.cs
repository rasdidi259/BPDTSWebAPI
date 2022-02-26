using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BPDTSWebAPI.Models
{
    public class Error
    {
        public int StatusCode { get; set; }
        public string Messasge { get; set; }
        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }
}
