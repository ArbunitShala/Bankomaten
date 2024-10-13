using System.Security.Principal;

namespace Bankomaten
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // tvådimensionell array som sparar användarna och pinkoderna
            string[,] usersAndPins = new string[5, 2];
            //jagged array som sparar användarnas konton i banken
            decimal[][] accounts = new decimal[5][];
            // array som har namnen på kontorna i banken
            string[] accountNames = ["1 Lönekonto", "2 Sparkonto", "3 Hushåll", "4 Buffert", "5 Barnsparkonto"];
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
            bool run = true;
            int userIndex = -1;
            while (run)
            {
                Console.Write("Ange ditt användarnamn: ");
                string userName = Console.ReadLine();
                
                // variabel userFound som kontrollerar om användaren hittades
                bool userFound = false;
                for (int i = 0; i < usersAndPins.GetLength(0); i++)
                {
                    if (userName == usersAndPins[i, 0])
                    {
                        userIndex = i;
                        userFound = true;
                        break;
                    }
                }
                if (!userFound)
                {
                    Console.WriteLine("Användaren hittades ej, försök igen.");
                    continue;
                }
                // 3 pinkod försök att logga in
                bool correctPin = false;
                int attempts = 0;

                while(attempts < 3 && !correctPin)
                {
                    Console.Write("Ange din pin-kod: ");
                    string userPin = Console.ReadLine();

                    if (usersAndPins[userIndex, 1] == userPin)
                    {
                        correctPin = true;
                    }
                    else
                    {
                        attempts++;//försök addderas och meddelnade skrivs ut
                        Console.WriteLine($"Du angav fel pinkod. {3 - attempts} försök kvar. ");
                    }
                }
                if (!correctPin)//programmet avslutas om pinkoden är fel vid tredje försöket
                {
                    Console.WriteLine("Programmet avslutas");
                    run = false;
                    break;
                }
                    Console.Clear();//meny
                    Console.WriteLine("Du är inloggad ");
                    Console.WriteLine("[1] Se dina konton och saldo");
                    Console.WriteLine("[2] Överföring mellan konton");
                    Console.WriteLine("[3] Ta ut pengar");
                    Console.WriteLine("[4] Logga ut");

                int menuChoice = Convert.ToInt32(Console.ReadLine());
                switch (menuChoice)
                {
                    case 1:
                        // metod för att se konton och saldo
                        showAccountsAndAmount(accountNames, accounts, userIndex);
                        break;
                    case 2:
                        //metod för att göra överföring mellan konton
                        Console.Write("Välj konto att överföra pengar från: ");
                        int fromAccount = Convert.ToInt32(Console.ReadLine()) -1;//-1 för att indexplatserna börjar på 0
                        Console.Write("Välj ett mottagarkonto: ");
                        int toAccount = Convert.ToInt32(Console.ReadLine()) -1;
                        Console.Write("Ange belopp du vill överföra: ");
                        decimal amount = Convert.ToDecimal(Console.ReadLine());
                        // anropar metoden
                        transferMoney(accounts, userIndex, fromAccount, toAccount, amount);
                        break;
                    case 3:
                        // metod för att ta ut pengar 
                        Console.Write("Välj konto att ta ut pengar från: ");
                        int withdrawFromAccount = Convert.ToInt32(Console.ReadLine()) - 1;//-1 för att få korrekt indexplats
                        Console.Write("Ange belopp du vill ta ut: ");
                        decimal withdrawAmount = Convert.ToDecimal(Console.ReadLine());
                        //anropar metoden
                        withdrawMoney(accounts, userIndex, withdrawFromAccount, withdrawAmount, usersAndPins);
                        break;
                    case 4:
                        // logga ut
                        break;
                    default:
                        Console.WriteLine("Ogiltigt val, välj mellan 1-4.");
                        break;
                }
            }
        }
        static void showAccountsAndAmount(string[] accountNames, decimal[][] accounts, int userIndex)
        {
            // loopar igenom alla konton för den valda användaren
            for (int i = 0; i < accounts[userIndex].Length; i++)
            {
                // skriver ut kontonamnen samt saldo på varje konto
                Console.WriteLine($"{accountNames[i]}: {accounts[userIndex][i]:C}");
            }
        }
        static void transferMoney(decimal[][] accounts, int userIndex,int fromAccount, int toAccount, decimal amount)
        {
            // kontrollerar om indexen är giltiga, får ej vara mindre än 0 eller lika med eller större än längden på konton
            // tex. giltigt index på user4 är mellan 0-3
            if (fromAccount < 0 || fromAccount >= accounts[userIndex].Length || toAccount < 0 || toAccount >= accounts[userIndex].Length)
            {
                Console.WriteLine("Ogiltigt val");// felmeddelande vid ogiltigt val
                return;// metoden avbryts
            }
            // kontrollerar om det finns tillräckligt saldo för att göra överföring på avsändarkontot
            if (accounts[userIndex][fromAccount] < amount)
            {
                Console.WriteLine("Du har för lite saldo på kontot");
                return;
            }
            // överför summan mellan kontorna
            accounts[userIndex][fromAccount] -= amount;
            accounts[userIndex][toAccount] += amount;
            Console.WriteLine("Överföringen är klar!");// nya saldot skrivs ut
            Console.WriteLine($"Nytt avsändarkonto saldo: {accounts[userIndex][fromAccount]:C}");
            Console.WriteLine($"Nytt mottagarkonto saldo: {accounts[userIndex][toAccount]:C}");
        }
        static void withdrawMoney(decimal[][] accounts, int userIndex, int withdrawFromAccount, decimal withdrawAmount, string[,]usersAndPins)
        {
            if (withdrawFromAccount < 0 || withdrawFromAccount >= accounts[userIndex].Length)
            {
                Console.WriteLine("Ogiltigt kontoval");
                return;
            }
            if (accounts[userIndex][withdrawFromAccount] < withdrawAmount)
            {
                Console.WriteLine("För lite saldo på kontot");
                return;
            }
            bool correctPin = false;
            int attempts = 0;
            while (!correctPin)
            {
                Console.Write("Bekräfta med din pin-kod: ");
                string userPin = Console.ReadLine();
                if (usersAndPins[userIndex, 1] == userPin)
                {
                    correctPin = true;
                }
                else
                {
                    attempts++;//försök addderas och meddelnade skrivs ut
                    Console.WriteLine($"Du angav fel pinkod, försök igen ");
                }
            }
            // uttag görs från konto och nya saldot skrivs ut
            accounts[userIndex][withdrawFromAccount] -= withdrawAmount;
            Console.WriteLine("Uttaget lyckades");
            Console.WriteLine($"Uppdaterat saldo: {accounts[userIndex][withdrawFromAccount]:C}");
        }
    }
}
