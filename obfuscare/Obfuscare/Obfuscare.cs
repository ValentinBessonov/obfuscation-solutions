using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace obfuscare
{
    public class Obfuscare
    {
        public string[] PerformObfuscation(string[] codeLines)
        {
            // TODO: make async
            for (int i = 0; i < codeLines.Length; i++)
            {
                codeLines[i] = PerformObfuscation(codeLines[i]);
            }

            return codeLines;
        }

        public string PerformObfuscation(string fileBody)
        {
            foreach (var NamesToReplaceName in NamesToReplaceNames)
            {
                string pattern = $@"\b{NamesToReplaceName.Key}\b";
                string target = NamesToReplaceName.Value;
                Regex regex = new Regex(pattern);
                fileBody = regex.Replace(fileBody, target);
            }

            return fileBody;
        }

        public IEnumerable<string> Names { get; }

        public IDictionary<string, string> NamesToReplaceNames { get; }


        public Obfuscare(NamesPickerService namesPickerService)
        {
            NamesToReplaceNames = namesPickerService.NamesToReplaceNames;
        }
    }
}
