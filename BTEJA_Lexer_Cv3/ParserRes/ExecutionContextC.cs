using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTEJA_Lexer_Cv3.ParserRes
{
    public class ExecutionContextC
    {
        public ProgramContext programContext { get; set; }
        public Variables variables { get; set; }
        public ExecutionContextC GlobalEexecutionContextC { get; set; }
    }
}
