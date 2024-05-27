using AspNetHomeFilms.Abstract;
using AspNetHomeFilms.Model;
using AspNetHomeFilms.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace AspNetHomeFilms.Pages
{
    public class FilmsModel : PageModel
    {

        public IFilmOutputSaveService FilmOutputSave;

        [BindProperty]
        public Film Film { get; set; } = new Film();

        public override void OnPageHandlerSelected(PageHandlerSelectedContext context)
        {
            FilmOutputSave = new FilmOutputSaveService();


            if (FilmOutputSave.GetFilms().Count == 0)
            {
                FilmOutputSave.AddFilm(new Film("Sir Lawrance Hedgecliff", "Martyr of the Stray Dogs", "Mystery", "Gloverb", 1978));
                FilmOutputSave.AddFilm(new Film("Bonney Betty Belle", "Close the Door on the Way Out", "Comedy", "Practicality", 2008));
                FilmOutputSave.AddFilm(new Film("Prosketti Marcippio", "Swords Crossed", "Romance", "Practicality", 2005));
            }
        }
        [HttpPost]
        public IActionResult OnPost()
        {
            if (!ModelState.IsValid) 
            {
                return Page();
            }

            FilmOutputSave.AddFilm(new Film(Film.Title, Film.Producer, Film.Style, Film.ShortDescription, Film.Seanses));
            return RedirectToPage(); 
        }
        public void OnGet()
        {
        }
    }
}
