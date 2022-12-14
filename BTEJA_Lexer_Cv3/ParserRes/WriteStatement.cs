using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTEJA_Lexer_Cv3.ParserRes
{
    public class WriteStatement : Statement
    {
        private Expression expr;

        public WriteStatement(Expression expr)
        {
            this.expr = expr;
        }

        public override void Execute(ExecutionContextC executionContextC)
        {
            Console.WriteLine(expr.Eval(executionContextC).ToString());
        }
    }
}
