using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MvcMovie.Data;
using MvcMovie.Models;

namespace MvcMovie.Controllers
{

    public class CommentController : Controller
    {
        private readonly MvcMovieContext _context;

        public CommentController(MvcMovieContext context)
        {
            _context = context;
        }

        // GET: Comment
        public async Task<IActionResult> Index()
        {
            var mvcMovieContext = _context.Comments.Include(c => c.Movie);
            return View(await mvcMovieContext.ToListAsync());
        }

        // GET: Comment/Details/5
       /* public async Task<IActionResult> Details(int? id)
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
*/

        //Test metode, for at se om Movie title kan bruges til at komme ind på specifikke comments
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

        // GET: Comment/Create
        public IActionResult Create()
        {
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Text");
            return View();
        }

        // Movie: Comment/Create
        // To protect from overMovieing attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CommentId, Title, Content, TimeStamp, MovieId")] Comment comment)
        {
            if (ModelState.IsValid)
            {
                _context.Add(comment);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MovieId"] = new SelectList(_context.Movie, "Id", "Text", comment.MovieId);
            return View(comment);
        }

        // GET: Comment/Edit/5
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

        // Movie: Comment/Edit/5
        // To protect from overMovieing attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
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

        // GET: Comment/Delete/5
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

        // Movie: Comment/Delete/5
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

        public IActionResult CommentsFromMovie(int? id){
            return null;
        }
    }
}
