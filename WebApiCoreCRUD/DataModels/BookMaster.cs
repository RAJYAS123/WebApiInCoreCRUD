using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCoreCRUD.DataModels
{
    public class BookMaster
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "book name is required")]
        public string BookName { get; set; }
        [Required(ErrorMessage = "author is required")]
        public string AuthorName { get; set; }
        [Required(ErrorMessage = "price is required")]
        public string Price { get; set; }

        //public string Address { get; set; }
    }
}
