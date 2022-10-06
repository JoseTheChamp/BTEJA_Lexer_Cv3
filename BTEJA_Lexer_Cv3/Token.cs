using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTEJA_Lexer_Cv3
{
    class Token
    {
        public TokenTypeEnum TokenType { get; set; }
        public String? Value { get; set; }
        public enum TokenTypeEnum
        {
            Const,
            Value,
            Eq,
            Semicolon,
            ident,
            num_lit
        }

        public Token(TokenTypeEnum tokenType)
        {
            TokenType = tokenType;
        }

        public Token(TokenTypeEnum tokenType, string value) : this(tokenType)
        {
            Value = value;
        }
    }
}
