using System;
using System.Collections.Generic;

namespace obfuscare
{
    public class EnumNamesPicker : NamesPicker
    {
        public override IEnumerable<string> Names { get; }

        public EnumNamesPicker() : base(SolutionElements.IEnum)
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
