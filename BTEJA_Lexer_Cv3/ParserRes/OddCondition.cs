using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTEJA_Lexer_Cv3.ParserRes
{
    public class OddCondition : Condition
    {
        public Expression Expr { get; set; }

        public override double Eval(ExecutionContextC executionContextC)
        {
            if (Expr.Eval(executionContextC) % 2 == 0)
            {
                return 1;
            }
            return 0;
        }
    }
}
