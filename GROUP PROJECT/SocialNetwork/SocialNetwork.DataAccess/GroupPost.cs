﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess
{
    public class GroupPost : Post
    {
        public Group group { get; set; }

    }
}