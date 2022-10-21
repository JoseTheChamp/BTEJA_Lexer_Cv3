using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTEJA_Lexer_Cv3.ParserRes
{
    public class BeginEndStatement : Statement
    {
        public List<Statement> statements { get; set; }
    }
}
