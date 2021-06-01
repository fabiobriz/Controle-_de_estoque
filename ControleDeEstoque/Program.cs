using System;
using System.Collections.Generic;

namespace ControleDeEstoque
{
    class Program
    {
        static void Main(string[] args)
        {
            int opcao = 0;
            int id;
            string nome;
            int quantidade;

            List<Produto> lista = new List<Produto>();


            Console.WriteLine("CONTROLE DE ESTOQUE");
            do
            {
                Console.WriteLine();
                Console.WriteLine("OPÇÃO 1: INSERIR PRODUTO");
                Console.WriteLine("OPÇÃO 2: FAZER BAIXA DE PRODUTO NO ESTOQUE");
                Console.WriteLine("OPÇÃO 3: RESUMO DO ESTOQUE");
                Console.WriteLine("OPÇÃO 4: SAIR DO SISTEMA");
                Console.Write("Digite uma opção: ");
                opcao = int.Parse(Console.ReadLine());
                Console.WriteLine();

                if (opcao == 1)
                {
                    Console.Write("Digite o ID do produto: ");
                    id = int.Parse(Console.ReadLine());

                    if (lista.Count == 0)
                    {

                        Console.Write("Digite o nome do produto: ");
                        nome = Console.ReadLine();
                        Console.Write("Digite quantos produtos serão adicionados ao estoque: ");
                        quantidade = int.Parse(Console.ReadLine());

                        Produto produto = new Produto(id, nome, quantidade);
                        lista.Add(produto);
                    }
                    else
                    {
                        int idRepetido = 0;
                        int index = 0;
                        foreach(Produto p in lista)
                        {
                            if(p.GetId() == id)
                            {
                                idRepetido = id;
                                index = lista.IndexOf(p);
                            }
                        }

                        if (idRepetido != 0)
                        {
                            Console.WriteLine($"Produto cadastrado! Digite a quantidade de {lista[index].GetNome()} que deseja adicionar ao estoque: ");
                            quantidade = int.Parse(Console.ReadLine());
                            lista[index].AdicionarProduto(quantidade);
                        }
                        else
                        {
                            Console.Write("Digite o nome do produto: ");
                            nome = Console.ReadLine();
                            Console.Write("Digite quantos produtos serão adicionados ao estoque: ");
                            quantidade = int.Parse(Console.ReadLine());

                            Produto produto = new Produto(id, nome, quantidade);
                            lista.Add(produto);
                        }

                    }
                }
                else if (opcao == 2)
                {
                    Console.Write("Digite o ID do produto que deseja dar baixa: ");
                    id = int.Parse(Console.ReadLine());
                    int idExistente = 0;
                    int index = 0;
                    foreach (Produto p in lista)
                    {
                        if (p.GetId() == id)
                        {
                            Console.Write("Quantos produtos deseja remover do estoque? ");
                            quantidade = int.Parse(Console.ReadLine());
                            if (p.GetQuantidade() - quantidade >= 0)
                            {
                                idExistente = id;
                                p.RemoverProduto(quantidade);
                            }
                            else
                            {
                                Console.WriteLine($"Restam apenas {p.GetQuantidade()} {p.GetNome()}(s) no estoque, não é possível concluir baixa.");
                            }
                        }
                        
                    }
                    if(idExistente == 0)
                    {
                        Console.WriteLine("PRODUTO NÃO ENCONTRADO");
                    }
                }
                else if (opcao == 3)
                {
                    foreach (Produto p in lista)
                    {
                        Console.WriteLine($"ID: {p.GetId()}, {p.GetNome()}, Unidades: {p.GetQuantidade()}");
                    }
                }

            }
            while (opcao != 4);
            Console.WriteLine("CONCLUÍDO.");
        }
    }
}
