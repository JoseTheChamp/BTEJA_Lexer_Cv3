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
            programBlock.Block = ReadBlock();
            if (lexer.PeekToken().Type != Token.TokenType.Dot) throw new Exception("Expected . after statements [Parsing]]");
            lexer.ReadToken();
            return programBlock;
        }

        private Block ReadBlock() {
            Block block = new Block();
            if (lexer.PeekToken().Type == Token.TokenType.Const)
            {
                block.AddConsts(ReadConsts());
            }
            if (lexer.PeekToken().Type == Token.TokenType.Var)
            {
                block.AddVars(ReadVars());
            }

            while (lexer.PeekToken() != null && lexer.PeekToken().Type == Token.TokenType.Procedure)
            {
                block.AddProcedure(ReadProcedure());
            }
            block.Statement = ReadStatement();
            return block;
        }

        private Statement ReadStatement()
        {
            Console.WriteLine("ReadStatement: " + lexer.PeekToken().Type);
            switch (lexer.PeekToken().Type)
            {
                case Token.TokenType.Ident: return ReadSetStatement();
                case Token.TokenType.Call: return ReadCallStatement();
                case Token.TokenType.Question: return ReadReadStatement();
                case Token.TokenType.Exclamation: return ReadWriteStatement();
                case Token.TokenType.Begin: return ReadBeginEndStatement();
                case Token.TokenType.If: return ReadIfStatement();
                case Token.TokenType.While: return ReadWhileStatement();
            }
            Console.WriteLine(lexer.PeekToken().Type);
            throw new Exception("Invalid statement token. " + lexer.PeekToken().Type);
            return null;
        }

        private Statement ReadWhileStatement()
        {
            WhileStatement whileStatement = new WhileStatement();
            lexer.ReadToken();
            whileStatement.Cond = ReadCondition();
            if (lexer.PeekToken().Type != Token.TokenType.Do) throw new Exception("Expected do after condition [reading while statement]]");
            lexer.ReadToken();
            whileStatement.Statement = ReadStatement();
            return whileStatement;
        }

        private Statement ReadIfStatement()
        {
            IfStatement ifStatement = new IfStatement();
            lexer.ReadToken();
            ifStatement.Cond = ReadCondition();
            if (lexer.PeekToken().Type != Token.TokenType.Then) throw new Exception("Expected then after condition [reading if statement]]");
            lexer.ReadToken();
            ifStatement.Statement = ReadStatement();
            return ifStatement;
        }

        private Statement ReadBeginEndStatement()
        {
            lexer.ReadToken();
            BeginEndStatement beginEndStatement = new BeginEndStatement();
            beginEndStatement.statements.Add(ReadStatement());
            while (lexer.PeekToken().Type == Token.TokenType.SemiColon)
            {
                lexer.ReadToken();
                beginEndStatement.statements.Add(ReadStatement());

            }
            lexer.ReadToken();
            return beginEndStatement;
        }

        private Statement ReadWriteStatement()
        {
            lexer.ReadToken();
            return new WriteStatement(ReadExpression());
        }

        private Statement ReadReadStatement()
        {
            lexer.ReadToken();
            if (lexer.PeekToken().Type != Token.TokenType.Ident) throw new Exception("Expected IDENT");
            return new ReadStatement(lexer.ReadToken().Value);
        }

        private Statement ReadCallStatement()
        {
            lexer.ReadToken();
            if (lexer.PeekToken().Type != Token.TokenType.Ident) throw new Exception("Expected IDENT");
            return new CallStatement(lexer.ReadToken().Value);
        }

        private Statement ReadSetStatement()
        {
            if (lexer.PeekToken().Type != Token.TokenType.Ident) throw new Exception("Expected IDENT");
            //Console.WriteLine("AT ident: " + lexer.PeekToken().Value);
            var identifier = lexer.ReadToken().Value;
            if (lexer.PeekToken().Type != Token.TokenType.SetEqual) throw new Exception("Expected :=");
            lexer.ReadToken();
            Expression expr = ReadExpression();
            //Console.WriteLine(lexer.PeekToken().Type);
            return new SetStatement(identifier,expr);
        }

        private Procedure ReadProcedure()
        {
            Procedure procedure = new Procedure();
            if (lexer.PeekToken().Type != Token.TokenType.Procedure) throw new Exception("Expected procedure [reading procedures]]");
            lexer.ReadToken();
            if (lexer.PeekToken().Type != Token.TokenType.Ident) throw new Exception("Expected ident after procedure [reading procedures]]");
            procedure.Ident = lexer.ReadToken().Value;
            if (lexer.PeekToken().Type != Token.TokenType.SemiColon) throw new Exception("Expected ; after procedure identifier [reading procedures]]");
            lexer.ReadToken();
            procedure.Block = ReadBlock();
            if (lexer.PeekToken().Type != Token.TokenType.SemiColon) throw new Exception("Expected ; after procedure block [reading procedures]]");
            lexer.ReadToken();
            return procedure;
        }

        private List<Var> ReadVars()
        {
            List<Var> vars = new List<Var>();
            lexer.ReadToken();
            var ident0 = lexer.ReadToken().Value;
            vars.Add(new Var(ident0));
            while (lexer.PeekToken().Type == Token.TokenType.Comma) {
                lexer.ReadToken();
                if (lexer.PeekToken().Type != Token.TokenType.Ident) throw new Exception("Expected ident after , [declaring constants]]");
                var ident = lexer.ReadToken().Value;
                vars.Add(new Var(ident));
            }
            if (lexer.PeekToken().Type != Token.TokenType.SemiColon) throw new Exception("Expected ; [declaring constants]");
            lexer.ReadToken();
            return vars;
        }

        private List<Const> ReadConsts()
        {
            List<Const> consts = new List<Const>();
            lexer.ReadToken();

            var idento = lexer.ReadToken().Value;
            if (lexer.PeekToken().Type != Token.TokenType.Equals) throw new Exception("Expected = [declaring constants].");
            lexer.ReadToken();
            String valueStro = lexer.ReadToken().Value;
            double valueo;
            try
            {
                valueo = Double.Parse(valueStro);
            }
            catch (Exception)
            {
                throw new Exception("Value to be assigned to literal must be a number.");
            }
            consts.Add(new Const(idento, valueo));

            while (lexer.PeekToken().Type == Token.TokenType.Comma)
            {
                lexer.ReadToken();
                if (lexer.PeekToken().Type != Token.TokenType.Ident) throw new Exception("Expected ident after , [declaring constants]]");
                var ident = lexer.ReadToken().Value;
                if (lexer.PeekToken().Type != Token.TokenType.Equals) throw new Exception("Expected = [declaring constants].");
                lexer.ReadToken();
                String valueStr = lexer.ReadToken().Value;
                double value;
                try
                {
                    value = Double.Parse(valueStr);
                }
                catch (Exception)
                {
                    throw new Exception("Value to be assigned to literal must be a number.");
                }
                consts.Add(new Const(ident,value));
            }
            if (lexer.PeekToken().Type != Token.TokenType.SemiColon) throw new Exception("Expected ; [declaring constants]");
            lexer.ReadToken();
            return consts;
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
            Token.TokenType? op = null;
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
            Console.WriteLine("ReadTerm");
            Expression Expr;
            Token.TokenType op;
            Expr = ReadFactor();
            while (lexer.PeekToken() != null && (lexer.PeekToken().Type == Token.TokenType.Multi || lexer.PeekToken().Type == Token.TokenType.Division))
            {
                op = lexer.ReadToken().Type;
                if (op == Token.TokenType.Division)
                {
                    Divide divide = new Divide();
                    divide.Left = Expr;
                    divide.Right = ReadFactor();
                    Expr = divide;

                }
                else if (op == Token.TokenType.Multi)
                {
                    Multiply multiply = new Multiply();
                    multiply.Left = Expr;
                    multiply.Right = ReadFactor();
                    Expr = multiply;
                }
                else
                {
                    throw new Exception("Expected * or /");
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
                if (lexer.PeekToken().Type == Token.TokenType.Ident)
                {
                    Expr = ReadIdentExpression();
                } else if (lexer.PeekToken().Type == Token.TokenType.Number) {
                    Expr = ReadLiteralExpression();
                }
                else {
                    throw new Exception("Read factor unexpected exception.");
                }
                
            }
            return Expr;
        }

        private Expression ReadLiteralExpression()
        {
            LiteralExpression expr = new LiteralExpression();
            expr.NumberLit = Double.Parse(lexer.ReadToken().Value);
            return expr;
        }
        private Expression ReadIdentExpression()
        {
            IdentExpression expr = new IdentExpression();
            expr.Ident = lexer.ReadToken().Value;
            return expr;
        }

    }
}

