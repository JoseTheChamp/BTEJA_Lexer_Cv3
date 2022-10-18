using BTEJA_Lexer_Cv3;
using BTEJA_Lexer_Cv3.Parser;
using BTEJA_Lexer_Cv3.ParserRes;

Lexer lexer = new Lexer();
string text = System.IO.File.ReadAllText(@"C:\Projects\C#\BTEJA_Lexer_Cv3\BTEJA_Lexer_Cv3\SourceCodeTest.txt");
List<Token> tokens =  lexer.Lexicate(text);


foreach (Token token in tokens)
{
    if (token.Type == Token.TokenType.Ident || token.Type == Token.TokenType.NumLit)
    {
        Console.WriteLine("Token:  " + token.Type.ToString() + "  " + token.Value.ToString());
    }
    else {
        Console.WriteLine("Token:  " + token.Type.ToString());
    }
}

Parser parser = new Parser(lexer);
ProgramBlock programBlock = parser.Parse();
Console.WriteLine("Vysledek: " + programBlock.Evaluate());

/*


VAR x, squ;

PROCEDURE square;
BEGIN
   squ:= x * x
END;

BEGIN
   x := 1;
   WHILE x <= 10 DO
   BEGIN
      CALL square;
      ! squ;
      x := x + 1
   END
END.



*/


