using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace obfuscare
{
    public static class FileHelper
    {
        private const string RENAME_DICTIONARY_FILENAME = "RenameDictionary";

        private static readonly string RENAME_DICTIONARY_FILENAME_PATH = Directory.GetCurrentDirectory() + "//" + RENAME_DICTIONARY_FILENAME;
        private static string SolutionPath;

        public static string GetFileBody(string filePath)
        {
            return File.ReadAllText(filePath, Encoding.UTF8);
        }

        public static void SaveFileBody(string filePath, string fileBody)
        {
            File.WriteAllText(filePath, fileBody);
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

        public static IEnumerable<string> GetCsFileBodies(IEnumerable<string> filePathes)
        {
            var bodies = new List<string>();

            foreach (var filePath in filePathes)
            {
                bodies.Add(GetFileBody(filePath));
            }

            return bodies;
        }
        public static IEnumerable<string> GetCsFileBodies() => GetCsFileBodies(GetCsFilePathes());

        public static void SetSolutionPath(string[] args)
        {
            if (args.Length > 0 && Directory.Exists(args[0]))
            {
                SolutionPath = args[0];
            }
        }

        public static string GetSolutionPath() => !string.IsNullOrWhiteSpace(SolutionPath) ? SolutionPath : Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

        public static IEnumerable<string> GetCsFilePathes() => GetCsFilePathes(GetSolutionPath());

        static IEnumerable<string> GetCsFilePathes(string solutionPath)
        {
            var csFiles = new List<string>();
            csFiles.AddRange(Directory.GetFiles(solutionPath, "*.cs"));
            var subfolders = Directory.GetDirectories(solutionPath);

            if (subfolders.Any())
            {
                foreach (var subfolder in subfolders)
                {
                    if (subfolder.Contains("bin\\") || subfolder.Contains("obj\\"))
                    {
                        continue;
                    }

                    csFiles.AddRange(GetCsFilePathes(subfolder));
                }
            }

            return csFiles;
        }
    }
}
