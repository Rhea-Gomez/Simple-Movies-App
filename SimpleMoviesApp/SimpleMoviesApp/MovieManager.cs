using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SimpleMoviesApp
{
    internal class MovieManager
    {
        Movies[] movies = new Movies[5];
        public static int count = 0;
        string path = @"D:\Training\Assignments\SimpleMoviesApp\SerializeJSONfile.json";
        string textPath = @"D:\Training\Assignments\SimpleMoviesApp\MoviesOutput.txt";

        public void AddMovies()
        {
            Random random = new Random();
            int id = random.Next(100, 999);

            Console.Write("Enter Movie Title : ");
            string name = Console.ReadLine();

            Console.Write("Enter Year Of Release : ");
            string year = Console.ReadLine();

            Console.Write("Enter Genre: ");
            string genre = Console.ReadLine();

            

            try
            {
                if (count > 5)
                {
                    throw new MaximumMoviesException("Cannot add more than 5 movies");
                }
                else
                {
                    movies[count] = new Movies(id, name, year, genre);
                    count++;
                    Console.WriteLine("Movie added successfully");
                }

            }
            catch (MaximumMoviesException ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {

            }

        }

        public void DisplayAllMovies()
        {
            if (count == 0)
            {
                Console.WriteLine("No movies in the array. Array is empty");
            }
            else
            {
                if(movies != null)
                {
                    for (int i = 0; i < count; i++)
                    {
                        Console.WriteLine(movies[i].ToString());
                    }
                }
                
            }

        }

        public void ClearAllMovies()
        {
            movies = new Movies[movies.Length];
            count = 0;
            Console.WriteLine("All Movies in the array are cleared");
        }

        public void SerializeMoviesToJson()
        {
            var movieList = movies.Where(m => m != null).ToList(); // Only serialize valid entries
            string jsonString = JsonSerializer.Serialize(movieList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(path, jsonString);
            Console.WriteLine("Movies serialized to JSON.");
        }

        public void DeserializeMoviesFromJson()
        {
            if (!File.Exists(path))
            {
                Console.WriteLine("Serialized JSON file not found.");
                return;
            }

            string fileString = File.ReadAllText(path);
            var deserializedList = JsonSerializer.Deserialize<List<Movies>>(fileString);

            if (deserializedList == null || deserializedList.Count == 0)
            {
                Console.WriteLine("No movies found in the JSON file.");
                return;
            }

            ClearAllMovies(); // Reset array and count

            foreach (var movie in deserializedList)
            {
                if (count < movies.Length)
                {
                    movies[count++] = movie;
                }
            }

            Console.WriteLine("Movies deserialized successfully.");
        }

        public void SaveToTextFile()
        {
            var movieLines = movies.Where(m => m != null)
                                   .Select(m => $"ID: {m.Id}, Title: {m.Name}, Year: {m.YearOfRelease}, Genre: {m.Genre}");
            File.WriteAllText(textPath, string.Join("\n", movieLines));
            Console.WriteLine("Movie data written to text file.");
        }

        public void DisplayTextFile()
        {
            if (!File.Exists(textPath))
            {
                Console.WriteLine("Text file not found.");
                return;
            }

            string content = File.ReadAllText(textPath);
            Console.WriteLine("\n--- Contents of MoviesOutput.txt ---");
            Console.WriteLine(content);
        }




    }
}

