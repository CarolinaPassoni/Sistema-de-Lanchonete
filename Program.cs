using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Listas para armazenar os produtos cadastrados
        List<string> produtos = new List<string>();
        List<double> precos = new List<double>();

        Console.WriteLine("=== CADASTRO DE PRODUTOS ===");

        // Cadastro de produtos (WHILE)
        string continuar = "s";
        while (continuar.ToLower() == "s")
        {
            Console.Write("Digite o nome do produto: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o preço do produto: ");
            if (double.TryParse(Console.ReadLine(), out double preco))
            {
                produtos.Add(nome);
                precos.Add(preco);
                Console.WriteLine("Produto cadastrado com sucesso!");
            }
            else
            {
                Console.WriteLine("Preço inválido!");
            }

            Console.Write("Deseja cadastrar outro produto? (s/n): ");
            continuar = Console.ReadLine();
        }

        // Pedido do cliente
        double total = 0;
        List<string> itensPedido = new List<string>();
        List<double> valoresPedido = new List<double>();

        Console.WriteLine("\n=== INICIANDO PEDIDO ===");

        int opcao;
        do
        {
            // Exibe o cardápio com FOR
            Console.WriteLine("\n===== CARDÁPIO =====");
            for (int i = 0; i < produtos.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {produtos[i]} (R$ {precos[i]:F2})");
            }
            Console.WriteLine($"{produtos.Count + 1} - Finalizar pedido");
            Console.WriteLine("===================");

            Console.Write("Escolha um produto: ");
            if (!int.TryParse(Console.ReadLine(), out opcao))
            {
                Console.WriteLine("Opção inválida!");
                continue;
            }

            if (opcao >= 1 && opcao <= produtos.Count)
            {
                // Pergunta a quantidade
                Console.Write("Digite a quantidade: ");
                if (int.TryParse(Console.ReadLine(), out int qtd) && qtd > 0)
                {
                    double subtotal = precos[opcao - 1] * qtd;
                    total += subtotal;

                    // Adiciona ao pedido
                    itensPedido.Add($"{qtd}x {produtos[opcao - 1]}");
                    valoresPedido.Add(subtotal);

                    Console.WriteLine($"Adicionado: {qtd}x {produtos[opcao - 1]} (R$ {subtotal:F2})");
                }
                else
                {
                    Console.WriteLine("Quantidade inválida!");
                }
            }
            else if (opcao == produtos.Count + 1)
            {
                Console.WriteLine("\nPedido finalizado!");
                break; // Sai do loop do pedido
            }
            else
            {
                Console.WriteLine("Opção inválida!");
            }

        } while (true); // Mantém o menu até o cliente finalizar

        // Resumo do pedido (FOREACH)
        Console.WriteLine("\n===== RESUMO DO PEDIDO =====");
        int pos = 0;
        foreach (string item in itensPedido)
        {
            Console.WriteLine($"{item} - R$ {valoresPedido[pos]:F2}");
            pos++;
        }
        Console.WriteLine($"TOTAL: R$ {total:F2}");
        Console.WriteLine("============================");
        Console.WriteLine("Obrigado pela preferência!");
    }
}

