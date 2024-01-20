using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BookMVC.Models;

namespace BookMVC.Controllers
{
    public class BookController : Controller
    {
        private readonly BooksDbContext _context;

        public BookController(BooksDbContext context)
        {
            _context = context;
        }

        // GET: Book
        public async Task<IActionResult> Index()
        {
              return _context.TblBooks != null ? 
                          View(await _context.TblBooks.ToListAsync()) :
                          Problem("Entity set 'BooksDbContext.TblBooks'  is null.");
        }

        public async Task<IActionResult> ShowAll()
        {
            return _context.TblBooks != null ?
                          View(await _context.TblBooks.ToListAsync()) :
                          Problem("Entity set 'BooksDbContext.TblBooks'  is null.");
        }

        // GET: Book/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TblBooks == null)
            {
                return NotFound();
            }

            var tblBook = await _context.TblBooks
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (tblBook == null)
            {
                return NotFound();
            }

            return View(tblBook);
        }

        // GET: Book/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookName,BookAuthor,BookPrice")] TblBook tblBook)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tblBook);
                await _context.SaveChangesAsync();
                ViewBag.id = "Book Added! ID: " + tblBook.BookId;
                return View();
            }
            return View(tblBook);
        }

        // GET: Book/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TblBooks == null)
            {
                return NotFound();
            }

            var tblBook = await _context.TblBooks.FindAsync(id);
            if (tblBook == null)
            {
                return NotFound();
            }
            return View(tblBook);
        }

        // POST: Book/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookId,BookName,BookAuthor,BookPrice")] TblBook tblBook)
        {
            if (id != tblBook.BookId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblBook);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblBookExists(tblBook.BookId))
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
            return View(tblBook);
        }

        // GET: Book/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TblBooks == null)
            {
                return NotFound();
            }

            var tblBook = await _context.TblBooks
                .FirstOrDefaultAsync(m => m.BookId == id);
            if (tblBook == null)
            {
                return NotFound();
            }

            return View(tblBook);
        }

        // POST: Book/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TblBooks == null)
            {
                return Problem("Entity set 'BooksDbContext.TblBooks'  is null.");
            }
            var tblBook = await _context.TblBooks.FindAsync(id);
            if (tblBook != null)
            {
                _context.TblBooks.Remove(tblBook);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblBookExists(int id)
        {
          return (_context.TblBooks?.Any(e => e.BookId == id)).GetValueOrDefault();
        }
    }
}
