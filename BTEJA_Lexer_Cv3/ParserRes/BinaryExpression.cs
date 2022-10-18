using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTEJA_Lexer_Cv3.ParserRes
{
    public abstract class BinaryExpression : Expression
    {
        public Expression Left { get; set; }
        public Expression Right { get; set; }
    }
}
