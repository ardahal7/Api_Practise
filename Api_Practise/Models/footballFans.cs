using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Api_Practise.Models
{

    [DataContract]
    [KnownType(typeof(Footballers))]
    public class footballFans
    {



     // foreign key  
  
        //[ForeignKey("Footballers")]

        public int FootballersID { get; set; }


        [Key]
        [DataMember]
        public int ID { get; set; }

        [DataMember]
        public string name { get; set; }

        
        public virtual Footballers Footballers { get; set; }

    }
}