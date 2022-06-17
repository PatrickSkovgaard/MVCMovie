using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;
using Microsoft.AspNetCore.Identity;


namespace MvcMovie.Controllers
{

    public class CommentController : Controller
    {
        private readonly MvcMovieContext _context;
        private readonly UserManager<IdentityUser> _userManager;


        public CommentController(MvcMovieContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            this._userManager = userManager;
        }

        
        public async Task<IActionResult> Index()
        {
            var mvcMovieContext = _context.Comments.Include(c => c.Movie);
            return View(await mvcMovieContext.ToListAsync());
        }

       
/*
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Details(int? movieId)
        {
            if (movieId == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments
                .Include(c => c.Movie)
                .FirstOrDefaultAsync(m => m.MovieId == movieId);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }
*/
      
        public IActionResult Create(int? id)
        {

            ViewData["MovieId"] = RouteData.Values["id"].ToString();


            var movieTitle = from m in _context.Movie select m;

            ViewData["movi"] = movieTitle.Where(m => m.Id == id).Single().Title;
            

            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommentId, Content, TimeStamp, MovieId, UserId")] Comment comment)
        {

            comment.TimeStamp = DateTime.Now;

            try{
                IdentityUser user = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);
            
                if (ModelState.IsValid){

                    if(user.Id.Equals(null) || user.Id.Equals("")){
                        user.Id = "Anonymous user";
                    }
                    comment.UserId = user.Id;
                    _context.Add(comment);
                    await _context.SaveChangesAsync();
                    
                    return RedirectToAction(controllerName: "Movie", 
                    actionName: "ShowComments", 
                    routeValues: new {id = comment.MovieId});
                }

                return View(comment);
            }

            catch(Exception e){
                Console.WriteLine("User is undefined" + e.GetBaseException());
                return View();
            }
        }



        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound();
            }
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Text", comment.MovieId);
            return View(comment);
        }

        
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CommentId, Title, Content, TimeStamp, MovieId")] Comment comment)
        {
            if (id != comment.CommentId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentExists(comment.CommentId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Text", comment.MovieId);
            return View(comment);
        }

        
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var comment = await _context.Comments
                .Include(c => c.Movie)
                .FirstOrDefaultAsync(m => m.CommentId == id);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment);
        }

        
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var comment = await _context.Comments.FindAsync(id);
            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommentExists(int id)
        {
            return _context.Comments.Any(e => e.CommentId == id);
        }

/*
        public IActionResult CommentsFromMovie(int? id){
            return null;
        }
*/
    }
}
