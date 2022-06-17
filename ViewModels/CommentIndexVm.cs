using Microsoft.AspNetCore.Identity;
namespace MvcMovie.Models.Entities;


public class CommentIndexVm{

    public IEnumerable<Comment> Comments {get; set;}

    public int? MovieId {get; set;}

    public IdentityUser? User {get; set;}

    public Movie Movie {get; set;}
}