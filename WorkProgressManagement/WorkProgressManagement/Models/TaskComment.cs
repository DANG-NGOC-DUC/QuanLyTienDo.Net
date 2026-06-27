using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WorkProgressManagement.Models
{
    public class TaskComment
    {
        [Key]
        public int CommentId { get; set; }

        public int TaskId { get; set; }

        public int UserId { get; set; }

        [Required]
        public string Content { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey("TaskId")]
        public virtual TaskItem Task { get; set; }

        [ForeignKey("UserId")]
        public virtual User User { get; set; }
    }
}