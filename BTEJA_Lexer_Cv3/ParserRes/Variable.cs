using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTEJA_Lexer_Cv3.ParserRes
{
    public class Variable
    {
        public string Ident { get; set; }
        public double Value { get; set; }
        public bool? IsConstant { get; set; }

        public Variable(string ident, double value,bool? isConstant)
        {
            this.Ident = ident;
            this.Value = value;
            this.IsConstant = isConstant;
        }
    }
}
