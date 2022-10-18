using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTEJA_Lexer_Cv3.ParserRes
{
    public class ModuloRel : BinaryRelCondition
    {
        public override double eval()
        {
            return Left.eval() % Right.eval();
        }
    }
}
