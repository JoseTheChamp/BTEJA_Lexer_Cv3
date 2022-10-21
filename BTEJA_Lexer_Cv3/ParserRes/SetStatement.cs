using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTEJA_Lexer_Cv3.ParserRes
{
    public class SetStatement : Statement
    {
        private String ident;
        private Expression expr;

        public SetStatement(string ident, Expression expr)
        {
            this.ident = ident;
            this.expr = expr;
        }
    }
}
