using SocialNetwork.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test_Console
{
    public class Program
    {
        static void Main(string[] args)
        {
            Comment comment;

            comment = new Comment() { commentId = 1 };

            Console.WriteLine(comment.commentId);
        }
    }
}
