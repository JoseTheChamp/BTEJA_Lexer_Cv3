using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTEJA_Lexer_Cv3.ParserRes
{
    public class WhileStatement : Statement
    {
        public Statement Statement { get; set; }
        public Condition Cond { get; set; }

        public override void Execute(ExecutionContextC executionContextC)
        {
            while (Cond.Eval(executionContextC) == 1) {
                //Console.WriteLine("Running");
                Statement.Execute(executionContextC);
            }
        }
    }
}
