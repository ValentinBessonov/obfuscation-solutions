using System.Collections.Generic;
using System.IO;
using System.Text;

namespace obfuscare
{
    public static class ObfuscareService
    {
        public static void Obfuscare(IEnumerable<string> csFilePathes)
        {
            // make async
            foreach (var csFilePath in csFilePathes)
            {
                var codeLines = Obfuscare(GetCodeLinesFromFile(csFilePath));
                SaveCodeToFile(csFilePath, codeLines);
            }
        }

        private static string[] Obfuscare(string[] codeLines)
        {
            // sink about
            return codeLines;
        }

        private static string[] GetCodeLinesFromFile(string filePath)
        {
            return File.ReadAllLines(filePath, Encoding.UTF8);
        }

        private static void SaveCodeToFile(string filePath, string[] codeLines)
        {
            File.WriteAllLines(filePath, codeLines);
        }
    }
}
