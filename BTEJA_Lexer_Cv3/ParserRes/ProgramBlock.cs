using BTEJA_Lexer_Cv3.ParserRes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTEJA_Lexer_Cv3.Parser
{
    public class ProgramBlock
    {
        public Condition Con { get; set; }
        public Expression Ex { get; set; }
    }
}
