using System.Collections.Generic;
using System.Linq;

namespace obfuscare
{
    public class PropertyNamesPicker : NamesPicker
    {
        public override IEnumerable<string> Names { get; }

        public PropertyNamesPicker() : base(SolutionElements.Property)
        {
            Names = classes.SelectMany(cl => cl.GetProperties(bindingFlags).Select(m => m.Name));
        }
    }
}
