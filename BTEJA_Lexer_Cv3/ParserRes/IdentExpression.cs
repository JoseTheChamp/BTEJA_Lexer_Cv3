using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTEJA_Lexer_Cv3.ParserRes
{
    internal class IdentExpression : Expression
    {
        public string Ident { get; set; }

        public override double eval()
        {
            throw new NotImplementedException();
        }
    }
}
