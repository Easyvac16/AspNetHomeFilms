namespace AspNetHomeFilms.Model
{
    public class Film
    {
        public string Title { get; set; }
        public string Producer { get; set; }
        public string Style { get; set; }
        public string ShortDescription { get; set; }
        public int Seanses { get; set; }

        public Film()
        {

        }

        public Film(string title, string producer, string style, string shortDescription, int seanses)
        {
            Title = title;
            Producer = producer;
            Style = style;
            ShortDescription = shortDescription;
            Seanses = seanses;
        }

        public override string ToString()
        {
            return $"Title:{Title} Producer:{Producer} Style:{Style} Description:{ShortDescription} Seanses:{Seanses}";
        }

    }
}
