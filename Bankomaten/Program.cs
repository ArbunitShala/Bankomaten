namespace Bankomaten
{
    internal class Program
    {
        static string[] users = { "Arbunit", "Petter", "Xhoni", "Hexe", "Krull" };
        static string[]  userPins = { "2004", "1111", "2222", "3333", "4444"};
        static void Main(string[] args)
        {
            Console.WriteLine("Välkomen till bankomaten! ");
            bool run = true;
            int attempts = 0;
            while (attempts < 3)
            {
                Console.Write("Ange ditt användarnamn: ");
                string userName = Console.ReadLine();
                Console.Write("Ange din pin-kod: ");
                string pinCode = Console.ReadLine();
                if ()
                {
                    Console.WriteLine("Inloggning lyckades! Klicka på valfri knapp för att gå vidare.");
                }
                else
                {
                    Console.WriteLine("Fel användarnamn eller Pin-kod. Försök igen.");
                    attempts++;
                }
            }  
        }
    }
}
