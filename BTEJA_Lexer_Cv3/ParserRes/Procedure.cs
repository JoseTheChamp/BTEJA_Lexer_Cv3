using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTEJA_Lexer_Cv3.ParserRes
{
    public class Procedure
    {
        public string Ident { get; set; }
        public Block Block { get; set; }

        public Procedure()
        {
        }

        public Procedure(string ident, Block block)
        {
            Ident = ident;
            Block = block;
        }
    }
}
