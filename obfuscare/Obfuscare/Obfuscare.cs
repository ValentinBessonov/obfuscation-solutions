using System.Collections.Generic;

namespace obfuscare
{
    public abstract class Obfuscare
    {
        public void PerformObfuscation(string[] codeLines)
        {
            // TODO: make async
            foreach (var codeLine in codeLines)
            {
                PerformObfuscation(codeLine);
            }
        }

        public abstract void PerformObfuscation(string codeLine);

        public SolutionElements SolutionElement { get; }
               
        public IEnumerable<string> Names { get; }

        public IDictionary<string, string> NamesToReplaceNames { get; }


        public Obfuscare(SolutionElements solutionElements, NamesPickerService namesPickerService)
        {
            Names = namesPickerService.GetNamesPicker(solutionElements).Names;
            NamesToReplaceNames = namesPickerService.NamesToReplaceNames;
            SolutionElement = solutionElements;
        }
    }
}
