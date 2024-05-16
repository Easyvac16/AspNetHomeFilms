using AspNetHomeFilms.Model;

namespace AspNetHomeFilms.Abstract
{
    public interface IFilmOutputSaveService
    {
        public List<Film> ReadFromJsonFile(string filePath);
        public void WriteToJsonFile(Film film, string filePath);
        public void RemoveFilm(string filePath);
        public List<Film> GetFilms();
        public void AddFilm(Film film);
    }
}
