using System;
using System.Collections.Generic;

namespace obfuscare
{
    public class EnumNamesPicker : NamesPicker
    {
        public override IEnumerable<string> GetNames()
        {
            var result = new List<string>();

            foreach (Type cl in classes)
            {
                result.AddRange(cl.GetEnumNames());
            }

            return result.ToArray();
        }

        public EnumNamesPicker() : base(SolutionElements.Enum)
        {
        }
    }
}
