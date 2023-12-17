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
				.WithOne(c => c.Category)
				.HasForeignKey(p => p.CategoryId);

			modelBuilder.Entity<User>()
				.HasMany(p => p.Posts)
				.WithOne(u => u.User)
				.HasForeignKey(p => p.UserId);

			modelBuilder.Entity<Category>()
				.HasMany(uc => uc.Users)
				.WithOne(c => c.Category)
				.HasForeignKey(uc => uc.CategoryId);
			
			modelBuilder.Entity<User>()
				.HasMany(uc => uc.Categories)
				.WithOne(c => c.User)
				.HasForeignKey(uc => uc.UserId);
		}
	}
}
