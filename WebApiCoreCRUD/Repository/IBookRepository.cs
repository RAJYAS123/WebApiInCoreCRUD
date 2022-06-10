using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCoreCRUD.DataModels;

namespace WebApiCoreCRUD.Repository
{
   public interface IBookRepository
    {
        Task<List<BookMaster>> GetAllBookDatails();

        Task<BookMaster> GetBookDatailsById(int bookid);

        Task<BookMaster> AddBookDetails(BookMaster bookMaster);
        Task DeleteBooksByIdAsync(int bookid);

        Task UpdateBookDetails(int Bookid, BookMaster bookMaster);
    }
}
