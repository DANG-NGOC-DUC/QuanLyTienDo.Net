using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkProgressManagement.Models
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }

        [Required]
        [MaxLength(255)]
        public string PasswordHash { get; set; }

        [Required]
        [MaxLength(100)]
        public string FullName { get; set; }

        [MaxLength(100)]
        public string Email { get; set; }

        [Required]
        [MaxLength(20)]
        public string Role { get; set; }

        public int? ProjectId { get; set; }

        public bool IsActive { get; set; } = true;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }

        public virtual ICollection<Project> ManagedProjects { get; set; }

        public virtual ICollection<TaskItem> AssignedTasks { get; set; }

        public virtual ICollection<TaskComment> Comments { get; set; }

        public User()
        {
            ManagedProjects = new HashSet<Project>();
            AssignedTasks = new HashSet<TaskItem>();
            Comments = new HashSet<TaskComment>();
        }
    }
}