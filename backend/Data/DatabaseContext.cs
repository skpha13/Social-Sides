using backend.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace backend.Data
{
	public class DatabaseContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
	{
		public DbSet<Post> Posts { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<User> Users { get; set; }
		public DbSet<UserFollowsCategory> UserFollowsCategories { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Saved> Saves { get; set; }
		
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			
			// Category - Post
			modelBuilder.Entity<Category>()
				.HasMany(p => p.Posts)
				.WithOne(c => c.Category)
				.HasForeignKey(p => p.CategoryId)
				.OnDelete(DeleteBehavior.NoAction);

			// User - Post
			modelBuilder.Entity<User>()
				.HasMany(p => p.Posts)
				.WithOne(u => u.User)
				.HasForeignKey(p => p.UserId);

			// User - Follow - Category
			modelBuilder.Entity<UserFollowsCategory>().HasKey(ob => new { ob.UserId, ob.CategoryId });
			
			modelBuilder.Entity<Category>()
				.HasMany(uc => uc.Users)
				.WithOne(c => c.Category)
				.HasForeignKey(uc => uc.CategoryId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<User>()
				.HasMany(uc => uc.Categories)
				.WithOne(c => c.User)
				.HasForeignKey(uc => uc.UserId)
				.OnDelete(DeleteBehavior.NoAction);
			
			// User - Comment
			modelBuilder.Entity<User>()
				.HasMany(u => u.Comments)
				.WithOne(c => c.User)
				.HasForeignKey(c => c.UserId);

			// Post - Comment
			modelBuilder.Entity<Post>()
				.HasMany(p => p.Comments)
				.WithOne(c => c.Post)
				.HasForeignKey(c => c.PostId)
				.OnDelete(DeleteBehavior.Cascade);

			// User - Saves - Post
			modelBuilder.Entity<Saved>().HasKey(ob => new { ob.UserId, ob.PostId });

			modelBuilder.Entity<User>()
				.HasMany(u => u.Saves)
				.WithOne(s => s.User)
				.HasForeignKey(s => s.UserId)
				.OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<Post>()
				.HasMany(p => p.Saves)
				.WithOne(s => s.Post)
				.HasForeignKey(s => s.PostId)
				.OnDelete(DeleteBehavior.Cascade);
			
			// User - Likes - Post
			modelBuilder.Entity<Liked>().HasKey(ob => new { ob.UserId, ob.PostId });

			modelBuilder.Entity<User>()
				.HasMany(u => u.Likes)
				.WithOne(l => l.User)
				.HasForeignKey(l => l.UserId)
				.OnDelete(DeleteBehavior.NoAction);

			modelBuilder.Entity<Post>()
				.HasMany(p => p.Likes)
				.WithOne(l => l.Post)
				.HasForeignKey(l => l.PostId)
				.OnDelete(DeleteBehavior.Cascade);
		}
	}
}
