using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace obfuscare
{
    public class FieldNamesPicker : NamesPicker
    {
        private const FieldAttributes BadAttributes = FieldAttributes.SpecialName | FieldAttributes.RTSpecialName;
        public override IEnumerable<string> Names { get; }

        public FieldNamesPicker() : base(SolutionElements.Field)
        {
            Names = classes.SelectMany(cl => cl.GetFields(bindingFlags))
                .Where(field => !field.Name.Contains("k__BackingField"))
                .Where(field => !HasAttribute(field.Attributes))
                .Select(m => m.Name);            
        }

        private bool HasAttribute(FieldAttributes attributes)
        {
            return (BadAttributes & attributes) != FieldAttributes.PrivateScope;
        }
    }
}

