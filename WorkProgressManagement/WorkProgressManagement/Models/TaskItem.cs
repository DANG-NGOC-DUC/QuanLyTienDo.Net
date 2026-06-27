using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkProgressManagement.Models
{
    public class TaskItem
    {
        [Key]
        public int TaskId { get; set; }

        public int ProjectId { get; set; }

        public int AssignedTo { get; set; }

        [Required]
        [MaxLength(150)]
        public string TaskName { get; set; }

        public string Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime DueDate { get; set; }

        [Range(0, 100)]
        public int CurrentProgress { get; set; }

        [Required]
        [MaxLength(30)]
        public string Status { get; set; }

        [MaxLength(20)]
        public string Priority { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("ProjectId")]
        public virtual Project Project { get; set; }

        [ForeignKey("AssignedTo")]
        public virtual User Assignee { get; set; }

        public virtual ICollection<TaskComment> Comments { get; set; }

        public TaskItem()
        {
            Comments = new HashSet<TaskComment>();
        }
    }
}