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
    public IActionResult Index(string SearchString){

        if(SearchString == null){
            SearchString = "";
        }


        var movies = from p in _context.Movie select p;
        

        movies = movies.Where(t => t.Title.ToLower().Contains(SearchString.ToLower()) ||
             t.Description.ToLower().Contains(SearchString.ToLower())).Include(u => u.User);

        

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
    public async Task<IActionResult> Create([Bind("Created", "Title", "Description", "Rating")] Movie movie){
       
       
        movie.CreatedDate = DateTime.Now;
        
        if (ModelState.IsValid){    

            IdentityUser user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            movie.UserId = user.Id;

            
            _context.Movie.Add(movie);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        else {
            return View();   
        }
    }


    public async Task<IActionResult> Edit(int id){


        IdentityUser user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);

        Movie p = _context.Movie.Include(x => x.Comments).ThenInclude(x => x.User).First(x => x.Id == id);


        if(p.UserId.Equals(user.Id)){
            return View(p);
        }
        else{
            return Unauthorized("ERROR ! \n You are not authorized to edit this movie. Go back to the list.");
        }
    }


    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id", "CreatedDate", "Title", "Description")] Movie movie){

        if (ModelState.IsValid)
        {
            
            IdentityUser user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);

            movie.CreatedDate = DateTime.Now;
            movie.UserId = user.Id;
            
            _context.Movie.Update(movie);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }

        return View();
    }



    public async Task<IActionResult> Delete(int? id){


        IdentityUser user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);


        if(id == null){
            return NotFound();
        }

        var movie = await _context.Movie
        .FirstOrDefaultAsync(p => p.Id == id);


        if(movie == null){
            return NotFound();
            }


        if(movie.UserId.Equals(user.Id)){
            return View(movie);
        }
        else{
            return Unauthorized("ERROR ! \n You are not authorized to delete this movie. Go back to the list.");
        }
    }


    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id){

        var movie = await _context.Movie.FindAsync(id);
        _context.Remove(movie);
        await _context.SaveChangesAsync();
            
        return RedirectToAction(nameof(Index));
    } 

    
    public async Task<IActionResult> ShowComments(int? Id){

        if(Id == null){
            return NotFound();
        }

        Movie movie = _context.Movie.Include(c => c.Comments).ThenInclude(u => u.User).First(mov => mov.Id == Id);
        var comments = movie.Comments;

        comments.Sort((a, b) => b.CommentId - a.CommentId);

        IdentityUser user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);

        var cm = new CommentIndexVm {
            Comments = comments.ToList(),
            MovieId = Id,
            User = user,
            Movie = movie           
        };
        
        return View(cm);
    }
}