using System.Collections.Generic;

namespace obfuscare
{
    public class ObfuscareService
    {
        private readonly Obfuscare obfuscare;

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
            obfuscare.PerformObfuscation(codeLines);
            return codeLines;
        }
                
        public ObfuscareService(NamesPickerService namesPickerService)
        {
            this.obfuscare = new Obfuscare(namesPickerService);
        }
    }
}
