using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using TeachingApp2.Extensions;


namespace TeachingApp2.Uzduotynas
{
    internal class Uzduotys
    {
        public List<int> RandomizerInt(int count, int min, int max)
        {
            List<int> list = new List<int>();
            Random random = new Random();
            for (int i = 0; i < count; i++)
            {
                list.Add(random.Next(min, max));
            }
            return list;
        }

        public List<string> RandomizerString(int count, int min, int max)
        {
            List<string> list = new List<string>();
            Random random = new Random();
            Random random1 = new Random();

            for (int i = 0; i < count; i++)
            {
                List<char> word = new List<char>();
                for (int j = 0; j < random.Next(min, max); j++)
                    word.Add((char)random1.Next(65, 91));

                list.Add(new string(word.ToArray()));
            }
            return list;
        }

        public List<string> RandomizerNormalString(int count)
        {
            List<string> list = new List<string>();

            List<string> texts = new List<string>()
            {
                "Apple", "Banana", "Computer", "Elephant", "Mountain",
                "Sunshine", "Adventure", "Butterfly", "Harmony", "Universe",
                "Serenity", "Chocolate", "Tranquility", "Moonlight", "Sparkle",
                "Freedom", "Joyful", "Elegant", "Laughter", "Spectacular",
                "Symphony", "Breathtaking", "Refreshing", "Rainbow", "Enchanting",
                "Mystery", "Whimsical", "Lighthouse", "Delicious", "Celebration",
                "Radiant", "Ocean", "Vibrant", "Majestic", "Inspire",
                "Wisdom", "Blissful", "Adventure", "Serendipity", "Effervescent",
                "Tranquil", "Blossom", "Graceful", "Melody", "Journey",
                "Harmony", "Whisper", "Cascade", "Pinnacle", "Soothing",
                "Quaint", "Twilight", "Cherish", "Amethyst", "Rejoice",
                "Velvet", "Harmony", "Symphony", "Illuminate", "Felicity",
                "Zenith", "Cascade", "Uplift", "Mellifluous", "Scintillate",
                "Aurora", "Ethereal", "Jubilant", "Piquant", "Enigma",
                "Delight", "Illuminate", "Euphoria", "Cherub", "Radiance",
                "Ponder", "Bountiful", "Luminous", "Resplendent", "Eloquent",
                "Opulent", "Quiescent", "Ineffable", "Tranquility", "Grace",
                "Nectar", "Panorama", "Inquisitive", "Lullaby", "Oasis",
                "Cacophony", "Petrichor", "Enchant", "Bliss", "Jubilee",
                "Halcyon", "Enthralling", "Gossamer", "Solace", "Panache"
            };

            Random random = new Random();

            for (int i = 0; i < count; i++)
            {
                list.Add(texts[random.Next(0, texts.Count)]);
            }
            return list;
        }
    }




}
