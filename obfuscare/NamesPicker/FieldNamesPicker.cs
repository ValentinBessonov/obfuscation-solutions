using System.Collections.Generic;
using System.Linq;

namespace obfuscare
{
    public class FieldNamesPicker : NamesPicker
    {
        public override IEnumerable<string> Names { get; }

        public FieldNamesPicker() : base(SolutionElements.Field)
        {
            Names = classes.SelectMany(cl => cl.GetFields(bindingFlags).Select(m => m.Name));
        }
    }
}
