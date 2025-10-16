using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotnet_async
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Iniciando aplicação...\n");

            var usuarios = BaixarUsuarios();
            var usuariosProcessados = ProcessarUsuarios(usuarios);
            SalvarEmArquivo(usuariosProcessados);

            Console.WriteLine("\nProcesso concluído!");
        }

        static List<string> BaixarUsuarios()
        {
            Console.WriteLine("Baixando usuários da API...");
            Thread.Sleep(3000); // Simula tempo de rede
            return new List<string> { "Roberto", "Luma", "Lucca", "Bela" };
        }

        static List<string> ProcessarUsuarios(List<string> usuarios)
        {
            Console.WriteLine("Processando usuários...");
            Thread.Sleep(2000); // Simula processamento pesado
            var listaProcessada = new List<string>();
            foreach (var u in usuarios)
                listaProcessada.Add(u.ToUpper());
            return listaProcessada;
        }

        static void SalvarEmArquivo(List<string> usuarios)
        {
            Console.WriteLine("Salvando em arquivo...");
            Thread.Sleep(1500); // Simula IO de disco
            File.WriteAllLines("usuarios.txt", usuarios);
        }
    }


}
