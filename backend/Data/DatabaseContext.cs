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

			// Category - User
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
				.HasForeignKey<User>(u => u.ProfileId);
			
			// User - Notification
			modelBuilder.Entity<User>()
				.HasMany(n => n.Notifications)
				.WithOne(u => u.User)
				.HasForeignKey(n => n.UserId);

			// Notification - NotificationType
			modelBuilder.Entity<Notification>()
				.HasOne(n => n.NotificationType)
				.WithOne(nt => nt.Notification)
				.HasForeignKey<Notification>(nt => nt.NotificationTypeId);
		}
	}
}
