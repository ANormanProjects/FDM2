using SocialNetwork.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork.WebUI.Models
{
    public class CommentViewModel
    {
        public Comment comment { get; set; }
        public User user { get; set; }
    }
}