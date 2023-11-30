/*
Butinai sukurkite du servicus ir Shopitem ir Failu apdorojimui (skaitymas/rasymas ir t.t) Butinai su interface.
 
turi buti igyvendinti sitie metodai servicuose.
 
Item service turi buti listas, kuris egzistuoja visos programos metu ir ji turi buti privatus
 
Programai baigus darba jis isvedamas i faila.
 
programai pradejus darba uzkraunamas is failo
 
1. "Add <itemname> <price>"
2. "Remove <Itemname>" (shop items)
3. "Show balance" -> displays your balance (initial balance is 20 euros)
4. "Topup <money>" -> topup your balance;
5. "Buy <itemname>" -> buys an item if the buyer has enough money.
6. "Display items" -> displays all items that you have bought.
 
Turi visos klaidos buti pagautos.
 
The information should be saved into a file. 
That means when you restart the information does not dissappear.
 
Console messages should be logical
*/

using System.Diagnostics;
using TeachingApp.Interfaces;
using TeachingApp.Models;
using TeachingApp.Services;


ItemBasket shopBasket = new ItemBasket("shop");
ItemBasket myBasket = new ItemBasket("user");


try
{
    shopBasket.LoadItems();
    myBasket.LoadItems();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
}

ShopItem item1 = new ShopItem();
item1.Tags.Add(new ItemTag(1,""));

double moneyBalance = 20.0;
Stopwatch stopwatch = new Stopwatch();

while (true)
{
    Console.WriteLine("1. \"Add <itemname> <price>\"\r\n2. \"Remove <Itemname>\" (shop items)\r\n3. \"Show balance\" -> displays your balance (initial balance is 20 euros)\r\n4. \"Topup <money>\" -> topup your balance;\r\n5. \"Buy <itemname>\" -> buys an item if the buyer has enough money.\r\n6. \"Display items\" -> displays all items that you have bought.");
    Console.WriteLine("7. \"Display shop items\" -> Shows shop items");
    Console.WriteLine("8. \"Exit\" -> save files and exit");
    Console.WriteLine();

    string inputext = Console.ReadLine() ?? "";
    string[] splitText= inputext.Split(" ");

    stopwatch.Start();

    Console.Clear();
    switch (splitText[0])
    {
        case "Add":

            if (splitText.Length != 3)
            {
                BadInput();
                continue;
            }

            if (double.TryParse(splitText[2], out double itemPrice))
                shopBasket.AddItem(splitText[1], itemPrice);
            else
                BadInput();
            
            break;

        case "Remove":
            if (splitText.Length != 2)
            {
                BadInput();
                continue;
            }

            try
            {
                shopBasket.RemoveItem(splitText[1]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);                
            }
            

            break;

        case "Show":

            if (splitText.Length != 2)
            {
                BadInput();
                continue;
            }

            if (splitText[1] == "balance")
            {
                Console.WriteLine($"Your money balance is: {moneyBalance}");
                Console.WriteLine();
            }
            else
            {
                BadInput();
            }
            break;

        case "Topup":
            if (splitText.Length != 2)
            {
                BadInput();
                continue;
            }
            if (double.TryParse(splitText[1], out double topUp))
                moneyBalance += topUp;

            break;

        case "Buy":
            if (splitText.Length != 2)
            {
                BadInput();
                continue;
            }
            try
            {
                ShopItem item = shopBasket.GetItem(splitText[1]);
                if (moneyBalance < item.Price)
                {
                    Console.WriteLine($"Not enough money, top up at least {item.Price - moneyBalance}");
                }
                else
                {
                    moneyBalance -= item.Price;
                    myBasket.AddItem(item.Name, item.Price);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            break;

        case "Display":
            if (splitText.Length != 2 && splitText.Length != 3)
            {
                BadInput();
                continue;
            }

            // show my items
            if (splitText[1] == "items")
            {
                if (splitText.Length != 2)
                {
                    BadInput();
                    continue;
                }
                myBasket.ShowItems();
            }
            // show shop items
            else if (splitText[1] == "shop")
            {
                if (splitText.Length != 3)
                {
                    BadInput();
                    continue;
                }

                if (splitText[2] == "items")
                {
                    shopBasket.ShowItems();
                }
                else
                {
                    BadInput();
                }
            }
            else
            {
                BadInput();
            }
            break;

        case "Exit":
            
            try
            {
                shopBasket.SaveItems();
                myBasket.SaveItems();
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return;

        default:
            BadInput();
            break;
    }

    stopwatch.Stop();

    Console.WriteLine(stopwatch.ElapsedMilliseconds + "ms");
}

void BadInput()
{
    Console.WriteLine("Bad input");
    Console.WriteLine();
}