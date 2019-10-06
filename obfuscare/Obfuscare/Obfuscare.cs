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

        public string PerformObfuscation(string codeLine)
        {
            foreach (var NamesToReplaceName in NamesToReplaceNames)
            {
                string pattern = NamesToReplaceName.Key;
                string target = NamesToReplaceName.Value;
                Regex regex = new Regex(pattern);
                codeLine = regex.Replace(codeLine, target);
            }

            return codeLine;
        }

        public IEnumerable<string> Names { get; }

        public IDictionary<string, string> NamesToReplaceNames { get; }


        public Obfuscare(NamesPickerService namesPickerService)
        {
            NamesToReplaceNames = namesPickerService.NamesToReplaceNames;
        }
    }
}
