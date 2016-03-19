using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Mvc;

namespace Api_Practise.Models
{
    [DataContract]
    public class Footballers
    {
        [DataMember]
        [Key]
        public int FootballersID { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Kit Number")]
        public int kitnumber { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Club")]
        public string club { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Position")]
        public string position { get; set; }

        [DataMember]
        [Required]
        [Display(Name = "Nationality")]
        public string nationality { get; set; }


        [DataMember]
        [Required]
        [Display(Name = "Name")]
        public string name { get; set; }


        [DataMember]
        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }


        [DataMember]
        [Required]
        [Display(Name = "User Name")]
        [Remote("doesUserNameExist", "Account", HttpMethod = "POST", ErrorMessage = "User name already exists. Please enter a different user name.")]
        public string username { get; set; }


        [DataMember]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [System.ComponentModel.DataAnnotations.Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }



        [JsonIgnore]
        public virtual ICollection<footballFans> fans { get; set; }
    }
}

//    public class SignInViewModel {

//       public string Email { get; set; }
//       public string Password { get; set; }
//  }
//}