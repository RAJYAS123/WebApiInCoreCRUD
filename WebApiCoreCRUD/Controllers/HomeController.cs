using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCoreCRUD.DataModels;
using WebApiCoreCRUD.Repository;
using WebApiCoreCRUD.Utility;

namespace WebApiCoreCRUD.Controllers
{
    //[Authorize]
    [BasicAuthentication]   
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        private IBookRepository _bookRepository;
        private IAuthorRepository _authorRepository;

        public HomeController(IBookRepository bookRepository,IAuthorRepository authorRepository)
        {
            _bookRepository = bookRepository;
            _authorRepository = authorRepository;
        }


        #region Book Master

        [HttpGet]
        [Route("GetAuthorAllBook")]
        public async Task<IActionResult> GetAllBooks()
        {
            var books = await _authorRepository.GetAllAuthorList();
            return Ok(books);
        }


        [HttpGet]
        [Route("GetAllBookDetails")]
        public async Task<IActionResult> GetAllBook()
        {
            var books = await _bookRepository.GetAllBookDatails();
            return Ok(books);
        }

        [HttpGet]
        [Route("GetBookById")]
        public async Task<IActionResult> GetBooksByID(int id)
        {
            var bookbyid = await _bookRepository.GetBookDatailsById(id);
            if (bookbyid == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(bookbyid);
            }
        }

        [HttpPost]
        [Route("AddNewBook")]
        public async Task<IActionResult> AddBookMaster([FromBody] BookMaster bookMaster)
        {
            var NewBook = await _bookRepository.AddBookDetails(bookMaster);
            if (NewBook == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(NewBook);
            }
        }

        [HttpDelete]
        [Route("DeleteBookById")]
        public async Task<IActionResult> DeleteformDb(int id)
        {
            await _bookRepository.DeleteBooksByIdAsync(id);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateBookById")]
        public async Task<IActionResult> GetBooksByID([FromBody] BookMaster bookMaster,int id)
        {
            await _bookRepository.UpdateBookDetails(id, bookMaster);

            return Ok();

        }

        //#endregion

        //#region AuthorMaster

        //[HttpGet]
        //public async Task<IActionResult> GetAllAuthor()
        //{
        //    var books = await _authorRepository.GetAllAuthorList();
        //    return Ok(books);
        //}



        //[HttpPost("")]
        //public async Task<IActionResult> AddAuthorMaster([FromBody]AuthorMaster authorMaster)
        //{
        //    var NewAuth = await _authorRepository.AddBookDetails(authorMaster);
        //    if (NewAuth == null)
        //    {
        //        return NotFound();
        //    }
        //    else
        //    {
        //        return Ok(NewAuth);
        //    }
        //}
        #endregion

        [AllowAnonymous]
        [HttpGet]
        [Route("GenrateTokanKey")]
        public string Authentication(string UserName, string Password)
        {
            if (UserName == "compiler" && Password == "coder")
            {
                var token = $"{UserName}@{Password}@{DateTime.Now}";
                var data = WebApiCoreCRUD.Utility.GlobalUtilities.Encryption(token);
                if (!string.IsNullOrEmpty(data))
                {
                    return (data);
                }
            }
            return ("Unauthorized");
        }


        //public async Task<string> LoginAsync()
        //{

        //}

    }
}
