using Api_Practise.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http;

namespace Api_Practise.Service
{
    interface FootballersInterface
    {
      IEnumerable<Footballers> Get();
      Footballers GetFootballers(int id);
      void PostFootballers(Footballers footballers);
      void Put(Footballers footballers);
    }
}
