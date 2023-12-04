using System.Text;

namespace AsyncConsoleApp
{
    internal class Program
    {
        /*
         * Sukurkite klasę ProgressBar kuri turėtų int lauką progress. Jūsų programėles main metodas turėtų sukurti ProgressBar tipo objektą 
         * ir vykdyti ciklą, kuris didintų progress lauko reikšmę vienetu kas sekundę, tol, kol reikšmė pasiekia 100. 
         * Sukurkite kitą giją, kuri kas 3 sekundes į konsolę išvestų ProgressBar objekto, progress 
         * lauko reikšmę, tol, kol programa veikia.
         */

        /*
Asinchroninis programavimas:
Sukurkite bent 10 failų su tekstų, teksto turėtų būti, bent 100+ žodžių (kuo daugiau failų ir teksto tuo daugiau). 
Tuomet asynchroniškai skaitykite visus failus vienu metu (jeigu pritrūkote resursų, galite skaityti po 4 ar 8 failus vienu metu.
Susikurkite sąrašą ieškomų žodžių. Tuo pačiu metu, kai baigiate skaityti failą (vienu metu išvedinėjame kelis failus)
išveskite naują rezultatų failą (atskiras failas kiekvienam skaitomui failui, pvz MyFile1_Results.txt... MyFile2_Results.txt)
Kuriame bus sąrašas žodžių iš jūsų ieškomų žodžių sąrašo kuriuose radote ir kiek kartų juos radote pvz (Herojus:15,Kompiuteris:4).
Failų formatas gali būti keičiamas jūsų nuožiūra, galima naudoti json.
*/

        static async Task Main(string[] args)
        {
            /*            ProgressBar progressBar = new ProgressBar();

                        progressBar.PrintsProgress();
                        for (int i = 0; i < 100; i++)
                        {
                            var aaa = progressBar.ProgressBarIncrease();
                            await Task.Delay(1000);
                        }
            */
            int fileCount = 50;
            List <FileReaderAsync> fileReaders = new List <FileReaderAsync> ();
            List<string> textToFind = new List<string>()
            {
                "Apple", "Banana", "Computer", "Elephant", "Mountain",
                "Sunshine", "Butterfly", "Universe",
                "Serenity", "Chocolate", "Tranquility", "Moonlight", "Sparkle",
                "Freedom", "Joyful", "Elegant", "Laughter", "Spectacular",
                "Symphony", "Breathtaking", "Refreshing", "Rainbow", "Enchanting",
                "Mystery", "Whimsical", "Lighthouse", "Delicious", "Celebration",
                "Radiant", "Ocean", "Vibrant", "Majestic", "Inspire",
                "Wisdom", "Blissful", "Adventure", "Serendipity", "Effervescent",
                "Tranquil", "Blossom", "Graceful", "Melody", "Journey",
                 "Whisper",  "Pinnacle", "Soothing",
                "Quaint", "Twilight", "Cherish", "Amethyst", "Rejoice",
                "Velvet", "Harmony",  "Felicity",
                "Zenith", "Cascade", "Uplift", "Mellifluous", "Scintillate",
                "Aurora", "Ethereal", "Jubilant", "Piquant", "Enigma",
                "Delight", "Illuminate", "Euphoria", "Cherub", "Radiance",
                "Ponder", "Bountiful", "Luminous", "Resplendent", "Eloquent",
                "Opulent", "Quiescent", "Ineffable", "Grace",
                "Nectar", "Panorama", "Inquisitive", "Lullaby", "Oasis",
                "Cacophony", "Petrichor", "Enchant", "Bliss", "Jubilee",
                "Halcyon", "Enthralling", "Gossamer", "Solace", "Panache"
            };

            for (int i = 0; i < fileCount; i++)
            {
                string path = (i+10).ToString() + ".txt";
                fileReaders.Add(new FileReaderAsync(path,textToFind));
                fileReaders[i].Read();
            }

            bool done = false;
            int count = 0;
            while (!done)
            {
                count = 0;
                done = true;
                foreach (FileReaderAsync reader in fileReaders)
                {
                    if (reader.Busy)
                        done = false;
                    else
                        count++;
                }
                await Task.Delay(100);
            }

            Console.WriteLine("Pabaiga");
            Console.ReadLine();
        }
    }
}
