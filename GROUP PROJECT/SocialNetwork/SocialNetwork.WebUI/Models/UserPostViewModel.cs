using SocialNetwork.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork.WebUI.Models
{
    public class UserPostViewModel
    {
        public UserPost post { get; set; }
        public User user { get; set; }
    }
}