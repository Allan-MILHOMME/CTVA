using CGVA.Analysis;
using System.Collections.Generic;

namespace BarelyFunctionnal.Syntax
{
    public interface ValueExpression
    {
        public void Compile(List<Name> currentNames);
        public Closure GetValue(Environment stack);
    }
}
