using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MvcMovie.Models;

    public class Movie
    {
        public int Id { get; set; }

        [StringLength(60, MinimumLength = 1, ErrorMessage = "Title cannot be empty")]
        [Required(ErrorMessage = "Please fill out title")]
        public string? Title { get; set; }


        [StringLength(300, MinimumLength = 1, ErrorMessage = "Description cannot be empty")]
        [Required(ErrorMessage = "Please enter text")]
        public string? Text { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }

        public MovieStatus Status { get; set; }


        public List<Comment> Comments { get; set; }


        public string UserId { get; set; }

        public IdentityUser? User { get; set; }
    }
