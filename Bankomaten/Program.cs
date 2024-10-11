﻿namespace Bankomaten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //tvådimensionell array som sparar användarna och pinkoderna
            string[,] usersAndPins = new string[5, 2];
            //jagged array som sparar användarnas konton i banken
            decimal[][] accounts = new decimal[5][];
            //array som har namnen på kontorna i banken
            string[] accountNames = ["Lönekonto", "Sparkonto", "Hushåll", "Buffert", "Barnsparkonto"];
            // skapar användarnamn och pinkod
            usersAndPins[0, 0] = "user1";
            usersAndPins[0, 1] = "1111";
            usersAndPins[1, 0] = "user2";
            usersAndPins[1, 1] = "2222";
            usersAndPins[2, 0] = "user3";
            usersAndPins[2, 1] = "3333";
            usersAndPins[3, 0] = "user4";
            usersAndPins[3, 1] = "4444";
            usersAndPins[4, 0] = "user5";
            usersAndPins[4, 1] = "5555";
            // tilldelar värden till varje användares bankonto
            accounts[0] = [1100.35m];
            accounts[1] = [13000.67m, 25300.59m];
            accounts[2] = [33549.77m, 177000.55m, 5600m];
            accounts[3] = [21000.98m, 450000.77m, 1600m, 9500m];
            accounts[4] = [65000.88m, 5000000.19m, 12000.56m, 50000.35m, 81000m];

            Console.WriteLine("Välkomen till bankomaten! ");
            Console.Write("Ange ditt användarnamn: ");
            string userName = Console.ReadLine();

            int userIndex = -1;
            for (int i = 0; i < usersAndPins.GetLength(0); i++)
            {
                if(userName == usersAndPins[i, 0])
                {
                    userIndex = i;
                }
            }
            Console.Write("Ange din pin-kod: ");
            string userPin = Console.ReadLine();

            if (usersAndPins[userIndex,1] == userPin)
            {
                Console.Clear();
                Console.WriteLine("Du är inloggad ");
                Console.WriteLine("[1] Se dina konton och saldo");
                Console.WriteLine("[2] Överföring mellan konton");
                Console.WriteLine("[3] Ta ut pengar");
                Console.WriteLine("[4] Logga ut");
            }
            int menuChoice = Convert.ToInt32(Console.ReadLine());
            switch (menuChoice)
            {
                case 1:
                    // metod för att se konton och saldo
                    showAccountsAndAmount(accountNames, accounts, userIndex);
                    break;
                case 2:
                    //metod för att göra överföring mellan konton
                    break;
                case 3:
                    // metod för att ta ut pengar 
                    break;
                case 4:
                    // logga ut
                    break;
                default:
                Console.WriteLine("Ogiltigt val välj mellan 1-4.");
                    break;
            }
        }
        static void showAccountsAndAmount(string[] accountNames, decimal[][] accounts, int userIndex)
        {
            // loopar igenom alla konton för den valda användaren
            for (int i = 0; i < accounts.Length; i++)
            {
                // skriver ut kontonamnen samt saldo på varje konto
                Console.WriteLine($"{accountNames[i]}: " + $"{accounts[userIndex][i]:C}");
            }
        }
    }
}
