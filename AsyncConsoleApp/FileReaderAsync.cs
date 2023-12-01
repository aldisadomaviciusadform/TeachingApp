using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AsyncConsoleApp
{
    internal class FileReaderAsync
    {
        private string _fileName;
        public bool busy = false;

        public FileReaderAsync(string fileName)
        {
            _fileName = fileName;
        }

        public async Task Read()
        {
            busy = true;
            string allText = File.ReadAllText(_fileName);

            busy = false;
        }

    }
}
