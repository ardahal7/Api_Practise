using Api_Practise.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Api_Practise.Models.DTO
{
    public class DTOFactory
    {

        public FootballerDTO CreateFootballerDTO(Footballers footballers)

        {
            FootballerDTO _footDto = new FootballerDTO {

                name = footballers.name,
                club = footballers.club,
                footballfans = footballers.fans         
            };
          
           


            return _footDto;
        }
    }
}