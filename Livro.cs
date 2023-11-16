using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControleEstoquePTI
{
    internal class Livro //classe com as propriedades do programa de estoque, como o construtor e os metodos
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
            //O primeiro return é  do método simples
            //return $"Título: {this.Titulo}, Autor(a): {this.Autor}, Editora: {this.Editora}, Gênero: {this.Genero}, Preço: ({this.Preco.ToString("C", new CultureInfo("pt-BR"))}) - {this.Estoque} em Estoque.";
            
            //Este return é do método de Interpolação
            return $"{this.Titulo,-10} | {this.Autor,-10} | {this.Editora,-10} | {this.Genero,-10} | {this.Preco.ToString("C", new CultureInfo("pt-BR")),-10} | {this.Estoque,-10} |";
        }
    }

}

