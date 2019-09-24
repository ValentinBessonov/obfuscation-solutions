using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;

namespace obfuscare
{
    public abstract class NamesPicker
    {
        protected internal const BindingFlags bindingFlags = BindingFlags.Instance
                                                | BindingFlags.Static
                                                | BindingFlags.Public
                                                | BindingFlags.NonPublic 
                                                | BindingFlags.DeclaredOnly;

        protected internal readonly Type[] classes;

        public SolutionElements SolutionElement { get; }

        public abstract IEnumerable<string> GetNames();

        public static NamesPicker Create(SolutionElements solutionElement)
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

        public NamesPicker(SolutionElements solutionElement)
        {
            SolutionElement = solutionElement;
            classes = Assembly.GetExecutingAssembly().GetTypes().Where(c => !c.CustomAttributes.Any(ca => ca.AttributeType.Name.Contains(nameof(CompilerGeneratedAttribute)))).ToArray();
        }
    }
}
