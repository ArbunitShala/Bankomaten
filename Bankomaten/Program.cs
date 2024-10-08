namespace Bankomaten
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

            accounts[0] = [1100.35m];
            accounts[1] = [13000m, 25300.59m];
            accounts[2] = [33549.77m, 177000, 5600m];
            accounts[3] = [21000, 450000m, 1600m, 9500m];
            accounts[4] = [65000m, 5000000m, 12000.56m, 50000m, 81000.39m];

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
                for(int i = 0; i < accounts[userIndex].Length; i++)
                {
                    Console.WriteLine($"{accountNames[i]}: {accounts[userIndex][i]:C}");
                }

            }


        }
    }
}
