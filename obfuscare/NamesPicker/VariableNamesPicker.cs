using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace obfuscare
{
    public class VariableNamesPicker : NamesPicker
    {
        public override IEnumerable<string> Names { get; }

        public VariableNamesPicker(IEnumerable<string> csFileBodies) : base(SolutionElements.IVariable)
        {
            var variables = new List<string>();
            foreach (var csFileBody in csFileBodies)
            {
                string pattern = $@"\w[\w|\d]* =";
                Regex regex = new Regex(pattern);
                var mathes = regex.Matches(csFileBody);
                foreach (var math in mathes)
                {
                    variables.Add(math.ToString().Substring(0, math.ToString().IndexOf(' ')));
                }
            }

            Names = variables;
        }
    }
}
