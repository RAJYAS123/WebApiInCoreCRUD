using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCoreCRUD.DataContext;
using WebApiCoreCRUD.DataModels;

namespace WebApiCoreCRUD.Repository
{
    public class AuthorRepository :IAuthorRepository
    {
        private readonly BookContext _bookContext;
        public AuthorRepository(BookContext bookContext)
        {
            _bookContext = bookContext;
        }

        public async Task<List<AuthorMaster>> GetAllAuthorList()
        {
            var records = await _bookContext.AuthorMasters.Select(x => new AuthorMaster()
            {
                Id = x.Id,
                BookName = x.BookName,
                AuthorName = x.AuthorName,
                Price = x.Price,
            }).ToListAsync();
            return records;
        }


        //public async Task<AuthorMaster> AddBookDetails(AuthorMaster authorMaster)
        //{
        //
        //    var AddAuthor = new AuthorMaster()
        //    {
        //        BookName = authorMaster.BookName,
        //        AuthorName = authorMaster.AuthorName,
        //        Price = authorMaster.Price,
        //    };
        //    _bookContext.AuthorMasters.Add(AddAuthor);
        //    await _bookContext.SaveChangesAsync();
        //    return AddAuthor;
        //}
    }
}
