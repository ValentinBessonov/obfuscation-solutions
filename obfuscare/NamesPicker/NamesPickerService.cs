using System;
using System.Collections.Generic;
using System.Linq;

namespace obfuscare
{
    public class NamesPickerService
    {
        private Dictionary<SolutionElements, NamesPicker> NamesPickers { get; }

        public Dictionary<string, string> NamesToReplaceNames{ get; }

        public NamesPicker GetNamesPicker(SolutionElements solutionElement)
        {
            return NamesPickers[solutionElement];
        }

        private NamesPicker Create(SolutionElements solutionElement)
        {
            NamesPicker namesPicker;

            switch (solutionElement)
            {
                case SolutionElements.IClass:
                    namesPicker = new ClassNamesPicker();
                    break;
                case SolutionElements.IMethod:
                    namesPicker = new MethodNamesPicker();
                    break;
                case SolutionElements.IProperty:
                    namesPicker = new PropertyNamesPicker();
                    break;
                case SolutionElements.IField:
                    namesPicker = new FieldNamesPicker();
                    break;
                case SolutionElements.IEnum:
                    namesPicker = new EnumNamesPicker();
                    break;
                default:
                    throw new NotSupportedException();
            }

            return namesPicker;
        }

        private Dictionary<string, string> GetReplaceNames()
        {
            var namesToReplaceNames = new Dictionary<string, string>();

            foreach (var namePicker in NamesPickers.Values)
            {
                foreach (var name in namePicker.Names)
                {
                    if(!namesToReplaceNames.ContainsKey(name))
                    {
                        namesToReplaceNames.Add(name, GetRandomUniqueString(namesToReplaceNames));
                    }                    
                }
            }

            return namesToReplaceNames;
        }

        private string GetRandomUniqueString(Dictionary<string, string> namesToReplaceNames)
        {
            var randomString = Guid.NewGuid().ToString("N").Substring(0, 8);

            if (char.IsDigit(randomString[0]) || namesToReplaceNames.ContainsValue(randomString))
            {
                randomString = GetRandomUniqueString(namesToReplaceNames);
            }

            return randomString;
        }

        public NamesPickerService()
        {            
            NamesPickers = new Dictionary<SolutionElements, NamesPicker>();

            foreach (SolutionElements solutionElements in (SolutionElements[])Enum.GetValues(typeof(SolutionElements)))
            {
                NamesPickers.Add(solutionElements, Create(solutionElements));
            }

            if (FileHelper.TryGetRenameDictionary(out var renameDictionary))
            {
                NamesToReplaceNames = renameDictionary.ToDictionary(x => x.Value, x => x.Key);
                FileHelper.RemoveRenameDictionary();
            }
            else
            {
                NamesToReplaceNames = GetReplaceNames();
                FileHelper.SaveRenameDictionary(NamesToReplaceNames);
            }            
        }
    }
}
