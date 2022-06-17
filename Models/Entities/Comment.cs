using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MvcMovie.Models;

    public class Comment {

        public int CommentId { get; set; }
        public DateTime? TimeStamp { get; set; }

        [StringLength(60, MinimumLength = 1, ErrorMessage = "Comment cannot be empty")]
        [Required(ErrorMessage = "Please fill out title")]
        public string Content { get; set; }

        public Movie Movie { get; set; }

        public int MovieId { get; set; }

        public string? UserId { get; set; }
        public IdentityUser? User { get; set; }
    }