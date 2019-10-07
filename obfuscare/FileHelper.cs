using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace obfuscare
{
    public static class FileHelper
    {
        private const string RENAME_DICTIONARY_FILENAME = "RenameDictionary";

        private static readonly string RENAME_DICTIONARY_FILENAME_PATH = Directory.GetCurrentDirectory() + "//" + RENAME_DICTIONARY_FILENAME;

        public static string[] GetCodeLines(string filePath)
        {
            return File.ReadAllLines(filePath, Encoding.UTF8);
        }

        public static void SaveCodeToFile(string filePath, string[] codeLines)
        {
            File.WriteAllLines(filePath, codeLines);
        }

        public static bool TryGetRenameDictionary(out Dictionary<string, string> renameDictionary)
        {            
            if (File.Exists(RENAME_DICTIONARY_FILENAME_PATH))
            {
                string json = File.ReadAllText(RENAME_DICTIONARY_FILENAME_PATH);
                renameDictionary = JsonConvert.DeserializeObject<Dictionary<string, string>>(json);
                return true;
            }

            renameDictionary = null;
            return false;
        }

        public static void SaveRenameDictionary(Dictionary<string, string> renameDictionary)
        {
            string json = JsonConvert.SerializeObject(renameDictionary, Formatting.Indented);
            File.WriteAllText(RENAME_DICTIONARY_FILENAME_PATH, json);
        }

        public static void RemoveRenameDictionary()
        {
            if (File.Exists(RENAME_DICTIONARY_FILENAME_PATH))
            {
                File.Delete(RENAME_DICTIONARY_FILENAME_PATH);
            }            
        }
    }
}
