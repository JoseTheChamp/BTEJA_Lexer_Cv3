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
        private List<char> alphabet = new List<char>("abcdefghijklmnopqrstuvwxyz".ToCharArray());
        public List<Token> Lexicate(String vstup) {
            this.vstup = vstup;

            while (konec != false)
            {
                ReadStart();

            }






            return null;
        }

        private void ReadStart() {
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
                    ReadStart();
                }
                ReadText();
            }
            else {
                konec = true;
            }

        }

        private void ReadPoint()
        {
            throw new NotImplementedException();
        }

        private void ReadText()
        {
            throw new NotImplementedException();
        }
    }
}
