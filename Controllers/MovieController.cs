using Microsoft.AspNetCore.Mvc;
using MvcMovie.Data;
using MvcMovie.Models;
using MvcMovie.Models.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;

namespace MvcMovie.Controllers;

[Authorize]
public class MovieController : Controller
{

    private MvcMovieContext _context;
    private readonly UserManager<IdentityUser> _userManager;

    public MovieController(MvcMovieContext context, UserManager<IdentityUser> userManager)
    {   this._userManager = userManager;
        _context = context;
    }

    [AllowAnonymous]
    public IActionResult Index(string SearchString = ""){

        //_context takes from the database below.
       // --> dette virker for alle movies IEnumerable<movie> movies = _context.movies.ToList();

        if(SearchString == null){
            SearchString = "";
        }


        var movies = from p in _context.Movie select p;
        
        /*
        IdentityUser user = await _userManager.FindByEmailAsync(HttpContext.User.Identity.Name);


        movies = movies.Include(a => a.User).Where(u => u.User.UserName == user.UserName);
*/
/*
        foreach(movie movie in movies){
            if(!(movie.User.Equals(user))){
                
            }
        }
*/

        movies = movies.Where(t => t.Title.Contains(SearchString) ||
             t.Text.Contains(SearchString)).Include(u => u.User);


        var vm = new MovieIndexVm 
        { 
            Movies = movies.ToList(), 
            SearchString = SearchString 
        };
        
        return View(vm);
    }

    public ActionResult Create(){

        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Created", "Title", "Text", "Status")] Movie movie){
        movie.CreatedDate = DateTime.Now;

        //Validation in the backend
        if (ModelState.IsValid){    

            IdentityUser user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            movie.UserId = user.Id;

            if(Request.Form["saving_type"].Equals("Published")){
                movie.Status = MovieStatus.PUBLISHED;
            }
            else{
                movie.Status = MovieStatus.DRAFT;
            }

            //save to database
            _context.Movie.Add(movie);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        else {
            return View();   
        }
    }

    public IActionResult Edit(int id){

        Movie p = _context.Movie.Include(x => x.Comments).ThenInclude(x => x.User).First(x => x.Id == id);

        return View(p);
    }

    [HttpPost]
    public IActionResult Edit(int id, [Bind("Id", "CreatedDate", "Title", "Text", "Status")] Movie movie){

        if (ModelState.IsValid)
        {
             if(Request.Form["saving_type"].Equals("Published")){
                movie.Status = MovieStatus.PUBLISHED;
            }
            else{
                movie.Status = MovieStatus.DRAFT;
            }

            movie.CreatedDate = DateTime.Now;
            
            _context.Movie.Update(movie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        return View();
    }



/*
    public async Task<IActionResult> Details(int? id){

        if(id == null){
            return NotFound();
        }

        var movie = await _context.movies.FirstOrDefaultAsync(p => p.Id == id);

        if(movie == null){
            return NotFound();
        } 

        return View(movie);
    }
*/

    public async Task<IActionResult> Delete(int? id){

        if(id == null){
            return NotFound();
        }

        var movie = await _context.Movie
        .FirstOrDefaultAsync(p => p.Id == id);
    

    if(movie == null){
        return NotFound();
        }

        return View(movie);
    }


    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id){

        var movie = await _context.Movie.FindAsync(id);
        _context.Remove(movie);
        await _context.SaveChangesAsync();
            
        return RedirectToAction(nameof(Index));
    } 




//Test, for at se om jeg kan vise en movie's comments på en side
    
    public  IActionResult ShowComments(int? Id, [Bind("Id", "CreatedDate", "Title", "Text", "Status")] Movie movie){

        if(Id == null){
            Console.WriteLine("ID ER " + Id);
            return NotFound();
        }

        Movie movie_comments = _context.Movie.Include(c => c.Comments).First(x => x.Id == Id);
        var pp = movie_comments.Comments;
        // var comments = await _context.movies.FindAsync(Id);
        
        //await _context.SaveChangesAsync();

        return null;
    }
}