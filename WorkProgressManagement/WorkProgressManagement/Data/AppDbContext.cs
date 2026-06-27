using System.Data.Entity;
using WorkProgressManagement.Models;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace WorkProgressManagement.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
    : base("name=WorkProgressDb")
        {
            Database.SetInitializer<AppDbContext>(null);
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Project> Projects { get; set; }

        public DbSet<TaskItem> Tasks { get; set; }

        public DbSet<TaskComment> TaskComments { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // SQLite không hỗ trợ Multiple Cascade Path
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            modelBuilder.Entity<Project>()
                .HasRequired(x => x.Manager)
                .WithMany(x => x.ManagedProjects)
                .HasForeignKey(x => x.ManagerId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<User>()
                .HasOptional(x => x.Project)
                .WithMany(x => x.Members)
                .HasForeignKey(x => x.ProjectId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaskItem>()
                .HasRequired(x => x.Project)
                .WithMany(x => x.Tasks)
                .HasForeignKey(x => x.ProjectId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaskItem>()
                .HasRequired(x => x.Assignee)
                .WithMany(x => x.AssignedTasks)
                .HasForeignKey(x => x.AssignedTo)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaskComment>()
                .HasRequired(x => x.Task)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.TaskId)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<TaskComment>()
                .HasRequired(x => x.User)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.UserId)
                .WillCascadeOnDelete(false);
        }
    }
}