using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTEJA_Lexer_Cv3.ParserRes
{
    public class Divide : BinaryExpression
    {
        public override double Eval(ExecutionContextC executionContextC)
        {
            return Left.Eval(executionContextC) / Right.Eval(executionContextC);
        }
    }
}