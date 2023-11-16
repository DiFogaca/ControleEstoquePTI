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
                Console.Write("Preço (R$): ");
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
                Console.Write("Qtde. Estoque: ");
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

        //public void Listar()//Metodo de apresentação em Matriz
        //{
        //    if (this.produtos.Count == 0)
        //    {
        //        Console.WriteLine("\nNão há produtos cadastrados.\n");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"\nProdutos cadastrados: {this.produtos.Count}\n");
        //        // Criar uma matriz de strings com o número de linhas igual ao número de livros mais um (para o cabeçalho) e o número de colunas igual a sete (para os campos dos livros)
        //        string[,] matriz = new string[this.produtos.Count + 1, 7];
        //        // Preencher a primeira linha da matriz com os títulos das colunas
        //        matriz[0, 0] = "ID";
        //        matriz[0, 1] = "Título";
        //        matriz[0, 2] = "Autor";
        //        matriz[0, 3] = "Editora";
        //        matriz[0, 4] = "Genero";
        //        matriz[0, 5] = "Preço (R$)";
        //        matriz[0, 6] = "Estoque";
        //        // Adicionando um contador
        //        int contador = 1;
        //        // Preencher as demais linhas da matriz com os dados dos livros
        //        foreach (Livro livro in this.produtos)
        //        {
        //            matriz[contador, 0] = contador.ToString(); // Usar o contador para gerar o ID do livro
        //            matriz[contador, 1] = livro.Titulo;
        //            matriz[contador, 2] = livro.Autor;
        //            matriz[contador, 3] = livro.Editora;
        //            matriz[contador, 4] = livro.Genero;
        //            matriz[contador, 5] = livro.Preco.ToString("C", new CultureInfo("pt-BR"));
        //            matriz[contador, 6] = livro.Estoque.ToString();
        //            contador++; // Incrementar o contador após cada iteração do loop
        //        }
        //        // Escrever o cabeçalho da tabela
        //        Console.WriteLine(String.Format("{0,-10} | {1,-10} | {2,-10} | {3,-10} | {4,-10} | {5,-10} | {6,-10} |", matriz[0, 0], matriz[0, 1], matriz[0, 2], matriz[0, 3], matriz[0, 4], matriz[0, 5], matriz[0, 6]));
        //        Console.WriteLine(new string('-', 85)); // Escrever uma linha separadora
        //                                                // Escrever os dados da tabela
        //        for (int j = 1; j < matriz.GetLength(0); j++) // Percorrer as linhas da matriz, começando da segunda
        //        {
        //            for (int k = 0; k < matriz.GetLength(1); k++) // Percorrer as colunas da matriz
        //            {
        //                // Escrever cada elemento da matriz no console, usando o método String.PadRight para alinhar as colunas à esquerda e adicionando um caractere | entre as colunas
        //                Console.Write(matriz[j, k].PadRight(10, ' ') + "|");
        //            }
        //            Console.WriteLine(); // Escrever uma linha em branco
        //        }
        //    }
        //}


        public void Listar() // Usando cadeia de Caracteres Interpolada
        {
            if (this.produtos.Count == 0)
            {
                Console.WriteLine("\nNão há produtos cadastrados.\n");
            }
            else
            {
                Console.WriteLine($"\nProdutos cadastrados: {this.produtos.Count}\n");
               
                int contador = 1;  // Adicionando um contador
                //Console.WriteLine($"{contador}. {livro}\n");

                // Escrever o cabeçalho da tabela
                Console.BackgroundColor = ConsoleColor.Gray;
                Console.ForegroundColor = ConsoleColor.Black;

                Console.WriteLine($"{"ID",-5} | {"Título",-10} | {"Autor",-10} | {"Editora",-10} | {"Genero",-10} | {"Preço (R$)",-10} | {"Estoque",-10} |");
                
                Console.ResetColor();
                    
                Console.WriteLine(new string('-', 85)); // Escrever uma linha separadora
                
                foreach (Livro livro in this.produtos) // Escrever os dados da tabela
                {
                    Console.WriteLine($"{contador,-5} | {livro}");
                    contador++;
                }
            }
                Console.WriteLine(); // Escrever uma linha em branco
        }

        //public void Listar() //primeiro método
        //{
        //    if (this.produtos.Count == 0)
        //    {
        //        Console.WriteLine("\nNão há produtos cadastrados.\n");
        //    }
        //    else
        //    {
        //        Console.WriteLine($"\nProdutos cadastrados: {this.produtos.Count}\n");
        //        // Adicionando um contador
        //        int contador = 1;
        //        foreach (Livro livro in this.produtos)
        //        {
        //            Console.WriteLine($"{contador}. {livro}\n");
        //            contador++;
        //        }
        //    }
        //}
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
