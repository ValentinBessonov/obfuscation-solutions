using System.Collections.Generic;
using System.Linq;

namespace obfuscare
{
    public class ClassNamesPicker : NamesPicker
    {
        public override IEnumerable<string> Names { get; }

        public ClassNamesPicker() : base(SolutionElements.Class)
        {
            Names = classes.Select(cl => cl.Name);
        }
    }
}
