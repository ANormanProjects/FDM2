using SocialNetwork.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SocialNetwork.WebUI.Models
{
    public class GroupViewModels
    {
        public Group group { get; set; }
        public GroupPost groupPost { get; set; }
    }
}