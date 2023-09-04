global using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Newtonsoft.Json.Linq;
using System.Runtime.InteropServices.JavaScript;
using System.Text.Json.Serialization;
using top_library_models;
using top_library_models.Models;

namespace top_library_dblayer
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<BookRoom> BookRooms { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Transaction> Transactions { get; set; }

        private const string configPath = "db_config.json";
        private const string connectionStringKey = "library_ConnectionString";
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if(!File.Exists(configPath))
                throw new Exception($"There is no file for \"{configPath}\" path!");
            var json = JObject.Parse(File.ReadAllText(configPath));

            if (!json.ContainsKey(connectionStringKey))
                throw new Exception($"Inconsistent {configPath} file!");

            optionsBuilder
                .UseSqlServer((string?)json[connectionStringKey])
                .UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            foreach (var entityType in ModelController.GetModelTypes())
                modelBuilder.Entity(entityType)
                    .Property(nameof(IEntity.Id))
                    .HasDefaultValue("NEWSEQUENTIALID()");
        }
    }
}