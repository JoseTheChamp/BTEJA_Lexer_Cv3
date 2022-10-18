namespace BTEJA_Lexer_Cv3
{
    public class Lexer
    {
        private String vstup;
        private int index = 0;
        private int tokenIndex = 0;
        private bool konec = false;
        private List<Token> tokens = new List<Token>();

        public Token PeekToken() {
            return tokens[tokenIndex];
        }

        public Token ReadToken() { 
            tokenIndex++;
            return tokens[tokenIndex-1];
        }

        private char Next()
        {
            return vstup[index];
        }
        private char Pop()
        {
            index++;
            return vstup[index - 1];
        }
        private bool hasNext()
        {
            if (index <= vstup.Length - 1) return true;
            return false;
        }

        private List<char> breakPoints = new List<char>(new char[] { '?', '!', ',', ';', '=', ':', '#', '<', '>', '+', '-', '*', '/', '(', ')', '.','\n','\r' });
        private List<string> keyWords = new List<string>(new string[] { "ident", "number", "const", "var", "procedure", "call", "begin", "end", "if", "then", "while", "do", "odd" });
        //private List<char> alphabet = new List<char>("abcdefghijklmnopqrstuvwxyz".ToCharArray());
        public List<Token> Lexicate(String vstup)
        {
            this.vstup = vstup;

            while (!konec)
            {
                char v = Next();
                if (breakPoints.Contains(v))
                {
                    ReadPoint();
                }
                else if (v == ' ')
                {
                    Pop();
                }
                else
                {
                    ReadText();
                }
                if (!hasNext())
                {
                    konec = true;
                }
            }
            return tokens;
        }
        private void ReadPoint()
        {
            char v = Pop();
            char v2 = ' ';
            if (v == '<' || v == '>' || v == ':')
            {
                if (hasNext())
                {
                    v2 = Next();
                    if (v2 == '=')
                    {
                        Pop();
                        switch (v)
                        {
                            case '<': tokens.Add(new Token(Token.TokenType.SmallerOrEqual)); break;
                            case '>': tokens.Add(new Token(Token.TokenType.GreaterOrEqual)); break;
                            case ':': tokens.Add(new Token(Token.TokenType.SetEqual)); break;
                        }
                    }
                    else
                    {
                        switch (v)
                        {
                            case '<': tokens.Add(new Token(Token.TokenType.Smaller)); break;
                            case '>': tokens.Add(new Token(Token.TokenType.Greater)); break;
                            case ':': tokens.Add(new Token(Token.TokenType.Colon)); break;
                        }
                    }
                }
                else
                {
                    konec = true;
                }
            }
            else
            {
                switch (v)
                {
                    case '?': tokens.Add(new Token(Token.TokenType.Question)); break;
                    case '!': tokens.Add(new Token(Token.TokenType.Exclamation)); break;
                    case ',': tokens.Add(new Token(Token.TokenType.Comma)); break;
                    case ';': tokens.Add(new Token(Token.TokenType.SemiColon)); break;
                    case '#': tokens.Add(new Token(Token.TokenType.Hash)); break;
                    case '+': tokens.Add(new Token(Token.TokenType.Plus)); break;
                    case '-': tokens.Add(new Token(Token.TokenType.Minus)); break;
                    case '*': tokens.Add(new Token(Token.TokenType.Multi)); break;
                    case '/': tokens.Add(new Token(Token.TokenType.Division)); break;
                    case '(': tokens.Add(new Token(Token.TokenType.LParanthesis)); break;
                    case ')': tokens.Add(new Token(Token.TokenType.LParanthesis)); break;
                    case '.': tokens.Add(new Token(Token.TokenType.Dot)); break;
                    case '=': tokens.Add(new Token(Token.TokenType.Equals)); break;
                    case '\n': break;
                    case '\r': break;

                }
            }
        }

        private void ReadText()
        {
            char v = ' ';
            string s = "";
            string sLower = "";
            while (!breakPoints.Contains(Next()) && Next() != ' ')
            {
                s = s + Pop().ToString();
                if (!hasNext())
                {
                    break;
                }
            }
            sLower = s.ToLower();
            if (keyWords.Contains(sLower))
            {
                switch (sLower)
                {
                    case "number": tokens.Add(new Token(Token.TokenType.Number)); break;
                    case "const": tokens.Add(new Token(Token.TokenType.Const)); break;
                    case "var": tokens.Add(new Token(Token.TokenType.Var)); break;
                    case "procedure": tokens.Add(new Token(Token.TokenType.Procedure)); break;
                    case "call": tokens.Add(new Token(Token.TokenType.Call)); break;
                    case "begin": tokens.Add(new Token(Token.TokenType.Begin)); break;
                    case "end": tokens.Add(new Token(Token.TokenType.End)); break;
                    case "if": tokens.Add(new Token(Token.TokenType.If)); break;
                    case "then": tokens.Add(new Token(Token.TokenType.Then)); break;
                    case "while": tokens.Add(new Token(Token.TokenType.While)); break;
                    case "do": tokens.Add(new Token(Token.TokenType.Do)); break;
                    case "odd": tokens.Add(new Token(Token.TokenType.Odd)); break;
                }
            }
            else
            {
                int num = 0;
                if (Int32.TryParse(s, out num))
                {
                    tokens.Add(new Token(Token.TokenType.NumLit, num.ToString()));
                }
                else if (s != "\n")
                {
                    tokens.Add(new Token(Token.TokenType.Ident, s));
                }
            }
            if (!hasNext())
            {
                konec = true;
            }
        }
    }
}
