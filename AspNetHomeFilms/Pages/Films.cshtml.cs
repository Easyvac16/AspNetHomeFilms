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
        public void OnGet()
        {
        }
    }
}
