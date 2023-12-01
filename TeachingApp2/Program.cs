using TeachingApp2;
using TeachingApp2.Extensions;
using TeachingApp2.Uzduotynas;

Uzduotys uzduotys = new Uzduotys();
Uzduotys_11_28 Diena_11_28 = new Uzduotys_11_28();
Uzduotys_11_29 Diena_11_29 = new Uzduotys_11_29();
Uzduotys_11_30 Diena_11_30 = new Uzduotys_11_30();
Uzduodys_12_01 Diena_12_01 = new Uzduodys_12_01();

try
{
    Diena_12_01.Uzd3GeneratorFiles();
}
catch (Exception e)
{
    Console.WriteLine(e.Message);
    throw;
}



