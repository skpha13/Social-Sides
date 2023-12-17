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
		public DbSet<Profile> Profiles { get; set; }
		public DbSet<Notification> Notifications { get; set; }
		public DbSet<NotificationType> NotificationTypes { get; set; }
		public DbSet<UserFollowsCategory> UserFollowsCategories { get; set; }
		public DbSet<Comment> Comments { get; set; }
		public DbSet<Saved> Saves { get; set; }
		
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			// Category - Post
			modelBuilder.Entity<Category>()
				.HasMany(p => p.Posts)
				.WithOne(c => c.Category)
				.HasForeignKey(p => p.CategoryId);

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
				.HasForeignKey(uc => uc.CategoryId);
			
			modelBuilder.Entity<User>()
				.HasMany(uc => uc.Categories)
				.WithOne(c => c.User)
				.HasForeignKey(uc => uc.UserId);

			// User - Profile
			modelBuilder.Entity<User>()
				.HasOne(p => p.Profile)
				.WithOne(u => u.User)
				.HasForeignKey<Profile>(p => p.UserId)
				.OnDelete(DeleteBehavior.Cascade);
			
			// User - Notification
			modelBuilder.Entity<User>()
				.HasMany(n => n.Notifications)
				.WithOne(u => u.User)
				.HasForeignKey(n => n.UserId)
				.OnDelete(DeleteBehavior.Cascade);

			// Notification - NotificationType
			modelBuilder.Entity<Notification>()
				.HasOne(n => n.NotificationType)
				.WithOne(nt => nt.Notification)
				.HasForeignKey<Notification>(nt => nt.NotificationTypeId)
				.OnDelete(DeleteBehavior.Cascade);
			
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

			// User - Save - Post
			modelBuilder.Entity<User>()
				.HasMany(u => u.Saves)
				.WithOne(s => s.User)
				.HasForeignKey(s => s.UserId)
				.OnDelete(DeleteBehavior.Cascade);

			modelBuilder.Entity<Post>()
				.HasMany(p => p.Saves)
				.WithOne(s => s.Post)
				.HasForeignKey(s => s.PostId);
		}
	}
}
