﻿using AspNetHomeFilms.Abstract;
using AspNetHomeFilms.Model;
using Newtonsoft.Json;

namespace AspNetHomeFilms.Service
{
    public class FilmOutputSaveService : IFilmOutputSaveService
    {
        List<Film> _films;

        public FilmOutputSaveService()
        {
            _films = ReadFromJsonFile("films.json");
        }

        public List<Film> ReadFromJsonFile(string filePath)
        {
            try
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<List<Film>>(json);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Помилка при читанні JSON-файлу: {ex.Message}");
                return new List<Film>();
            }
        }
        public void WriteToJsonFile(Film film, string filePath)
        {
            List<Film> films = new List<Film>();

            if (File.Exists(filePath))
            {
                string jsonString = File.ReadAllText(filePath);

                if (!string.IsNullOrWhiteSpace(jsonString))
                {
                    films = JsonConvert.DeserializeObject<List<Film>>(jsonString);
                }
            }

            films.Add(film);

            string updatedJson = JsonConvert.SerializeObject(films, Formatting.Indented);
            File.WriteAllText(filePath, updatedJson);

        }
        public void RemoveFilm(string filePath)
        {
            Console.WriteLine("LVA");
        }

        public List<Film> GetFilms() => _films;

        public void AddFilm(Film film) => WriteToJsonFile(film, "films.json");

    }
}
