using System;
using System.Collections.Generic;

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
                names.AddRange(cl.GetEnumNames());
            }

            Names = names;
        }
    }
}
