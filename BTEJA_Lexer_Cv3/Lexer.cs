using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTEJA_Lexer_Cv3
{
    class Lexer
    {
        private String vstup;
        private int index = 0;
        private bool konec = false;
        private List<Token> tokens = new List<Token> ();

        private int state;
        /*
         *  1 - read point
         *  2 - read text
         *  3 - Start Reading
         * 
         * 
         */

        private char Next() {
            return vstup[index + 1];
        }
        private char Pop() {
            index++;
            return vstup[index];
        }
        private bool hasNext() {
            if (index<vstup.Length-1) return true;
            return false;
        }

        private List<char> breakPoints = new List<char>(new char[] { '?', '!', ',', ';', '=', ':', '#', '<', '>', '+', '-', '*', '/', '(', ')','.'});
        //private List<char> alphabet = new List<char>("abcdefghijklmnopqrstuvwxyz".ToCharArray());
        public List<Token> Lexicate(String vstup) {
            this.vstup = vstup;

            while (konec != false)
            {
                if (hasNext())
                {
                    char v = Next();
                    if (breakPoints.Contains(v))
                    {
                        ReadPoint();
                    }
                    if (v == ' ')
                    {
                        Pop();
                    }
                    else {
                        ReadText();
                    }
                }
                else
                {
                    konec = true;
                }
            }

            return null;
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
                            case '<':
                                tokens.Add(new Token(Token.TokenType.SmallerOrEq));
                                break;
                            case '>':
                                tokens.Add(new Token(Token.TokenType.GreaterOrEq));
                                break;
                            case ':':
                                tokens.Add(new Token(Token.TokenType.SetEq));
                                break;
                        }
                    }
                    else {
                        switch (v)
                        {
                            case '<':
                                tokens.Add(new Token(Token.TokenType.Smaller));
                                break;
                            case '>':
                                tokens.Add(new Token(Token.TokenType.Greater));
                                break;
                            case ':':
                                tokens.Add(new Token(Token.TokenType.Colon));
                                break;
                        }
                    }
                }
                else
                {
                    konec = true;
                }
            }
            else {
                switch (v)
                {
                    case '?':
                        tokens.Add(new Token(Token.TokenType.Colon));
                        break;
                        //atd
                }
            }
        }

        private void ReadText()
        {
            char v = ' ';
            string s = "";
            while (hasNext() && (!breakPoints.Contains(Next()) && Next() != ' ')) {
                s.Append(Pop());
            }
            if (hasNext()) { 
                konec = true;
            }
            //make token logic
        }
    }
}
