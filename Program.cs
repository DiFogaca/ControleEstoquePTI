using System;
using System.Collections.Generic;
using System.Globalization;

namespace ControleEstoquePTI
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu();
        }
        static void Menu()
        {
            Estoque estoque = new Estoque(); //cria um objeto da classe Estoque
            string opcao; //variável que armazena a opção escolhida pelo usuário

            do //repete até que a opção seja zero
            {
                int numTracos = 22; //Definindo a quantidade de traços para as bordas do programa
                string bordaCima = ""; //borda de cima
                string bordaBaixo = ""; //borda de baixo
                for (int i = 0; i < numTracos; i++)
                {
                    bordaCima += "-";
                    bordaBaixo += "_";
                }
                Console.WriteLine($"--- LIVRARIA DOS LIVROS - CONTROLE DE ESTOQUE ---\n{bordaCima}");
                //Apresenta o menu
                Console.WriteLine("[1] Novo              |");
                Console.WriteLine("[2] Listar Produtos   |");
                Console.WriteLine("[3] Remover Produtos  |");
                Console.WriteLine("[4] Entrada Estoque   |");
                Console.WriteLine("[5] Saída Estoque     |");
                Console.WriteLine($"[0] Sair              |\n{bordaBaixo}" + "|");
                Console.Write("Escolha uma opção: ");   //usuário insere a opção desejada
                opcao = Console.ReadLine(); //programa lê a opção digitada
                switch (opcao) //executa a ação de acordo com a opção
                {
                    case "1": //se a opção for 1
                        estoque.Novo(); //chama o método Novo do objeto estoque
                        break;
                    case "2": //se a opção for 2
                        estoque.Listar(); //chama o método Listar do objeto estoque
                        break;
                    case "3": //se a opção for 3
                        estoque.Remover(); //chama o método Remover do objeto estoque
                        break;
                    case "4": //se a opção for 4
                        estoque.Entrada(); //chama o método Entrada do objeto estoque
                        break;
                    case "5": //se a opção for 5
                        estoque.Saida(); //chama o método Saida do objeto estoque
                        break;
                    case "0": //se a opção for 0
                        Console.WriteLine("\nEntão é isso, vou Fechar, Até a próxima!"); //chama o método de Sair do Programa
                        Console.WriteLine("Pressione qualquer tecla para sair...");
                        Console.ReadKey();
                        break;
                    default: //se a opção não for nenhuma das anteriores
                        Console.WriteLine("\nOpção inválida! Por favor, digite um número entre 0 e 5.\n"); //mensagem de aviso para usuário
                        break;
                }
            } while (opcao != "0");
        }
    }
}