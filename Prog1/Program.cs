using System;

int playerMoney = 100;
int playersamla = 0;
int samlacounter = 0;
while (playerMoney > 0)
{
    Console.WriteLine("Vill du samla, köpa eller sälja?");
    Console.WriteLine($"Du har {playersamla} items");
    Console.WriteLine($"Du har {playerMoney} kronor");

    string val = "";
    while (val != "samla" && val != "köpa")
    {
        val = Console.ReadLine();
    }


    while (val == "samla" && samlacounter < 10)
    {
        Console.WriteLine($"Du har {playersamla} items ");
        Console.WriteLine("Vill du leta efter items?");

        val = ""; 
        while (val != "ja" && val != "nej")
        {
            val = Console.ReadLine();
        }

        if (val == "ja" && samlacounter == 9)
        {
         
         Console.WriteLine("du är för trött för att samla");
        }
        
        else if(val == "ja")
        {
         Random generator = new Random();
         int r = generator.Next(10);

          playersamla += r;
          val = "samla";
          samlacounter++;
        }
       




    }
    
    

    if (val == "köpa")
    {


        Console.WriteLine($"Du har {playerMoney} kronor kvar");


        Console.WriteLine("Vad vill du köpa?");
        Console.WriteLine("1. En bronsmedalj (10kr)");
        Console.WriteLine("2. En silvermedalj (20kr)");
        Console.WriteLine("3. En guldmedalj (30kr)");

        string whatToBuy = "";
        while (whatToBuy != "1" && whatToBuy != "2" && whatToBuy != "3")
        {
            whatToBuy = Console.ReadLine();
        }


        int pricePerItem = 0;

        if (whatToBuy == "1")
        {
            pricePerItem = 10;
        }
        else if (whatToBuy == "2")
        {
            pricePerItem = 20;
        }
        else if (whatToBuy == "3")
        {
            pricePerItem = 30;
        }


        Console.WriteLine("Hur många vill du köpa?");
        int numToBuy = 0;
        while (numToBuy == 0)
        {
            string num = Console.ReadLine();
            bool success = int.TryParse(num, out numToBuy);
            if (success == false)
            {
                Console.WriteLine("Du måste skriva en siffra!");
            }
        }

        int finalCost = pricePerItem * numToBuy;

        if (finalCost <= playerMoney)
        {
            Console.WriteLine("Ja, det går bra.");
            playerMoney -= finalCost;
        }
        else
        {
            Console.WriteLine("Nej, det har du inte råd med!");
        }
    }

}





