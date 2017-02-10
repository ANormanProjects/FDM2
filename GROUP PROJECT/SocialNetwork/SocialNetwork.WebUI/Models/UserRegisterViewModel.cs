using SocialNetwork.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork.WebUI.Models
{
    public class UserRegisterViewModel
    {
        public User user { get; set; }
        public string confirmPassword { get; set; }
    }
}