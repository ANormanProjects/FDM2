using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork.DataAccess
{
    public interface IComment
    {
        int commentId { get; set; }

        string content { get; set; }

        User user { get; set; }

        Post post { get; set; }

    }
}
