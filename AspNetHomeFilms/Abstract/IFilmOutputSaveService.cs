using AspNetHomeFilms.Model;

namespace AspNetHomeFilms.Abstract
{
    public interface IFilmOutputSaveService
    {
        public List<Film> ReadFromJsonFile(string filePath);
        public void WriteToJsonFile(Film film, string filePath);
        public void WriteToJsonFile(List<Film> films, string filePath);
        public List<Film> GetFilms();
        public void AddFilm(Film film);
        public void DeleteFilmFromJSON(Film film);

        public Film FindFilm(Film filmToFind);
        public void UpdateFilm(Film film,Film FilmToUpdate);
    }
}
