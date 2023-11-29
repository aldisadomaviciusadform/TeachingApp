
int number;
Console.WriteLine(Uzduotis3("123",out number)+ " " + number.ToString());


/*
Sukurkite programą, kuri priimtų tekstą (eilėraštis arba dainos žodžiai). Tada užklaustų vartotojo kokį žodį norėtų pakeisti į kitą vartotojo paduotą žodį.
Atnaujintą tekstą turėtų išvesti į ekraną.
*/
void Uzduotis1()
{
    string lyrics = Console.ReadLine();
    string inputTextFrom = Console.ReadLine();
    string inputTextTo = Console.ReadLine();

    string[] words = lyrics.Split(" ");

    string newLyrics = string.Empty;

    Console.WriteLine(lyrics.Replace(inputTextFrom, inputTextTo));
}

/*
Sukurkite programą, kuri priima vartotojo įvestą žodį ir patikrina, ar jis yra "labas". Jei taip,
atspausdinkite žodį atbulai naudodami metodą Reverse(). Jei žodis nesutampa su "labas", atspausdinkite žodį taip, kaip jis buvo įvestas.
 */
void Uzduotis2()
{
    string inputText = Console.ReadLine();

    if (inputText == "labas")
    {
        string text = string.Empty;
        var reversed = inputText.Reverse().Select(a=>text+=a);
        Console.WriteLine(reversed.Last());
    }
    else
        Console.WriteLine(inputText);
}

/*
Sukurkite metoda kuris patikrina ar atsiustas tekstas yra skaicius ir grazina skaiciu (kaip int) ir atsakyma ar teisinga
(is esmes sukurkite savo int.TryParse metoda) NEGALIMA NAUDOTI TRYPARSE
*/
bool Uzduotis3(string inputText, out int number)
{
    try
    {
        number = int.Parse(inputText);
        return true;
    }
    catch (Exception)
    {
        number = 0;
        return false;
    }
}