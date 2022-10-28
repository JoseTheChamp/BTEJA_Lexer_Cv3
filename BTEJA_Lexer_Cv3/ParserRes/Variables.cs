using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTEJA_Lexer_Cv3.ParserRes
{
    public class Variables
    {
        public List<Variable> vars;

        public Variables()
        {
            vars = new List<Variable>();
        }

        public Variables(List<Variable> vars)
        {
            this.vars = vars;
        }

        public void AddVariable(Variable variable) {
            foreach (var var in vars)
            {
                if(var.Ident == variable.Ident) {
                    throw new Exception("This variable is already defined. [" + variable.Ident + "].");
                }

            }
            //Console.WriteLine("Adding variable " + variable.Ident);
            vars.Add(variable);
        }

        public double Get(string ident) {

            foreach (var var in vars)
            {
                if (var.Ident == ident)
                {
                    return var.Value;
                }
            }
            throw new Exception("Proměná nebyla definovaná [" + ident + "].");
        }

        public void Set(string ident, double value) {
            foreach (var var in vars)
            {
                if (var.Ident == ident)
                {
                    var.Value = value;
                    return;
                }
            }
            vars.Add(new Variable(ident,value));
        }
    }
}
