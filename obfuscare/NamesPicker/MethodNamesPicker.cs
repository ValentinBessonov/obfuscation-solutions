using System.Collections.Generic;
using System.Linq;

namespace obfuscare
{
    public class MethodNamesPicker : NamesPicker
    {
        public override IEnumerable<string> GetNames() => classes.SelectMany(cl => 
            cl.GetMethods(bindingFlags).Select(method => method.Name));

        public MethodNamesPicker() : base(SolutionElements.Method)
        {
        }
    }
}
