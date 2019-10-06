using System;
using System.Collections.Generic;
using System.Linq;

namespace obfuscare
{
    public class EnumNamesPicker : NamesPicker
    {
        public override IEnumerable<string> Names { get; }

        public EnumNamesPicker() : base(SolutionElements.Enum)
        {
            var names = new List<string>();

            foreach (Type cl in classes)
            {
                if (cl.IsEnum)
                {
                    names.Add(cl.Name);
                }
                
            }

            Names = names;
        }
    }
}
