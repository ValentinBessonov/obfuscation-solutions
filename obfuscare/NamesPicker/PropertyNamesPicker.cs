using System.Collections.Generic;
using System.Linq;

namespace obfuscare
{
    public class PropertyNamesPicker : NamesPicker
    {
        public override IEnumerable<string> GetNames() => classes.SelectMany(cl => 
            cl.GetProperties(bindingFlags).Select(m => m.Name));

        public PropertyNamesPicker() : base(SolutionElements.Property)
        {            
        }
    }
}
