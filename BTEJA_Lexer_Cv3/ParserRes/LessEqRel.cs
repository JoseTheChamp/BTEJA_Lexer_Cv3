using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTEJA_Lexer_Cv3.ParserRes
{
    public class lessEqRel : BinaryRelCondition
    {
        public override double eval()
        {
            if (Left.eval() <= Right.eval())
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
