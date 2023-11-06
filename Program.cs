using System;
using System.Collections.Generic;
using System.Globalization;

class Program
{
    static void Main(string[] args)
    {
        Estoque estoque = new Estoque(); //cria um objeto da classe Estoque
        string opcao = null; //variável que armazena a opção escolhida pelo usuário
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
            Console.WriteLine($"LIVRARIA DOS LIVROS - CONTROLE DE ESTOQUE\n{bordaCima}");
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

    public class Livro //classe com as propriedades do programa de estoque, como o construtor e os metodos
    {
        //Propriedades da classe Livro
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editora { get; set; }
        public string Genero { get; set; }
        public double Preco { get; set; }
        public int Estoque { get; set; }

        //Construtor da classe Livro
        public Livro(string titulo, string autor, string editora, string genero, double preco, int estoque)
        {
            this.Titulo = titulo;
            this.Autor = autor;
            this.Editora = editora;
            this.Genero = genero;
            this.Preco = preco;
            this.Estoque = estoque;
        }
        //Métodos
        public string GetTitulo()
        {
            return this.Titulo;
        }
        public void SetEstoque(int quantidade)
        {
            this.Estoque = quantidade;
        }
        public int GetEstoque()
        {
            return this.Estoque;
        }
        public override string ToString()
        {
            return $"Título: {this.Titulo}, Autor(a): {this.Autor}, Editora: {this.Editora}, Gênero: {this.Genero}, Preço: ({this.Preco.ToString("C", new CultureInfo("pt-BR"))}) - {this.Estoque} em Estoque.";
        }
    }
    class Estoque
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
            Livro livro = new Livro(titulo, autor, editora, genero, preco, estoque); //cria um objeto da classe Livro
            this.produtos.Add(livro); //adiciona o objeto à lista
            Console.WriteLine("\nProduto cadastrado com sucesso!\n");
        }
        public void Listar() //Método que lista todos os produtos da lista
        {
            if (this.produtos.Count == 0) //verifica se a lista está vazia
            {
                Console.WriteLine("\nNão há produtos cadastrados.\n"); //Avisa quando não há produtos cadastrados no sistema
            }
            else
            {
                Console.WriteLine($"\nProdutos cadastrados: {this.produtos.Count}\n"); //Mostra a quantidade de produtos cadastrados
                foreach (Livro livro in this.produtos) //percorre a lista
                {
                    Console.WriteLine(livro + "\n"); //imprime as informações do produto
                }
            }
        }
        public void Remover() //Método que remove um produto da lista
        {
            Console.Write("\nDigite o título do produto que deseja remover: \n");
            string titulo = Console.ReadLine();
            bool encontrado = false; // variável que indica se o produto foi encontrado
            foreach (Livro livro in this.produtos) //percorre a lista
            {
                if (livro.Titulo == titulo) //compara o título do produto com o título digitado
                {
                    this.produtos.Remove(livro); //remove o produto da lista
                    encontrado = true;
                    Console.WriteLine("\nProduto removido com sucesso!\n");
                    break;
                }
            }
            if (!encontrado) //se o produto não foi encontrado
            {
                Console.WriteLine("\nProduto não encontrado!\n");
            }
        }
        public void Entrada() //Método que realiza uma entrada de estoque de um produto
        {
            Console.Write("\nDigite o título do produto que deseja dar entrada: \n");
            string titulo = Console.ReadLine();
            bool encontrado = false; //variável que indica se o produto foi encontrado
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
                    break;
                }
            }
            if (!encontrado) // se o produto não foi encontrado
            {
                Console.WriteLine("\nProduto não encontrado!\n");
            }
        }

        public void Saida() //Método que realiza uma saída de estoque de um produto
        {
            Console.Write("\nDigite o título do produto que deseja dar saída: \n");
            string titulo = Console.ReadLine();
            bool encontrado = false; //variável que indica se o produto foi encontrado
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
                        Console.WriteLine("\nEstoque insuficiente!\n");
                    }
                    break;
                }
            }
            if (!encontrado) //se o produto não foi encontrado
            {
                Console.WriteLine("\nProduto não encontrado!\n");
            }
        }
    }
}