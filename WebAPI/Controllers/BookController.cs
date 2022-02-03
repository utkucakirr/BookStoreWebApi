using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]s")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public List<Book> Books;

        public BookController()
        {
            //Adding books to the list.
            Books = new List<Book>();
            Books.Add(new Book { Id = 1, SerialNumber = 300, Name = "Kitap1", Author = "Yazar1", Length = 132 });
            Books.Add(new Book { Id = 2, SerialNumber = 123, Name = "Kitap2", Author = "Yazar2", Length = 123 });
            Books.Add(new Book { Id = 3, SerialNumber = 413, Name = "Kitap3", Author = "Yazar3", Length = 300 });
            Books.Add(new Book { Id = 4, SerialNumber = 234, Name = "Kitap4", Author = "Yazar4", Length = 401});
            Books.Add(new Book { Id = 5, SerialNumber = 100, Name = "Kitap5", Author = "Yazar5", Length = 209 });
            Books.Add(new Book { Id = 6, SerialNumber = 255, Name = "Kitap6", Author = "Yazar6", Length = 867 });
        }

        //Listing all books on the list.
        [HttpPost]
        public IActionResult GetAll()
        {
            return Ok(Books);
        }

        //Getting a book from list using FromQuery.
        [HttpGet]
        public IActionResult GetById([FromQuery] int id)
        {
            var book = Books.FirstOrDefault(x => x.Id == id);
            if (book is null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        //Getting a book from list using FromRoute.
        [HttpGet("{id}")]
        public IActionResult GetById2([FromRoute] int id)
        {
            var book = Books.FirstOrDefault(x => x.Id == id);
            if (book is null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        //Adding a book to the list.
        [HttpPost("add")]
        public IActionResult Add([FromBody] Book book)
        {
            Books.Add(book);
            return Ok(Books);
        }

        //Updating a book on the list.
        [HttpPut("{id}")]
        public IActionResult Update([FromRoute] Book book)
        {
            var temp = Books.FirstOrDefault(x => x.Id == book.Id);
            if (temp is null)
            {
                return NotFound();
            }
            temp.Author = book.Author;
            temp.Length = book.Length;
            temp.Name = book.Name;
            temp.SerialNumber = book.SerialNumber;

            return Ok(Books);
        }

        //Deleting a book from the list.
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var temp = Books.FirstOrDefault(x => x.Id == id);
            if (temp == null)
            {
                return Ok("Not Found");
            }

            Books.Remove(temp);
            return Ok(Books);
        }
    }
}
