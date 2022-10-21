using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTEJA_Lexer_Cv3.ParserRes
{
    public class ReadStatement : Statement
    {
        private String ident;

        public ReadStatement(string ident)
        {
            this.ident = ident;
        }
    }
}
