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
            if (lexer.PeekToken().Type == Token.TokenType.Cond)
            {
                lexer.ReadToken();
                programBlock.Con = ReadCondition();
            }
            else if (lexer.PeekToken().Type == Token.TokenType.Expr)
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
            if (lexer.PeekToken().Type == Token.TokenType.Odd)
            {
                return ReadOddCondition();
            }
            else { 
                return ReadBinaryRelCondition();
            }
        }

        private Expression ReadExpression()
        {
            Expression Expr;
            Token.TokenType op = Token.TokenType.Begin;
            if (lexer.PeekToken().Type == Token.TokenType.Plus || lexer.PeekToken().Type == Token.TokenType.Minus)
            {
                op = lexer.ReadToken().Type;
            }
            if (op == Token.TokenType.Minus)
            {
                MinusUnary minusUnary = new MinusUnary();
                minusUnary.Expr = ReadTerm();
                Expr = minusUnary;
            } else if (op == Token.TokenType.Plus) {
                PlusUnary plusUnary = new PlusUnary();
                plusUnary.Expr = ReadTerm();
                Expr = plusUnary;
            }
            else {
                Expr = ReadTerm();
            }

            while (lexer.PeekToken() != null && (lexer.PeekToken().Type == Token.TokenType.Plus || lexer.PeekToken().Type == Token.TokenType.Minus)) { 
                op = lexer.ReadToken().Type;
                if (op == Token.TokenType.Minus)
                {
                    Minus minus = new Minus();
                    minus.Left = Expr;
                    minus.Right = ReadTerm();
                    Expr = minus;
                }
                else{
                    Plus plus = new Plus();
                    plus.Left = Expr;
                    plus.Right = ReadTerm();
                    Expr = plus;
                }
            }
            return Expr;
        }

        private OddCondition ReadOddCondition() {
            lexer.ReadToken();
            OddCondition oddCondition = new OddCondition();
            oddCondition.Expr = ReadExpression();
            return oddCondition;
        }

        private BinaryRelCondition ReadBinaryRelCondition() {
            Expression ex1 = ReadExpression();
            Token.TokenType op = lexer.ReadToken().Type;
            switch (op)
            {
                case Token.TokenType.Equals: 
                    EqualsRel equalsRel = new EqualsRel();
                    equalsRel.Left = ex1;
                    equalsRel.Right = ReadExpression();
                    return equalsRel;
                case Token.TokenType.Hash:
                    ModuloRel moduloRel = new ModuloRel();
                    moduloRel.Left = ex1;
                    moduloRel.Right = ReadExpression();
                    return moduloRel;
                case Token.TokenType.Smaller:
                    Lessthanrel lessthanrel = new Lessthanrel();
                    lessthanrel.Left = ex1;
                    lessthanrel.Right = ReadExpression();
                    return lessthanrel;
                case Token.TokenType.SmallerOrEqual:
                    lessEqRel lessEqRel = new lessEqRel();
                    lessEqRel.Left = ex1;
                    lessEqRel.Right = ReadExpression();
                    return lessEqRel;
                case Token.TokenType.Greater:
                    GreaterThanRel greaterThanRel = new GreaterThanRel();
                    greaterThanRel.Left = ex1;
                    greaterThanRel.Right = ReadExpression();
                    return greaterThanRel;
                case Token.TokenType.GreaterOrEqual:
                    GreaterEqRel greaterEqRel = new GreaterEqRel();
                    greaterEqRel.Left = ex1;
                    greaterEqRel.Right = ReadExpression();
                    return greaterEqRel;
                default: throw new Exception("Parsing error. Expected = # < <= > >= .");
            }
        }
        
        private Expression ReadTerm() {
            Expression Expr;
            String op = "";
            Expr = ReadFactor();
            while (lexer.PeekToken() != null && (lexer.PeekToken().Type == Token.TokenType.Multi || lexer.PeekToken().Type == Token.TokenType.Division))
            {
                op = lexer.ReadToken().ToString();
                if (op == "/")
                {
                    Divide divide = new Divide();
                    divide.Left = Expr;
                    divide.Right = ReadFactor();
                    Expr = divide;
                }
                else
                {
                    Multiply multiply = new Multiply();
                    multiply.Left = Expr;
                    multiply.Right = ReadFactor();
                    Expr = multiply;
                }
            }
            return Expr;
        }

        private Expression ReadFactor()
        {
            Expression Expr;
            if (lexer.PeekToken().Type == Token.TokenType.LParanthesis)
            {
                lexer.ReadToken();
                Expr = ReadExpression();
                lexer.ReadToken();
            }
            else { 
                Expr = ReadLiteralExpression();
            }
            return Expr;
        }

        private Expression ReadLiteralExpression()
        {
            LiteralExpression expr = new LiteralExpression();
            expr.NumberLit = Double.Parse(lexer.ReadToken().Value);
            return expr;
        }

    }
}

