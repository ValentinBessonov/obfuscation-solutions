using System.IO;
using System.Text;

namespace obfuscare
{
    public static class FileHelper
    {
        public static string[] GetCodeLines(string filePath)
        {
            return File.ReadAllLines(filePath, Encoding.UTF8);
        }

        public static void SaveCodeToFile(string filePath, string[] codeLines)
        {
            File.WriteAllLines(filePath, codeLines);
        }
    }
}
