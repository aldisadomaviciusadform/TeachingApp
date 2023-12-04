using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace AsyncConsoleApp
{
    internal class FileReaderAsync
    {
        private string _name;
        private string _fileName;
        private string _fileResult;
        public bool Busy = false;
        List<string> _texts = new List<string>();

        public FileReaderAsync(string fileName, List<string> texts)
        {
            _name = fileName;
            _fileName = "C:\\Users\\Aldis\\source\\repos\\TeachingApp\\TeachingApp2\\bin\\Debug\\net8.0\\" + fileName;
            _fileResult = "C:\\Users\\Aldis\\source\\repos\\TeachingApp\\TeachingApp2\\bin\\Debug\\net8.0\\Result_" + fileName;
            _texts = texts;
        }

        public void SaveItems<T>(IEnumerable<T> items, string fileName)
        {
            List<string> text = new List<string>();
            foreach (T item in items)
            {
                string jsonString = JsonSerializer.Serialize<T>(item);
                text.Add(jsonString);
            }
            File.WriteAllLines(fileName, text);
        }

        public async Task Read()
        {
            try
            {
                Busy = true;

                if (!File.Exists(_fileName))
                    return;

                string allText = await File.ReadAllTextAsync(_fileName);

                Dictionary<string, int> dictionary = new Dictionary<string, int>();
                foreach (string text in _texts)
                {
                    dictionary.Add(text, 0);
                }

                foreach (string text in allText.Split(" "))
                {
                    if (dictionary.ContainsKey(text))
                        dictionary[text]++;
                }

                SaveItems(dictionary, _fileResult);

                await Console.Out.WriteLineAsync(_name + " done");
                Busy = false;
            }
            catch (Exception e)
            {
                await Console.Out.WriteLineAsync(_name + " crashed " + e.Message);
            }
        }
    }
}
