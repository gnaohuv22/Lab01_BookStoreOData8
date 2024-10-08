using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Controllers;
using Microsoft.EntityFrameworkCore;
using ODataBookStore.Models;

namespace ODataBookStore.Controllers
{
    public class BooksController : ODataController
    {
        private BookStoreContext db;
        public BooksController(BookStoreContext context)
        {
            db = context;
            db.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            if (context.Books.Count() == 0)
            {
                foreach (var b in DataSource.GetBooks())
                {
                    context.Books.Add(b);
                    context.Presses.Add(b.Press);

                }
                context.SaveChanges();
            }
        }

        [EnableQuery(PageSize = 5)]
        public IActionResult Get()
        {
            return Ok(db.Books);
        }

        [EnableQuery]
        public IActionResult Get(int key)
        {
            return Ok(db.Books.FirstOrDefault(c => c.Id == key));
        }

        [EnableQuery]
        public IActionResult Post([FromBody] BookDto bookDto)
        {
            var book = new Book
            {
                ISBN = bookDto.ISBN,
                Title = bookDto.Title,
                Author = bookDto.Author,
                Price = bookDto.Price
            };

            db.Books.Add(book);
            db.SaveChanges();
            return Created(book);
        }

        [EnableQuery]
        public IActionResult Delete(int key)
        {
            Book b = db.Books.FirstOrDefault(c => c.Id == key);
            if (b == null)
            {
                return NotFound();
            }

            db.Books.Remove(b);
            db.SaveChanges();
            return Ok();
        }

        [EnableQuery]
        public IActionResult Put(int key, [FromBody] BookDto bookDto)
        {
            if (key != bookDto.Id)
            {
                return BadRequest();
            }

            var book = new Book
            {
                Id = bookDto.Id,
                ISBN = bookDto.ISBN,
                Title = bookDto.Title,
                Author = bookDto.Author,
                Price = bookDto.Price
            };

            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();
            return Updated(book);
        }

    }
}
