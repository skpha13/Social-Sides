using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace backend.Data
{
	public class DatabaseContext : DbContext
	{
		public DbSet<Class> Class { get; set; }

		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
		}
	}
}
