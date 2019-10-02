using System;
using System.Collections.Generic;

namespace obfuscare
{
    public static class NamePickerService
    {
        private static Dictionary<SolutionElements, NamesPicker> NamesPickers { get; }

        public static NamesPicker GetNamesPicker(SolutionElements solutionElement)
        {
            return NamesPickers[solutionElement];
        }

        private static NamesPicker Create(SolutionElements solutionElement)
        {
            NamesPicker namesPicker;

            switch (solutionElement)
            {
                case SolutionElements.Class:
                    namesPicker = new ClassNamesPicker();
                    break;
                case SolutionElements.Method:
                    namesPicker = new MethodNamesPicker();
                    break;
                case SolutionElements.Property:
                    namesPicker = new PropertyNamesPicker();
                    break;
                case SolutionElements.Field:
                    namesPicker = new FieldNamesPicker();
                    break;
                case SolutionElements.Enum:
                    namesPicker = new EnumNamesPicker();
                    break;
                default:
                    throw new NotSupportedException();
            }

            return namesPicker;
        }

        static NamePickerService()
        {
            NamesPickers = new Dictionary<SolutionElements, NamesPicker>();
            foreach (SolutionElements solutionElements in (SolutionElements[])Enum.GetValues(typeof(SolutionElements)))
            {
                NamesPickers.Add(solutionElements, Create(solutionElements));
            }
        }
    }
}
