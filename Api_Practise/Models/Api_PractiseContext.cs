using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Api_Practise.Models
{
    public class Api_PractiseContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public Api_PractiseContext() : base("name=Api_PractiseContext")
        {
        }

        public System.Data.Entity.DbSet<Api_Practise.Models.Footballers> Footballers { get; set; }

        public System.Data.Entity.DbSet<Api_Practise.Models.footballFans> footballFans { get; set; }
    }
}
