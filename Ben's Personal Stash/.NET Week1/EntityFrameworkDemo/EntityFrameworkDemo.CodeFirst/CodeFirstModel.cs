namespace EntityFrameworkDemo.CodeFirst
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class CodeFirstModel : DbContext
    {
        public CodeFirstModel()
            : base("name=CodeFirstModel")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public virtual DbSet<Broker> brokers { get; set; }
        public DbSet<Company> companies { get; set; }
        public DbSet<Location> locations { get; set; }

    }
}
