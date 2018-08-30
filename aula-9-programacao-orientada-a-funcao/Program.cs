using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace aula_9_programacao_orientada_a_funcao
{
    class Program
    {

        public static void LerArquivos(int numero )
        {
            string caminhoArquivo = @"C:\arquivo\arq" + (numero) + ".txt";
            Console.WriteLine("=========== Lendo arquivo ==========\n" + caminhoArquivo + "\n==========================");
            if (File.Exists(caminhoArquivo))
            {
                using (StreamReader arquivo = File.OpenText(caminhoArquivo))
                {
                    string linha;
                    while ((linha = arquivo.ReadLine()) != null)
                    {
                        Console.WriteLine(linha);
                    }
                }
            }

            string caminhoArquivo2 = @"C:\arquivo\arq" + (numero + 1) + ".txt";
            if (File.Exists(caminhoArquivo2))
            {
                LerArquivos(numero + 1);
            }

        }

        public static void Tabuada(int numero)
        {
            Console.WriteLine("Fazendo a tabuada de " + numero + "\n");
            for (int x = 0; x <= 10; x++)
            {
                Console.WriteLine( numero +" X " + x + " = " + (numero*x));
            }
        }

        public static void Media()
        {
            Console.WriteLine("Digite o nome do aluno: ");
            string nome = Console.ReadLine();
            int qtdNotas = 3;
            Console.WriteLine("Digite as " + qtdNotas + " notas do aluno " + nome);

            List<int> notas = new List<int>();
            int totalNotas = 0;
            for (int i = 1; i <= qtdNotas; i++)
            {
                Console.WriteLine("Digite a nota número " + i);
                int nota = int.Parse(Console.ReadLine());
                totalNotas += nota;
                notas.Add(nota);
            }

            int media = totalNotas / notas.Count;
            Console.WriteLine("Mostrando a média do aluno " + nome + " é: " + media);
            Console.WriteLine("Suas notas são: \n");
            
            foreach(int nota in notas)
            {
                Console.WriteLine("Nota: " + nota + "\n");
            }
        }
          
       public static void Menu()
        {
            while (true)
            {
                string mensagem = "Olá usuário, bem vindo ao programa ~~ " +
                    "\nUtilizando programação funcional !" +
                    "\n\n Digite uma das opções abaixo:" +
                    "\n 0 - Sair do programa" +
                    "\n 1 - Ler arquivos" +
                    "\n 2 - Tabuada" +
                    "\n 3 - Calcular média";

                Console.WriteLine(mensagem);

                int valor = int.Parse(Console.ReadLine());

                if (valor == SAIDA_PROGRAMA) break;

                else if (valor == LER_ARQUIVOS)
                {
                    LerArquivos(1);
                    Console.WriteLine("--------------------------------------");
                }

                else if (valor == TABUADA)
                {
                    Console.WriteLine("Digite o número que você quer executar na tabuada :");
                    int numero = int.Parse(Console.ReadLine());
                    Tabuada(numero);
                    Console.WriteLine("--------------------------------------");
                }

                else if (valor == CALCULO_MEDIA)
                {
                    Media();
                    Console.WriteLine("--------------------------------------");
                }

                else
                {
                    Console.WriteLine("Opção inválida, digite novamente !\n");
                    Console.WriteLine("--------------------------------------");
                }

                Console.WriteLine("\n");
            }
        }

        public const int SAIDA_PROGRAMA = 0;
        public const int LER_ARQUIVOS = 1;
        public const int TABUADA = 2;
        public const int CALCULO_MEDIA = 3;

        static void Main(string[] args)
        {
            Menu();
        }
    }
}
