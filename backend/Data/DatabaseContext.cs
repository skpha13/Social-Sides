using backend.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Identity.Client;

namespace backend.Data
{
	public class DatabaseContext : DbContext
	{
		public DbSet<Post> Posts { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<UserFollowsCategory> UserFollowsCategories { get; set; }
		
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Category>()
				.HasMany(p => p.Posts)
				.WithOne(c => c.Category);
		}
	}
}
