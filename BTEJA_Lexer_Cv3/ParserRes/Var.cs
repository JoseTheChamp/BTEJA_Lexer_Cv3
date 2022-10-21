using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTEJA_Lexer_Cv3.ParserRes
{
    public class Var
    {
        public string ident { get; set; }

        public Var(string ident)
        {
            this.ident = ident;
        }
    }
}
