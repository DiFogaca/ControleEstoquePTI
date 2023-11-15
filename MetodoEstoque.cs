using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ControleEstoquePTI.Program;

namespace ControleEstoquePTI
{
    internal class Estoque
    {
        private List<Livro> produtos; //Atributo que armazena os produtos em uma lista      
        public Estoque() //Construtor da classe
        {
            this.produtos = new List<Livro>(); //inicia a lista vazia
        }
        public void Novo() //Método que adiciona um novo produto à lista
        {
            Console.WriteLine("\nDigite as informações do novo produto: \n");
            Console.Write("Título: ");
            string titulo = Console.ReadLine();
            Console.Write("Autor(a): ");
            string autor = Console.ReadLine();
            Console.Write("Editora: ");
            string editora = Console.ReadLine();
            Console.Write("Gênero: ");
            string genero = Console.ReadLine();

            double preco = 0; //inicializa a variável estoque com um valor padrão
            bool precoValido = false;
            while (!precoValido)
            {
                Console.Write("Preço: ");
                precoValido = double.TryParse(Console.ReadLine(), out preco);
                if (!precoValido)
                {
                    Console.WriteLine("Valor inválido. Tente novamente.");
                }
            }

            int estoque = 0; //inicializa a variável estoque com um valor padrão
            bool estoqueValido = false;
            while (!estoqueValido)
            {
                Console.Write("Estoque: ");
                estoqueValido = int.TryParse(Console.ReadLine(), out estoque);
                if (!estoqueValido)
                {
                    Console.WriteLine("Valor inválido. Tente novamente.");
                }
            }
            Livro livro = new Livro($"{titulo}", $"{autor}", $"{editora}", $"{genero}", preco, estoque); //cria um objeto da classe Livro
            this.produtos.Add(livro); //adiciona o objeto à lista
            Console.WriteLine("\nProduto cadastrado com sucesso!\n");
        }
        public void Listar()
        {
            if (this.produtos.Count == 0)
            {
                Console.WriteLine("\nNão há produtos cadastrados.\n");
            }
            else
            {
                Console.WriteLine($"\nProdutos cadastrados: {this.produtos.Count}\n");

                // Adicionando um contador
                int contador = 1;

                foreach (Livro livro in this.produtos)
                {
                    Console.WriteLine($"{contador}. {livro}\n");
                    contador++;
                }
            }
        }
        public void Remover() //Método que remove um produto da lista
        {
            bool encontrado = false; // variável que indica se o produto foi encontrado
            while (!encontrado)
            {
                Console.Write("\nDigite o título do produto que deseja remover: \n");
                string titulo = Console.ReadLine();
                foreach (Livro livro in this.produtos) //percorre a lista
                {
                    if (livro.Titulo == titulo) //compara o título do produto com o título digitado
                    {
                        this.produtos.Remove(livro); //remove o produto da lista
                        encontrado = true;
                        Console.WriteLine("\nProduto removido com sucesso!\n");
                        return;
                    }
                }
                if (this.produtos.Count == 0) //se o produto não foi encontrado
                {
                    Console.WriteLine("\nNenhum Produto Cadastrado com esse título.\n");
                    Console.WriteLine("Por favor tente novamente.\n________________________________");
                    return;
                }
                else
                {
                    Listar();
                }
            }
        }
        public void Entrada() //Método que realiza uma entrada de estoque de um produto
        {
            bool encontrado = false; //variável que indica se o produto foi encontrado
            while (!encontrado)
            {
                Console.Write("\nDigite o título do produto que deseja dar entrada: \n");
                string titulo = Console.ReadLine();
                foreach (Livro livro in this.produtos) //percorre a lista
                {
                    if (livro.GetTitulo() == titulo) //compara o título do produto com o título digitado
                    {
                        Console.Write("\nDigite a quantidade que deseja adicionar ao estoque: \n");
                        int quantidade;
                        while (!Int32.TryParse(Console.ReadLine(), out quantidade)) //valida a entrada do usuário
                        {
                            Console.WriteLine("\nEntrada inválida! Digite um número de quantidade válido.\n");
                            Console.Write("\nDigite a quantidade que deseja adicionar ao estoque: \n");
                        }
                        livro.SetEstoque(livro.GetEstoque() + quantidade); //atualiza o estoque do produto
                        encontrado = true;
                        Console.WriteLine("\nEntrada de estoque realizada com sucesso!\n");
                        return;
                    }
                }
                if (this.produtos.Count == 0) //se o produto não foi encontrado
                {
                    Console.WriteLine("\nNenhum Produto Cadastrado com esse título.\n");
                    Console.WriteLine("Por favor verifique o estoque.\n________________________________");
                    return;
                }
                else
                {
                    Listar();
                }
            }
        }
        public void Saida() //Método que realiza uma saída de estoque de um produto
        {
            bool encontrado = false; //variável que indica se o produto foi encontrado
            while (!encontrado) 
            {
                Console.Write("\nDigite o título do produto que deseja dar saída: \n");
                string titulo = Console.ReadLine();
                foreach (Livro livro in this.produtos) //percorre a lista
                {
                    if (livro.GetTitulo() == titulo) //compara o título do produto com o título digitado
                    {
                        Console.Write("\nDigite a quantidade que deseja retirar do estoque: \n");
                        int quantidade;
                        while (!Int32.TryParse(Console.ReadLine(), out quantidade)) //valida a entrada do usuário
                        {
                            Console.WriteLine("\nEntrada inválida! Digite um número de quantidade válido.\n");
                            Console.Write("\nDigite a quantidade que deseja retirar do estoque: \n");
                        }
                        if (quantidade <= livro.GetEstoque()) //verifica se há estoque suficiente
                        {
                            livro.SetEstoque(livro.GetEstoque() - quantidade); //atualiza o estoque do produto
                            encontrado = true;
                            Console.WriteLine("\nSaída de estoque realizada com sucesso!\n");
                        }
                        else //se não há estoque suficiente
                        {
                            Console.WriteLine("\nEstoque insuficiente!\n________________________________");
                            return;
                        }
                    }
                }
                if (this.produtos.Count == 0) //se o produto não foi encontrado
                {
                    Console.WriteLine("\nNenhum Produto Cadastrado com esse título.\n");
                    Console.WriteLine("Por favor verifique o estoque.\n________________________________");
                    return;                    
                }
                else
                {
                    Listar();
                }
            }
        }
    }
}
