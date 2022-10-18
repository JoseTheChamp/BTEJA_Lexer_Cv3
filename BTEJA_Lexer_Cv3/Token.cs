using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTEJA_Lexer_Cv3
{
    public class Token
    {
        public TokenType Type { get; set; }
        public String? Value { get; set; }
        public enum TokenType
        {
            Const,
            Value,
            Equals,
            SemiColon,
            Ident,
            NumLit,
            SmallerOrEqual,
            GreaterOrEqual,
            SetEqual,
            Colon,
            Smaller,
            Greater,
            Question,
            Exclamation,
            Comma,
            Hash,
            Plus,
            Minus,
            Multi,
            Division,
            LParanthesis,
            RParanthesis,
            Dot,
            Number,
            Var,
            Procedure,
            Call,
            Begin,
            End,
            While,
            Do,
            Odd,
            If,
            Then
        }

        public Token(TokenType type)
        {
            Type = type;
        }

        public Token(TokenType Type, string value) : this(Type)
        {
            Value = value;
        }
    }
}
