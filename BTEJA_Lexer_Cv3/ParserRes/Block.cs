using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTEJA_Lexer_Cv3.ParserRes
{
    public class Block
    {
        public Statement Statement { get; set; }
        public List<Const> Consts { get; set; }
        public List<Var> Vars { get; set; }
        public List<Procedure> Procedures { get; set; }

        public Block()
        {
            Procedures = new List<Procedure>();
        }

        public void AddConsts(List<Const> consts)
        {
            this.Consts = consts;
        }

        public void AddVars(List<Var> vars)
        {
            this.Vars = vars;
        }

        public void AddProcedure(Procedure procedure)
        {
            Procedures.Add(procedure);
        }
    }
}
