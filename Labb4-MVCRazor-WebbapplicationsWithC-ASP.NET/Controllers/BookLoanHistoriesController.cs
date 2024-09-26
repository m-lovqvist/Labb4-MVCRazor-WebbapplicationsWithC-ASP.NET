using Labb4_MVCRazor_WebbapplicationsWithC_ASP.NET.Data;
using Labb4_MVCRazor_WebbapplicationsWithC_ASP.NET.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Labb4_MVCRazor_WebbapplicationsWithC_ASP.NET.Controllers
{
    public class BookLoanHistoriesController : Controller
    {
        private readonly ApplicationDbContext db;

        public BookLoanHistoriesController(ApplicationDbContext _db)
        {
            db = _db;
        }

        // GET: LoanHistories/Create
        public ActionResult Create(int? bookId)
        {
            if (bookId == null)
            {
                return BadRequest();
            }

            var book = db.Books.Find(bookId);
            if (book == null)
            {
                return NotFound();
            }

            ViewBag.CustomerId = new SelectList(db.Customers, "CustomerId", "FullName");
            ViewBag.BookId = new SelectList(db.Books, "BookId", "BookTitle");

            var newCheckOut = new BookLoanViewModel();

            return View(newCheckOut);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(BookLoanViewModel bookLoanViewModel)
        {
            int bookId = bookLoanViewModel.BookId;
            var bookHistory = await db.Books.FirstOrDefaultAsync(x => x.BookId == bookId);

            if (ModelState.IsValid)
            {
                if (bookHistory.IsCheckedOut == false)
                {
                    var today = DateTime.Now.Date;

                    var newBorrow = new BookLoanHistory
                    {
                        CustomerId = bookLoanViewModel.CustomerId,
                        BookId = bookLoanViewModel.BookId,
                        CheckoutDate = DateTime.Now.Date,
                        ReturnDate = today.AddDays(14),
                    };
                    await db.BookLoanHistories.AddAsync(newBorrow);
                    await db.SaveChangesAsync();
                    bookHistory.IsCheckedOut = true;
                    db.Books.Update(bookHistory);
                    await db.SaveChangesAsync();

                    return RedirectToAction("Index", "Title");
                }
            }

            return RedirectToAction("Index", "Title");
        }


        // GET: BorrowHistories/Edit/5
        public async Task<ActionResult> Edit(int? bookId, DateTime? returnDate, int bbh)
        {
            if (bookId == null)
            {
                return BadRequest();
            }

            var returnBook = await db.BookLoanHistories.FirstOrDefaultAsync(bh => bh.BookLoanHistoryId == bbh);
            returnBook.ReturnDate = DateTime.Today;
            db.BookLoanHistories.Update(returnBook);
            await db.SaveChangesAsync();

            var book = await db.Books.FirstOrDefaultAsync(b => b.BookId == bookId);
            book.IsCheckedOut = false;
            db.Books.Update(book);
            await db.SaveChangesAsync();

            return RedirectToAction("Index", "Title");
        }

        // POST: BorrowHistories/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind("BorrowHistoryId,BookId,CustomerId,BorrowDate,ReturnDate")] BookLoanHistory borrowHistory)
        {
            // Assuming the data is always valid
            var borrowHistoryItem = db.BookLoanHistories.Include(i => i.BookId)
                .FirstOrDefault(i => i.BookLoanHistoryId == borrowHistory.BookLoanHistoryId);
            if (borrowHistoryItem == null)
            {
                return BadRequest();
            }

            borrowHistoryItem.ReturnDate = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index", "Title");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
