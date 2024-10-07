void LerArqquivo()
{
    
    string content = File.ReadAllText("arquivo.txt");
    Thread.Sleep(5000);
    Console.WriteLine("Arquivo lido.\n");
    Console.WriteLine(content);
}
Console.WriteLine("Lendo arquivo em uma thread...");
Console.ReadKey();

