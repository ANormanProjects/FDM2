namespace SocialNetwork.DataAccess
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class SocialNetworkDataModel : DbContext
    {
        public SocialNetworkDataModel()
            : base("name=SocialNetworkDataModel")
        {

        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

        }

        public virtual DbSet<User> users { get; set; }
        public virtual DbSet<Post> posts { get; set; }
        public virtual DbSet<Comment> comments { get; set; }
    }
}
