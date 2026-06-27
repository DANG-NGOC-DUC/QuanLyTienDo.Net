using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkProgressManagement.Models
{
    public class Project
    {
        [Key]
        public int ProjectId { get; set; }

        [Required]
        [MaxLength(150)]
        public string ProjectName { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        [MaxLength(30)]
        public string Status { get; set; }

        public int ManagerId { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("ManagerId")]
        public virtual User Manager { get; set; }

        public virtual ICollection<User> Members { get; set; }

        public virtual ICollection<TaskItem> Tasks { get; set; }

        public Project()
        {
            Members = new HashSet<User>();
            Tasks = new HashSet<TaskItem>();
        }
    }
}