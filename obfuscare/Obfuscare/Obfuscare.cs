using System.Collections.Generic;

namespace obfuscare
{
    public abstract class Obfuscare<T> where T: NamesPicker
    {
        public IEnumerable<string> nameForObfuscare { get; set; }
                
        public abstract string PerformObfuscation(string fileCode);

        public Obfuscare(T namePicker)
        {
            nameForObfuscare = namePicker.Names;
        }
    }
}
