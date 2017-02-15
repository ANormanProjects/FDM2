namespace E_Commerce_DAL
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class E_CommerceDataModel : DbContext
    {
        public E_CommerceDataModel()
            : base("name=CommerceDataModel")
        {
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }

        public virtual DbSet<Item> items { get; set; }
        public virtual DbSet<Basket> baskets { get; set; }
    }
}
