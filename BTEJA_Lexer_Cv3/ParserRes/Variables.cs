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

        public void Set(string ident, double value, bool? isConstant) {
            foreach (var var in vars)
            {
                if (var.Ident == ident)
                {
                    if (var.IsConstant == false)
                    {
                        Console.WriteLine("Setting " + var.Ident + " to " + value);
                        var.Value = value;
                        return;
                    }
                    else {
                        Console.WriteLine("ELSE-Setting " + var.Ident + " to " + value);
                        throw new Exception("Nemůžete zapisovat do konstanty.");
                    }
                }
            }
            vars.Add(new Variable(ident,value,isConstant));
        }
    }
}
