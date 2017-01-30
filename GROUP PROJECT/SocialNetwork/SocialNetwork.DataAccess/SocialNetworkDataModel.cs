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

        public virtual IDbSet<IUser> users { get; set; }
        public virtual IDbSet<Post> posts { get; set; }
        public virtual IDbSet<IComment> comments { get; set; }
        public virtual IDbSet<IGroup> groups { get; set; }
    }
}
