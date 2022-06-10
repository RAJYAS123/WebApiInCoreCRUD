using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCoreCRUD.DataContext;
using WebApiCoreCRUD.DataModels;

namespace WebApiCoreCRUD.Repository
{
    public class BookRepository : IBookRepository
    {
        private readonly BookContext _bookContext;
        public BookRepository(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public async Task<List<BookMaster>> GetAllBookDatails()
        {
            var records = await _bookContext.bookMasters.Select(x => new BookMaster()
            {
                Id = x.Id,
                BookName = x.BookName,
                AuthorName = x.AuthorName,
                Price = x.Price,
            }).ToListAsync();
            return records;
        }

        public async Task<BookMaster> GetBookDatailsById(int bookid)
        {
            var records = await _bookContext.bookMasters.Where(x => x.Id == bookid).Select(x => new BookMaster()
            {
                Id = x.Id,
                BookName = x.BookName,
                AuthorName = x.AuthorName,
                Price = x.Price,
            }).FirstOrDefaultAsync();
            return records;
        }

        public async Task<BookMaster> AddBookDetails(BookMaster bookMaster)
        {

            var addbook = new BookMaster()
            {
                BookName = bookMaster.BookName,
                AuthorName = bookMaster.AuthorName,
                Price = bookMaster.Price
            };

            _bookContext.bookMasters.Add(addbook);
            await _bookContext.SaveChangesAsync();
            return addbook;

        }


        public async Task DeleteBooksByIdAsync(int bookid)
        {
            var Bookid = new BookMaster() { Id = bookid };
            _bookContext.bookMasters.Remove(Bookid);
            await _bookContext.SaveChangesAsync();

        }

        public async Task UpdateBookDetails(int Bookid, BookMaster bookMaster)
        {

            var addbook = new BookMaster()
            {
                Id = Bookid,
                BookName = bookMaster.BookName,
                AuthorName = bookMaster.AuthorName,
                Price = bookMaster.Price
            };

            _bookContext.bookMasters.Update(addbook);
            await _bookContext.SaveChangesAsync();

        }
    }
}
