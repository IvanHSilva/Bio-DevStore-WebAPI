using DevAccounts.Domain;
using System.Data.Entity;

namespace DevStore.Data.Contexts {
    public class AppDataContext : DbContext {
        public AppDataContext():base("AppConStr"){}

        public DbSet<Product> Products { get; set; }
    }
}
