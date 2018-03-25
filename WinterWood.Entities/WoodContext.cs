namespace WinterWood.Entities
{
    using System.Data.Entity;

    public partial class WoodContext : DbContext
    {
        public WoodContext()
            : base("name=WoodContext")
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<Invoice> Invoices { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
        }
    }
}
