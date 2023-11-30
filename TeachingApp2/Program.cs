using TeachingApp2.Extensions;
using TeachingApp2.Uzduotynas;

Uzduotys uzduotys = new Uzduotys();
Uzduotys_11_28 Diena_11_28 = new Uzduotys_11_28();
Uzduotys_11_29 Diena_11_29 = new Uzduotys_11_29();
Uzduotys_11_30 Diena_11_30 = new Uzduotys_11_30();

try
{
    uzduotys.RandomizerInt(10, int.MinValue, int.MaxValue);
    uzduotys.RandomizerString(10, 5, 10);

    Diena_11_30.Uzd6();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    throw;
}



