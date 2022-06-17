using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace MvcMovie.Models;

    public class Movie
    {
        public int Id { get; set; }


        [StringLength(40, MinimumLength = 1, ErrorMessage = "Title cannot be empty. Max. of 40 characters.")]
        [Required(ErrorMessage = "Please fill out title")]
        public string? Title { get; set; }


        [StringLength(150, MinimumLength = 1)]
        public string? Description { get; set; }


        [DataType(DataType.Date)]
        [Display(Name = "Created Date")]
        public DateTime CreatedDate { get; set; }


        public List<Comment> Comments { get; set; }


        public int Rating {get; set;} = 0;


        public string UserId { get; set; }


        public IdentityUser? User { get; set; }
    }
