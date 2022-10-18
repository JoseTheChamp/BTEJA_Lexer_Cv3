using BTEJA_Lexer_Cv3.Parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTEJA_Lexer_Cv3.ParserRes
{
    public class Parser
    {
        private Lexer lexer;
        private List<String> operands = new List<String>() { "=", "#", "<", "<=", ">=", ">" };

        public Parser(Lexer lexer)
        {
            this.lexer = lexer;
        }

        public ProgramBlock Parse()
        {
            ProgramBlock programBlock = new ProgramBlock();
            if (lexer.PeekToken().Type.ToString() == "cond")
            {
                lexer.ReadToken();
                programBlock.Con = ReadCondition();
            }
            else if (lexer.PeekToken().Type.ToString() == "expr")
            {
                lexer.ReadToken();
                programBlock.Ex = ReadExpression();
            }
            else {
                throw new Exception("Expected \"cond\" or \"expr\"");
            }
            return programBlock;
        }

        private Condition ReadCondition() {
            if (lexer.PeekToken().Type.ToString() == "odd")
            {
                return ReadOddCondition();
            }
            else { 
                return ReadBinaryRelCondition();
            }
        }

        private Expression ReadExpression()
        {
            String op = "";
            if (lexer.PeekToken().Type.ToString() == "+" || lexer.PeekToken().Type.ToString() == "-")
            {
                op = lexer.ReadToken().ToString();
            }
            //Expression Ex = ReadTerm();

            return null;
        }

        private OddCondition ReadOddCondition() {
            lexer.ReadToken();
            OddCondition oddCondition = new OddCondition();
            oddCondition.Expr = ReadExpression();
            return oddCondition;
        }

        private BinaryRelCondition ReadBinaryRelCondition() {
            Expression ex1 = ReadExpression();
            String op = lexer.ReadToken().ToString();
            switch (op)
            {
                case "=": 
                    EqualsRel equalsRel = new EqualsRel();
                    equalsRel.Left = ex1;
                    equalsRel.Right = ReadExpression();
                    return equalsRel;
                case "#":
                    ModuloRel moduloRel = new ModuloRel();
                    moduloRel.Left = ex1;
                    moduloRel.Right = ReadExpression();
                    return moduloRel;
                case "<":
                    Lessthanrel lessthanrel = new Lessthanrel();
                    lessthanrel.Left = ex1;
                    lessthanrel.Right = ReadExpression();
                    return lessthanrel;
                case "<=":
                    lessEqRel lessEqRel = new lessEqRel();
                    lessEqRel.Left = ex1;
                    lessEqRel.Right = ReadExpression();
                    return lessEqRel;
                case ">":
                    GreaterThanRel greaterThanRel = new GreaterThanRel();
                    greaterThanRel.Left = ex1;
                    greaterThanRel.Right = ReadExpression();
                    return greaterThanRel;
                case ">=":
                    GreaterEqRel greaterEqRel = new GreaterEqRel();
                    greaterEqRel.Left = ex1;
                    greaterEqRel.Right = ReadExpression();
                    return greaterEqRel;
                default: throw new Exception("Parsing error. Expected = # < <= > >= .");
            }
        }
        /*
        private Term ReadTerm() { 
        
        }*/

    }
}
