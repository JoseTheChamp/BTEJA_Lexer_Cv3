using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTEJA_Lexer_Cv3.ParserRes
{
    public class ProgramContext
    {
        public List<Procedure> procedures;

        public ProgramContext()
        {
            procedures = new List<Procedure>();
        }

        public ProgramContext(List<Procedure> procedures)
        {
            this.procedures = procedures;
        }

        public void AddProcedure(Procedure procedure) {
            foreach (var proc in procedures)
            {
                if (proc.Ident == procedure.Ident)
                {
                    throw new Exception("This procedure is already defined. [" + procedure.Ident + "].");
                }

            }
            procedures.Add(procedure);
        }

        public void Call(String proc, ExecutionContextC executionContextC) {
            foreach (Procedure procedure in procedures) {
                if (procedure.Ident == proc)
                {
                    procedure.Execute(executionContextC);
                    return;
                }
            }
            throw new Exception("This method was not defined. [" + proc + "]");
        }
    }
}
