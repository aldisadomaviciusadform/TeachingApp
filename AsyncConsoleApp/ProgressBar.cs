using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncConsoleApp
{
    internal class ProgressBar
    {
        private int progress=0;
        public async Task ProgressBarIncrease()
        {
            progress += 1;
        }

        public async Task PrintsProgress()
        {
            while (progress < 100) 
            {
                Console.WriteLine(progress);
                await Task.Delay(3000);
            }
            
        }
    }
}
