using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Libreria.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Libreria.Pages.Books
{
    public class InsertBookModel : PageModel
    {
        private readonly IBooksDataService _booksDataService;

        public InsertBookModel(IBooksDataService booksDataService)
        {
            _booksDataService = booksDataService;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public class InputModel
        {
          

            public string Titolo { get; set; }
            [Required] //questa proprietà è obbligatoria
            [StringLength(25)]
            public string Autore { get; set; }
            [Display(Name = "Data di Acquisto")]
            public string DataAcquisto { get; set; }
            
            public bool Finito { get; set; }
        }

        public void OnGet()
        {
        
        }

        public IActionResult OnPost()
        {

            if (ModelState.IsValid) //se il database è connesso allora lo salva
            {
                //questa classe simula l'accesso ai dati
                _booksDataService.InsertBook(Input.Titolo, Input.Autore, Input.DataAcquisto, Input.Finito);
                return RedirectToPage("/Index");
            }

            //Validazione sia lato server che lato client
            //ModelState.AddModelError("", "Errore nell'aggiornamento del prodotto.");
            //ModelState.AddModelError("Input.Code", "Errore caso");
            return Page();
        }
    }
}