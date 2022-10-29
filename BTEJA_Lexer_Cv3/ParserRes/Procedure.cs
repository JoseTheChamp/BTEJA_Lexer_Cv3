using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTEJA_Lexer_Cv3.ParserRes
{
    public class Procedure
    {
        public string Ident { get; set; }
        public Block Block { get; set; }

        public Procedure()
        {
        }

        public Procedure(string ident, Block block)
        {
            Ident = ident;
            Block = block;
        }

        public void Execute(ExecutionContextC executionContextC) { 
            ExecutionContextC executionContextC1 = new ExecutionContextC();
            executionContextC1.GlobalEexecutionContextC = executionContextC.GlobalEexecutionContextC;
            executionContextC1.variables = new Variables();
            executionContextC1.programContext = new ProgramContext();
            /*Console.WriteLine("Executing: " + Ident);
            foreach (var var in Block.Vars)
            {
                Console.WriteLine(var.ident);
            }*/
            foreach (var var in executionContextC.GlobalEexecutionContextC.variables.vars)
            {
                executionContextC1.variables.AddVariable(var);
            }
            foreach (var proc in executionContextC.GlobalEexecutionContextC.programContext.procedures)
            {
                executionContextC1.programContext.AddProcedure(proc);
            }
            foreach (var var in Block.Vars)
            {
                executionContextC1.variables.AddVariable(new Variable(var.ident,0,false));
            }
            foreach (var con in Block.Consts)
            {
                executionContextC1.variables.AddVariable(new Variable(con.ident, con.value, true));
            }
            foreach (var proc in Block.Procedures)
            {
                executionContextC1.programContext.AddProcedure(proc);
            }
            /*
            Console.WriteLine("//// proc: " + Ident);
            foreach (var var in Block.Vars)
            {
                Console.WriteLine(var.ident);
            }
            Console.WriteLine("/////////// orig");
            foreach (var var in executionContextC.GlobalEexecutionContextC.variables.vars)
            {
                Console.WriteLine(var.Ident);
            }
            */
            //Console.WriteLine("Executing function: " + Ident);
            Block.Statement.Execute(executionContextC1);
        }
    }
}
