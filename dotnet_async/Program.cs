using System;
using System.IO;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;

namespace AsyncPractice
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Console.WriteLine("Iniciando aplicação assíncrona...\n");

            var stopwatch = Stopwatch.StartNew();

            var usuariosTask = BaixarUsuariosAsync();
            var outraCoisaTask = Task.Delay(2000); // Simula outro processo paralelo

            await Task.WhenAll(usuariosTask, outraCoisaTask);

            var usuarios = await usuariosTask;
            var usuariosProcessados = await ProcessarUsuariosAsync(usuarios);
            await SalvarEmArquivoAsync(usuariosProcessados);

            stopwatch.Stop();
            Console.WriteLine($"\nProcesso concluído em {stopwatch.ElapsedMilliseconds / 1000.0:F2} segundos!");
        }

        static async Task<List<string>> BaixarUsuariosAsync()
        {
            Console.WriteLine("Baixando usuários da API...");
            await Task.Delay(3000); // Simula chamada de rede
            return new List<string> { "Roberto", "Luma", "Lucca", "Bela" };
        }

        static async Task<List<string>> ProcessarUsuariosAsync(List<string> usuarios)
        {
            Console.WriteLine("Processando usuários...");
            await Task.Delay(2000); // Simula processamento pesado

            var listaProcessada = new List<string>();
            foreach (var u in usuarios)
                listaProcessada.Add(u.ToUpper());

            return listaProcessada;
        }

        static async Task SalvarEmArquivoAsync(List<string> usuarios)
        {
            Console.WriteLine("Salvando em arquivo...");
            await Task.Delay(1500); // Simula IO de disco

            // Operação de escrita assíncrona real
            await File.WriteAllLinesAsync("usuarios.txt", usuarios);
        }
    }
}
