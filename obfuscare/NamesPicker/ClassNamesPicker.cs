using System.Collections.Generic;
using System.Linq;

namespace obfuscare
{
    public class ClassNamesPicker : NamesPicker
    {
        public override IEnumerable<string> GetNames() => classes.Select(cl => cl.Name);

        public ClassNamesPicker() : base(SolutionElements.Class)
        {
        }
    }
}
