namespace SimpleMoviesApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int choice;

            MovieManager manager = new MovieManager();
            do
            {
                Console.WriteLine("Welcome to Movie Store App!");
                Console.WriteLine("Select an option from the given menu: ");
                Console.WriteLine("1. Add new Movie \n2. Display All Movies \n3. Clear All Movies \n4. Exit");
                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        manager.AddMovies();
                        Console.WriteLine();
                        break;
                    case 2:
                        manager.DisplayAllMovies();
                        Console.WriteLine();
                        break;
                    case 3:
                        manager.ClearAllMovies();
                        Console.WriteLine();
                        break;
                    case 4:
                        manager.SerializeMoviesToJson();
                        manager.DeserializeMoviesFromJson();
                        manager.SaveToTextFile();
                        manager.DisplayTextFile();
                        //to do exit
                        break;
                    default:
                        Console.WriteLine("Enter a valid choice");
                        Console.WriteLine();
                        break;
                }
            } while (choice != 4);



        }
    }
}
    

