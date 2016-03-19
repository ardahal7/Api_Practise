using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Api_Practise.Models.DTO
{
    
    public class FootballerDTO
    {
    
        public string club { get; set; }


        public string name { get; set; }

        [JsonIgnore]
        public virtual ICollection<footballFans> footballfans { get; set; }
    }
}