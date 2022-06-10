using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiCoreCRUD.DataModels;

namespace WebApiCoreCRUD.Repository
{
   public interface IAuthorRepository
    {
        Task<List<AuthorMaster>> GetAllAuthorList();
    }
}
