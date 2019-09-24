using System.Collections.Generic;
using System.Linq;

namespace obfuscare
{
    public class FieldNamesPicker : NamesPicker
    {
        public override IEnumerable<string> GetNames() => classes.SelectMany(cl => 
            cl.GetFields(bindingFlags).Select(m => m.Name));

        public FieldNamesPicker() : base(SolutionElements.Field)
        {
        }
    }
}
