namespace T_3_L_21
{
    internal class Program
    {
        static void Main(string[] args)
        {
            MainProgram();
        }
        private static void MainProgram()
        {
            try
            {
                Console.WriteLine("Witaj! podaj swoje imię: ");
                var name = Console.ReadLine();

                Console.WriteLine("\nTeraz podaj miejscowość z której pochodzisz: ");
                var city = Console.ReadLine();

                Console.WriteLine("\nA teraz podaj swoją datę urodzenia: (dd/mm/rrrr)");
                var date = Console.ReadLine();

                if (!DateTime.TryParse(date, out var dateOfBirth))
                {
                    Console.WriteLine("\nPodano zły format daty.");
                    throw new Exception();
                }

                ValidateDateOfBirth(dateOfBirth);

                Console.WriteLine($"\nMasz na imię {name}, urodziłeś się w miejscowości: {city}, i masz {DetermineAge(dateOfBirth)} lat");

            }
            catch (Exception)
            {
                RestartProgram();
            }
        }

        private static void ValidateDateOfBirth(DateTime dateOfBirth)
        {
            if( dateOfBirth > DateTime.Now)
            {
                Console.WriteLine("\nPodana data jest datą późniejszą niż data dzisiejsza.");
                throw new Exception();
            }
        }

        private static void RestartProgram()
        {
            Console.WriteLine("\nNaciśnij cokolwiek by zacząć od nowa");
            Console.ReadLine();
            Console.Clear();
            MainProgram();
        }
        private static string DetermineAge(DateTime dateOfBirth)
        {
            var now = DateTime.Now;
            if(now.Month < dateOfBirth.Month || (now.Month == dateOfBirth.Month && now.Day < dateOfBirth.Day))
            {
                if (now.Year - dateOfBirth.Year - 1 < 0)
                    return "0";
                else
                return (now.Year - dateOfBirth.Year - 1).ToString();
            }
            else
            {
                return (now.Year - dateOfBirth.Year).ToString();
            }
        }

    }
}