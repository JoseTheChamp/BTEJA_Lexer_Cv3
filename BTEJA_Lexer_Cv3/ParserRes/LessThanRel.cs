using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTEJA_Lexer_Cv3.ParserRes
{
    public class Lessthanrel : BinaryRelCondition
    {
        public override double Eval(ExecutionContextC executionContextC)
        {
            if (Left.Eval(executionContextC) < Right.Eval(executionContextC))
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
