using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace obfuscare
{
    public class MethodNamesPicker : NamesPicker
    {
        private const MethodAttributes BadAttributes = MethodAttributes.SpecialName | MethodAttributes.RTSpecialName;
        
        public override IEnumerable<string> Names { get; }

        public MethodNamesPicker() : base(SolutionElements.IMethod)
        {
            List<string> names = classes.SelectMany(cl => cl.GetMethods(bindingFlags))
                .Where(method => !HasAttribute(method.Attributes))
                .Where(method => !method.Name.Contains(".ctor"))
                .Where(method => method.Name != "Main")
                .Select(method => method.Name).ToList();
            Names = names;
        }

        private bool HasAttribute(MethodAttributes attributes)
        {
            return (BadAttributes & attributes) != MethodAttributes.PrivateScope;
        }
    }
}
