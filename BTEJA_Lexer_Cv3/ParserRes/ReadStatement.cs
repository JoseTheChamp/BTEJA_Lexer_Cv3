using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTEJA_Lexer_Cv3.ParserRes
{
    public class ReadStatement : Statement
    {
        private string ident;

        public ReadStatement(string ident)
        {

            this.ident = ident;
        }

        public override void Execute(ExecutionContextC executionContextC)
        {
            double db = double.Parse(Console.ReadLine().Trim());
            Console.WriteLine("Set " + ident + " to " + db);
            executionContextC.variables.Set(ident,db);
        }
    }
}
