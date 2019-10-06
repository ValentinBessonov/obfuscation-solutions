using System;
using System.Collections.Generic;
using System.Text;

namespace obfuscare
{
    public class ObfuscareClass : Obfuscare
    {
        public ObfuscareClass(NamesPickerService namesPickerService) : base(SolutionElements.Class, namesPickerService)
        {

        }

        public override void PerformObfuscation(string fileCode)
        {
            throw new NotImplementedException();
        }
    }
}
