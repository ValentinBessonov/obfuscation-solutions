using System.Collections.Generic;

namespace obfuscare
{
    public class ObfuscareService
    {
        private readonly IEnumerable<Obfuscare> obfuscares = new List<Obfuscare>
        {
        };

        private readonly IDictionary<string, string> namesToReplaceNames;

        public void Obfuscare(IEnumerable<string> csFilePathes)
        {
            // TODO: make async
            foreach (var csFilePath in csFilePathes)
            {
                var codeLines = Obfuscare(FileHelper.GetCodeLines(csFilePath));
                FileHelper.SaveCodeToFile(csFilePath, codeLines);
            }
        }

        private string[] Obfuscare(string[] codeLines)
        {
            foreach (var obfuscare in obfuscares)
            {
                obfuscare.PerformObfuscation(codeLines);
            }

            return codeLines;
        }
                
        public ObfuscareService(NamesPickerService namesPickerService)
        {
            this.namesToReplaceNames = namesPickerService.NamesToReplaceNames;

            this.obfuscares = new List<Obfuscare>
            {
                new ObfuscareClass(namesPickerService),
            };
        }
    }
}
