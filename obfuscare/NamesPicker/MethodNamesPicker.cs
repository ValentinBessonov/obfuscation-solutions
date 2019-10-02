using System.Collections.Generic;
using System.Linq;

namespace obfuscare
{
    public class MethodNamesPicker : NamesPicker
    {
        public override IEnumerable<string> Names { get; }

        public MethodNamesPicker() : base(SolutionElements.Method)
        {
            Names = classes.SelectMany(cl => cl.GetMethods(bindingFlags).Select(method => method.Name));
        }
    }
}
