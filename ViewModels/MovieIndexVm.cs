namespace MvcMovie.Models.Entities;

public class MovieIndexVm{
    
    public IEnumerable<Movie> Movies {get; set;}

    public string SearchString {get; set;}
}