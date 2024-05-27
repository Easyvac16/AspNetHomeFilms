using AspNetHomeFilms.Abstract;
using AspNetHomeFilms.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetHomeFilms.Pages
{
    public class FilmInfoModel : PageModel
    {
        private readonly IFilmOutputSaveService FilmOutputSave;

        public FilmInfoModel(IFilmOutputSaveService filmOutputSave)
        {
            FilmOutputSave = filmOutputSave;
        }

        [BindProperty]
        public Film Film { get; set; }

        [BindProperty]
        public Film FilmToUpdate { get; set; }

        public IActionResult OnGet(string title, string producer, string style, string shortDescription, int seanses)
        {
            Film = new Film(title, producer, style, shortDescription, seanses);

            FilmToUpdate = new Film
            {
                Title = Film.Title,
                Producer = Film.Producer,
                Style = Film.Style,
                ShortDescription = Film.ShortDescription,
                Seanses = Film.Seanses
            };

            return Page();
        }

        public IActionResult OnPostDelete()
        {
            if (ModelState.IsValid)
            {
                FilmOutputSave.DeleteFilmFromJSON(Film);
                return RedirectToPage("/Films");
            }
            return Page();
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                FilmOutputSave.UpdateFilm(Film, FilmToUpdate);
                return RedirectToPage("/Films");
            }
            return Page();
        }
    }
}
