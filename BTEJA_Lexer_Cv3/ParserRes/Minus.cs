using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTEJA_Lexer_Cv3.ParserRes
{
    public class Minus : BinaryExpression
    {
        public override double eval()
        {
            return Left.eval() - Right.eval();
        }
    }
}