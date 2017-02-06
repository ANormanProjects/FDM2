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
            Database.SetInitializer<SocialNetworkDataModel>(null);            

            modelBuilder.Entity<UserPost>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("UserPosts");
            });

            modelBuilder.Entity<GroupPost>().Map(m =>
            {
                m.MapInheritedProperties();
                m.ToTable("GroupPosts");
            }); 

            modelBuilder.Entity<Group>()
                .HasMany<User>(g => g.usersInGroup)
                .WithMany(u => u.groups)
                .Map(ug =>
                    {
                        ug.MapLeftKey("GroupRefId");
                        ug.MapRightKey("UserRefId");
                        ug.ToTable("UserGroups");
                    }                    
                );

            modelBuilder.Entity<User>()
                .HasMany<User>(u => u.friends)
                .WithMany()
                .Map(uf =>
                {
                    uf.MapLeftKey("UserRefId");
                    uf.MapRightKey("FriendRefId");
                    uf.ToTable("UserFriends");
                }
                );

            base.OnModelCreating(modelBuilder);
        }

        public virtual IDbSet<User> users { get; set; }
        public virtual IDbSet<Post> posts { get; set; }
        public virtual IDbSet<Comment> comments { get; set; }
        public virtual IDbSet<Group> groups { get; set; }
    }
}
