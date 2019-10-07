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
                var fileBody = FileHelper.GetFileBody(csFilePath);
                var newFileBody = Obfuscare(fileBody);
                FileHelper.SaveFileBody(csFilePath, newFileBody);
            }
        }

        private string Obfuscare(string fileBody) => obfuscare.PerformObfuscation(fileBody);
                
        public ObfuscareService(NamesPickerService namesPickerService)
        {
            obfuscare = new Obfuscare(namesPickerService);
        }
    }
}
