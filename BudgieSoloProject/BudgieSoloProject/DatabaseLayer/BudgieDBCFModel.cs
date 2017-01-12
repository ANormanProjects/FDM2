namespace BudgieDatabaseLayer
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BudgieDBCFModel : DbContext
    {
        public BudgieDBCFModel()
            : base("name=BudgieDBCFModelApp")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public virtual DbSet<BudgieUser> budgieUsers { get; set; }
        public virtual DbSet<Account> accounts { get; set; }
    }
}
