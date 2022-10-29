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
        public Block Block { get; set; }

        public void Execute() {
            ExecutionContextC executionContextC = new ExecutionContextC();
            ExecutionContextC globalexecutionContext = new ExecutionContextC();
            List<Variable> vars = new List<Variable>();
            foreach (var con in Block.Consts)
            {
                vars.Add(new Variable(con.ident, con.value, true));
            }
            foreach (var var in Block.Vars) 
            {
                vars.Add(new Variable(var.ident, 0.0, false));
            }
            globalexecutionContext.variables = new Variables(vars);
            executionContextC.variables = new Variables(vars);
            globalexecutionContext.programContext = new ProgramContext(Block.Procedures);
            executionContextC.programContext = new ProgramContext(Block.Procedures);
            executionContextC.GlobalEexecutionContextC = globalexecutionContext;
            /*debug
            Console.WriteLine("//// mainBlock");
            foreach (var var in Block.Vars)
            {
                Console.WriteLine(var.ident);
            }
            Console.WriteLine("///////// orig");
            foreach (var var in executionContextC.GlobalEexecutionContextC.variables.vars)
            {
                Console.WriteLine(var.Ident);
            }
            */
            Block.Statement.Execute(executionContextC);
        }
    }
}
