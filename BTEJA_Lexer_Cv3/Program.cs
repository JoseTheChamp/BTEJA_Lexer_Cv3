using BTEJA_Lexer_Cv3;





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




