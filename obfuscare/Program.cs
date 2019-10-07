using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace obfuscare
{
    class Program
    {
        static void Main(string[] args)
        {
            FileHelper.SetSolutionPath(args);

            var namesPickerService = new NamesPickerService();
            var obfuscareService = new ObfuscareService(namesPickerService);

            obfuscareService.Obfuscare(FileHelper.GetCsFilePathes());
            Console.WriteLine("Done");
            Console.ReadLine();            
        }       
    }
}
