using BTEJA_Lexer_Cv3;
using BTEJA_Lexer_Cv3.Parser;
using BTEJA_Lexer_Cv3.ParserRes;

Lexer lexer = new Lexer();
string text = System.IO.File.ReadAllText(@"C:\Projects\C#\BTEJA_Lexer_Cv3\BTEJA_Lexer_Cv3\SourceCodeTest.txt");
List<Token> tokens =  lexer.Lexicate(text);


foreach (Token token in tokens)
{
    if (token.Type == Token.TokenType.Ident || token.Type == Token.TokenType.Number)
    {
        Console.WriteLine("Token:  " + token.Type.ToString() + "  " + token.Value.ToString());
    }
    else {
        Console.WriteLine("Token:  " + token.Type.ToString());
    }
}

Parser parser = new Parser(lexer);
ProgramBlock program = parser.Parse();

Console.WriteLine();
Console.WriteLine("Následuje částečný testovací výpis.");
Console.WriteLine();


Console.WriteLine("Vysledek: " + program);
/*
Console.WriteLine(" Constants:");
foreach (var item in programBlock.Consts)
{
    Console.WriteLine("  " + item.ident + "  " + item.value);
}
Console.WriteLine(" vars:");
foreach (var item in programBlock.Vars)
{
    Console.WriteLine("  " + item.ident);
}
foreach (var procedure in programBlock.Procedures)
{
    Console.WriteLine("Procedure: " + procedure.Ident);
    Console.WriteLine(" Procedure Vars:");
    foreach (var var1 in procedure.Block.Vars)
    {
        Console.WriteLine("  " + var1.ident);
    }
}
*/

Console.WriteLine();
Console.WriteLine("Úspěšně zparsované.");
Console.WriteLine();
program.Execute();
Console.WriteLine("Úspěšně interpretovane.");
Console.WriteLine("--------------------------------------------------.");