using BTEJA_Lexer_Cv3;





Lexer lexer = new Lexer();
List<Token> tokens =  lexer.Lexicate("Const Sto = 100;\n Begin\n CALL internalFunc;\n!Sto +1000 ;");


foreach (Token token in tokens)
{
    if (token.Type == Token.TokenType.Ident || token.Type == Token.TokenType.NumLit)
    {
        Console.WriteLine("Token:  " + token.Type.ToString() + "  " + token.Value.ToString() + "");
        if (token.Value == null || token.Value == "\n")
        {
            Console.WriteLine("AAAAAAAAAAAAAAAAA");
        }
    }
    else {
        Console.WriteLine("Token:  " + token.Type.ToString());
    }
}

