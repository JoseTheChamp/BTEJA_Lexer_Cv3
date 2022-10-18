using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTEJA_Lexer_Cv3.ParserRes
{
    public class LiteralExpression : Expression
    {
        public double NumberLit { get; set; }

        public override double eval()
        {
            return NumberLit;
        }
    }
}
