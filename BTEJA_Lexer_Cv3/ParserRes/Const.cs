using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTEJA_Lexer_Cv3.ParserRes
{
    public class Const
    {
        public string ident { get; set; }
        public double value { get; set; }

        public Const(string ident, double value)
        {
            this.ident = ident;
            this.value = value;
        }
    }
}
