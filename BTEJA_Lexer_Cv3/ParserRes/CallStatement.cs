using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTEJA_Lexer_Cv3.ParserRes
{
    public class CallStatement : Statement
    {
        private String ident;

        public CallStatement(string ident)
        {
            this.ident = ident;
        }

        public override void Execute(ExecutionContextC executionContextC)
        {
            executionContextC.programContext.Call(ident,executionContextC);
        }
    }
}
