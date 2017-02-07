using SocialNetwork.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork.WebUI.Models
{
    public class ProfilePageViewModel
    {
        public List<UserPost> userpost { get; set; }       
        public User user { get; set; }
    }
}