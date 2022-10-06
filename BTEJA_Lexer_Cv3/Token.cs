using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTEJA_Lexer_Cv3
{
    class Token
    {
        public TokenType Type { get; set; }
        public String? Value { get; set; }
        public enum TokenType
        {
            Const,
            Value,
            Eq,
            SemiColon,
            Ident,
            NumLit,
            SmallerOrEq,
            GreaterOrEq,
            SetEq,
            Colon,
            Smaller,
            Greater
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
