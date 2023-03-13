using System;
using System.Linq;

int playerPengar = 100;
int playerSamla = 0;
int samlaRäknare = 0;
//detta är början av mitt spel då man  får välja att starta spelet eller lämna spelet


int[] arrayHp = new int[3];

string[] choices = { "Start", "Options", "Quit" };

string val = "Start";
while (!choices.Contains(val))
{
    val = Console.ReadLine();

}

if (val == "Start")
{



    // val om du vill samla item, sälja eller köpa
    {
        PrintInstructions(playerSamla, playerPengar);

        val = "";
        while (val != "samla" && val != "köpa" && val != "sälja")
        {
            val = Console.ReadLine();
        }
        Console.WriteLine("_________________________________________________");
        //här kommer man till samla alternativet där man får samla föremål
        while (val == "samla" && samlaRäknare < 10)
        {
            Console.WriteLine($"Du har {playerSamla} items ");
            Console.WriteLine("Vill du leta efter items?");
            // resettar valet så att man kan göra ett nytt, annars körs koden om
            val = "";
            while (val != "ja" && val != "nej")
            {
                val = Console.ReadLine();
            }
            Console.WriteLine("_________________________________________________");
            // om du har samlat mer än 9 gånger så kommer programmet att slänga ut dig ur loopet och du kommer tillbaka till köpa, samla eller sälja.
            if (val == "ja" && samlaRäknare == 9)
            {

                Console.WriteLine("du är för trött för att samla");
            }

            else if (val == "ja")
            {
                Random generator = new Random();
                int r = generator.Next(10);

                playerSamla += r;
                val = "samla";
                samlaRäknare++;
            }
            
    

        }


        //köpa valet
        // här kan du köpa föremål med pengar, koden kommer att informera dig om du inte har råd med att köpa
        if (val == "köpa")
        {


            PrintKöpaVal(playerPengar);

            string whatToBuy = "";
            while (whatToBuy != "1" && whatToBuy != "2" && whatToBuy != "3")
            {
                whatToBuy = Console.ReadLine();
            }

            // Console.WriteLine("_________________________________________________");
            int pricePerItem = 0;

            if (whatToBuy == "1")
            {
                pricePerItem = 10;
            }
            // Console.WriteLine("_________________________________________________");
            else if (whatToBuy == "2")
            {
                pricePerItem = 20;
            }
            // Console.WriteLine("_________________________________________________");
            else if (whatToBuy == "3")
            {
                pricePerItem = 30;
            }
            Console.WriteLine("_________________________________________________");


            Console.WriteLine("Hur många vill du köpa?");
            int numToBuy = 0;
            while (numToBuy == 0)
            Console.WriteLine("_________________________________________________");
            {
                string num = Console.ReadLine();
                bool success = int.TryParse(num, out numToBuy);
                if (success == false)
                {
                    Console.WriteLine("Du måste skriva en siffra!");
                }
            }
            Console.WriteLine("_________________________________________________");

            int finalCost = pricePerItem * numToBuy;

            if (finalCost <= playerPengar)
            {
                Console.WriteLine("Ja, det går bra.");
                playerPengar -= finalCost;
            }
            Console.WriteLine("_________________________________________________");
            else
            {
                Console.WriteLine("Nej, det har du inte råd med!");
            }
            Console.WriteLine("_________________________________________________");
        }

//Sälja valet.
// här kan du sälja de föremål du har sammlat för att få en större summa pengar.
        if (val == "sälja")
        {
            Console.WriteLine("hur många items vill du sälja?");


            int säljaItems = 0;
            while (säljaItems == 0)
            {
                string num = Console.ReadLine();
                bool success = int.TryParse(num, out säljaItems);
                if (success == false)
                {
                    Console.WriteLine("Du måste skriva en siffra!");
                }
                Console.WriteLine("_________________________________________________");
            }


            if (playerSamla <= säljaItems)
            {
                Console.WriteLine("Ja, det går bra.");
                // playerPengar += ;

                Random generator = new Random();
                int p = generator.Next(40);

                playerPengar += säljaItems * p;

                playerSamla -= p;
                val = "samla";
                samlaRäknare--;
            }
            else 
            Console.WriteLine("_________________________________________________");
            {
                Console.WriteLine("Du har inte tillräckligt med items att sälja!");
            }

        }


    }

}



// Metoder jag har skrivit för att förenkla/förkorta koden
static void PrintInstructions(int PlayerNumItems, int playerPengar)
{
    Console.WriteLine("Vill du samla, köpa eller sälja?");
    Console.WriteLine($"Du har {PlayerNumItems} items");
    Console.WriteLine($"Du har {playerPengar} kronor");
}

static void PrintKöpaVal(int playerPengar)
{
    Console.WriteLine($"Du har {playerPengar} kronor kvar");


    Console.WriteLine("Vad vill du köpa?");
    Console.WriteLine("1. En bronsmedalj (10kr)");
    Console.WriteLine("2. En silvermedalj (20kr)");
    Console.WriteLine("3. En guldmedalj (30kr)");
}