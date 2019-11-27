using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Libreria.Models;
using Libreria.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Libreria.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly IBooksDataService _data;
        public IEnumerable<Book> Books { get; set; }
        public IndexModel(ILogger<IndexModel> logger, IBooksDataService booksDataServices)
        {
            _logger = logger;
            _data = booksDataServices;
        }

        public void OnGet()
        {
            Books = _data.GetBooks();
        }
    }
}
