using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTEJA_Lexer_Cv3.ParserRes
{
    public class IfStatement : Statement
    {
        public Statement Statement { get; set; }
        public Condition Cond { get; set; }

        public IfStatement()
        {
        }

        public IfStatement(Statement statement, Condition cond)
        {
            Statement = statement;
            Cond = cond;
        }

        public override void Execute(ExecutionContextC executionContextC)
        {
            if (Cond.Eval(executionContextC) == 1)
            {
                Statement.Execute(executionContextC);
            }
        }
    }
}
