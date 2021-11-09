using System.Data.Entity;
using ParserDb.Models;

namespace ParserDb.Context
{
    public class UserContext : DbContext
    {
        public UserContext() : base("MyConnection1")
        {
        }

        public DbSet<ItemModel> Items { get; set; }

        //public DbSet<TestObject> TestItems { get; set; }
    }
}
