using System.Collections.Generic;

namespace SalesSystem
{
    public class Movie
    {
        public string Title { get; set; } = null!;
        public string Rating { get; set; } = null!;
        public int DurationMinutes { get; set; }
        public string Description { get; set; } = null!;
        public List<string> Schedule { get; set; } = new();

        public override string ToString() => $"{Title} ({Rating}, {DurationMinutes} min)";

        public static List<Movie> GetAllMovies()
        {
            return new List<Movie>
            {
                new Movie {
                    Title = "Furiosa: A Mad Max Saga",
                    Rating = "R",
                    DurationMinutes = 148,
                    Description = "After being snatched from the Green Place of Many Mothers, " +
                                  "young Furiosa falls into the hands of a great Biker Horde " +
                                  "led by the Warlord Dementus. Sweeping through the Wasteland, " +
                                  "they come across the Citadel presided over by The Immortan Joe.",
                    Schedule = new List<string> { "Tuesday 18:00", "Saturday 21:00" }
                },
                new Movie {
                    Title = "Dog Day Afternoon",
                    Rating = "R",
                    DurationMinutes = 125,
                    Description = "Three amateur robbers plan to hold up a Brooklyn bank. " +
                                  "When they discover there isn't much money in the bank, " +
                                  "the simple robbery turns into a prolonged hostage situation " +
                                  "and media circus.",
                    Schedule = new List<string> { "Thursday 21:00" }
                },
                new Movie {
                    Title = "The Fall Guy",
                    Rating = "PG-13",
                    DurationMinutes = 126,
                    Description = "A stuntman, fresh off an almost career-ending accident, " +
                                  "has to track down a missing movie star, solve a conspiracy, " +
                                  "and try to win back the love of his life.",
                    Schedule = new List<string> { "Tuesday 21:00", "Friday 21:00" }
                },
                new Movie {
                    Title = "Iron Man 3",
                    Rating = "PG-13",
                    DurationMinutes = 130,
                    Description = "Tony Stark faces a formidable terrorist called the Mandarin. " +
                                  "With his world destroyed, he embarks on a journey of rebuilding " +
                                  "and discovers what it really means to be Iron Man.",
                    Schedule = new List<string> { "Wednesday 18:00", "Saturday 13:00" }
                },
                new Movie {
                    Title = "Civil War",
                    Rating = "R",
                    DurationMinutes = 109,
                    Description = "In a dystopian future America, torn apart by civil conflict, " +
                                  "a team of journalists embarks on a dangerous journey across " +
                                  "the country to reach Washington D.C. before rebel factions do.",
                    Schedule = new List<string> { "Friday 18:00", "Saturday 18:00" }
                },
                new Movie {
                    Title = "The Room Next Door",
                    Rating = "PG-13",
                    DurationMinutes = 107,
                    Description = "Ingrid and Martha, once close friends, meet again after many years. " +
                                  "Both face personal struggles and must confront their past together, " +
                                  "rekindling their complicated relationship.",
                    Schedule = new List<string> { "Wednesday 21:00", "Thursday 18:00" }
                }
            };
        }
    }
}
    