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

        public BeginEndStatement()
        {
            statements = new List<Statement>();
        }

        public override void Execute(ExecutionContextC executionContextC)
        {
            foreach (var item in statements)
            {
                item.Execute(executionContextC);
            }
        }
    }
}
