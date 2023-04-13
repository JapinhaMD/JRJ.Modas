// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

public class Produto
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public string Nome { get; set; }
    public double Preco { get; set; }
    public Categoria Categoria { get; set; }
}

public class Categoria
{
    public int Id { get; set; }
    public string Descricao { get; set; }
    public string Nome { get; set; }
}

public class Cliente
{
    public int Id { get; set; }
    public string Sobrenome { get; set; }
    public string Nome { get; set; }
    public string Endereco { get; set; }
    public string Telefone { get; set; }
}

public class Venda
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public Cliente Cliente { get; set; }
    public List<ItemVenda> Itens { get; set; }
    public double Total { get; set; }

    public Venda()
    {
        Itens = new List<ItemVenda>();
    }
}

public class ItemVenda
{
    public int Id { get; set; }
    public Produto Produto { get; set; }
    public int Quantidade { get; set; }
    public double PrecoUnitario { get; set; }

    public double Subtotal
    {
        get { return Quantidade * PrecoUnitario; }
    }
}

public class Program
{
    static List<Produto> produtos = new List<Produto>();
    static List<Categoria> categorias = new List<Categoria>();
    static List<Cliente> clientes = new List<Cliente>();
    static List<Venda> vendas = new List<Venda>();
    static int proximoIdProduto = 1;
    static int proximoIdCategoria = 1;
    static int proximoIdCliente = 1;
    static int proximoIdVenda = 1;

    static void Main(string[] args)
    {
        bool continuar = true;
        do
        {
            Console.Clear();
            Console.WriteLine("1 - Gerenciar produtos");
            Console.WriteLine("2 - Gerenciar categorias");
            Console.WriteLine("3 - Gerenciar clientes");
            Console.WriteLine("4 - Realizar venda");
            Console.WriteLine("5 - Mostrar relatório de vendas");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    GerenciarProdutos();
                    break;
                case "2":
                    GerenciarCategorias();
                    break;
                case "3":
                    GerenciarClientes();
                    break;
                case "4":
                    RealizarVenda();
                    break;
                case "5":
                    MostrarRelatorioVendas();
                    break;
                case "0":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        } while (continuar);
    }

    static void GerenciarProdutos()
    {
        bool continuar = true;
        do
        {
            Console.Clear();
            Console.WriteLine("1 - Listar produtos");
            Console.WriteLine("2 - Cadastrar produto");
            Console.WriteLine("3 - Alterar produto");
            Console.WriteLine("4 - Excluir produto");
            Console.WriteLine("0 - Voltar");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    ListarProdutos();
                    break;
                case "2":
                    CadastrarProduto();
                    break;
                case "3":
                    AlterarProduto();
                    break;
                case "4":
                    ExcluirProduto();
                    break;
                case "0":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        } while (continuar);
    }

    static void ListarProdutos()
    {
        Console.Clear();
        Console.WriteLine("Lista de produtos:");
        foreach (var produto in produtos)
        {
            Console.WriteLine($"ID: {produto.Id} | Nome: {produto.Nome} | Preço: {produto.Preco} | Categoria: {produto.Categoria.Nome}");
        }
    }


    static void CadastrarProduto()
    {
        Console.Clear();
        Console.WriteLine("Cadastro de produto:");

        Produto produto = new Produto();

        produto.Id = proximoIdProduto++;

        Console.Write("Nome: ");
        produto.Nome = Console.ReadLine();

        Console.Write("Preço: ");
        produto.Preco = double.Parse(Console.ReadLine());

        Console.Write("ID da categoria: ");
        int idCategoria = int.Parse(Console.ReadLine());
        produto.Categoria = categorias.Find(c => c.Id == idCategoria);

        produtos.Add(produto);

        Console.WriteLine("Produto cadastrado com sucesso!");
    }

    static void AlterarProduto()
    {
        Console.Clear();
        Console.WriteLine("Alteração de produto:");

        Console.Write("ID do produto: ");
        int idProduto = int.Parse(Console.ReadLine());

        Produto produto = produtos.Find(p => p.Id == idProduto);

        if (produto != null)
        {
            Console.Write($"Nome ({produto.Nome}): ");
            string nome = Console.ReadLine();
            if (!string.IsNullOrEmpty(nome))
            {
                produto.Nome = nome;
            }

            Console.Write($"Preço ({produto.Preco}): ");
            string precoStr = Console.ReadLine();
            if (!string.IsNullOrEmpty(precoStr))
            {
                produto.Preco = double.Parse(precoStr);
            }

            Console.Write($"ID da categoria ({produto.Categoria.Id}): ");
            string idCategoriaStr = Console.ReadLine();
            if (!string.IsNullOrEmpty(idCategoriaStr))
            {
                int idCategoria = int.Parse(idCategoriaStr);
                produto.Categoria = categorias.Find(c => c.Id == idCategoria);
            }

            Console.WriteLine("Produto alterado com sucesso!");
        }
        else
        {
            Console.WriteLine("Produto não encontrado!");
        }
    }

    static void ExcluirProduto()
    {
        Console.Clear();
        Console.WriteLine("Exclusão de produto:");

        Console.Write("ID do produto: ");
        int idProduto = int.Parse(Console.ReadLine());

        Produto produto = produtos.Find(p => p.Id == idProduto);

        if (produto != null)
        {
            produtos.Remove(produto);
            Console.WriteLine("Produto excluído com sucesso!");
        }
        else
        {
            Console.WriteLine("Produto não encontrado!");
        }
    }



    static void GerenciarCategorias()
    {
        bool continuar = true;
        do
        {
            Console.Clear();
            Console.WriteLine("1 - Listar categorias");
            Console.WriteLine("2 - Cadastrar categoria");
            Console.WriteLine("3 - Alterar categoria");
            Console.WriteLine("4 - Excluir categoria");
            Console.WriteLine("0 - Voltar");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    ListarCategorias();
                    break;
                case "2":
                    CadastrarCategoria();
                    break;
                case "3":
                    AlterarCategoria();
                    break;
                case "4":
                    ExcluirCategoria();
                    break;
                case "0":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        } while (continuar);
    }

    static void ListarCategorias()
    {
        Console.Clear();
        Console.WriteLine("Lista de categorias:");
        foreach (var categoria in categorias)
        {
            Console.WriteLine($"ID: {categoria.Id} | Nome: {categoria.Nome}");
        }
    }

    static void CadastrarCategoria()
    {
        Console.Clear();
        Console.WriteLine("Cadastro de categoria:");
        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        Categoria categoria = new Categoria
        {
            Id = proximoIdCategoria,
            Nome = nome
        };
        categorias.Add(categoria);
        proximoIdCategoria++;

        Console.WriteLine();
        Console.WriteLine("Categoria cadastrada com sucesso!");
    }

    static void AlterarCategoria()
    {
        Console.Clear();
        Console.WriteLine("Alteração de categoria:");
        Console.Write("Digite o ID da categoria que deseja alterar: ");
        int id = int.Parse(Console.ReadLine());
        Categoria categoria = categorias.Find(c => c.Id == id);
        if (categoria == null)
        {
            Console.WriteLine("Categoria não encontrada!");
            return;
        }
        Console.Write($"Novo nome para a categoria {categoria.Nome}: ");
        string nome = Console.ReadLine();
        categoria.Nome = nome;

        Console.WriteLine();
        Console.WriteLine("Categoria alterada com sucesso!");
    }

    static void ExcluirCategoria()
    {
        Console.Clear();
        Console.WriteLine("Exclusão de categoria:");
        Console.Write("Digite o ID da categoria que deseja excluir: ");
        int id = int.Parse(Console.ReadLine());
        Categoria categoria = categorias.Find(c => c.Id == id);
        if (categoria == null)
        {
            Console.WriteLine("Categoria não encontrada!");
            return;
        }
        if (produtos.Exists(p => p.Categoria.Id == categoria.Id))
        {
            Console.WriteLine("Não é possível excluir a categoria, pois existem produtos vinculados a ela!");
            return;
        }
        categorias.Remove(categoria);

        Console.WriteLine();
        Console.WriteLine("Categoria excluída com sucesso!");
    }

    static void GerenciarClientes()
    {
        bool continuar = true;
        do
        {
            Console.Clear();
            Console.WriteLine("1 - Listar clientes");
            Console.WriteLine("2 - Cadastrar cliente");
            Console.WriteLine("3 - Alterar cliente");
            Console.WriteLine("4 - Excluir cliente");
            Console.WriteLine("0 - Voltar");
            Console.Write("Escolha uma opção: ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    ListarClientes();
                    break;
                case "2":
                    CadastrarCliente();
                    break;
                case "3":
                    AlterarCliente();
                    break;
                case "4":
                    ExcluirCliente();
                    break;
                case "0":
                    continuar = false;
                    break;
                default:
                    Console.WriteLine("Opção inválida!");
                    break;
            }
            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        } while (continuar);
    }
    static void ListarClientes()
    {
        Console.Clear();
        Console.WriteLine("Lista de clientes:");
        foreach (var cliente in clientes)
        {
            Console.WriteLine($"ID: {cliente.Id} | Nome: {cliente.Nome} | Endereço: {cliente.Endereco}");
        }
    }

    static void CadastrarCliente()
    {
        Console.Clear();
        Console.WriteLine("Cadastro de cliente:");
        Console.Write("Nome: ");
        string nome = Console.ReadLine();
        Console.Write("Endereço: ");
        string endereco = Console.ReadLine();

        Cliente cliente = new Cliente
        {
            Id = proximoIdCliente,
            Nome = nome,
            Endereco = endereco
        };
        clientes.Add(cliente);
        proximoIdCliente++;

        Console.WriteLine();
        Console.WriteLine("Cliente cadastrado com sucesso!");
    }

    static void AlterarCliente()
    {
        Console.Clear();
        Console.WriteLine("Alterar cliente");
        Console.Write("Digite o ID do cliente que deseja alterar: ");
        int id = int.Parse(Console.ReadLine());
        Cliente cliente = clientes.Find(c => c.Id == id);
        if (cliente == null)
        {
            Console.WriteLine("Cliente não encontrado!");
            return;
        }
        Console.Write("Digite o novo nome: ");
        string nome = Console.ReadLine();
        Console.Write("Digite o novo endereço: ");
        string endereco = Console.ReadLine();
        cliente.Nome = nome;
        cliente.Endereco = endereco;
        Console.WriteLine("Cliente alterado com sucesso!");
    }
    static void ExcluirCliente()
    {
        Console.Clear();
        Console.WriteLine("Excluir cliente");

        Console.Write("Informe o ID do cliente que deseja excluir: ");
        int id = int.Parse(Console.ReadLine());

        Cliente cliente = clientes.Find(c => c.Id == id);
        if (cliente != null)
        {
            clientes.Remove(cliente);
            Console.WriteLine("Cliente removido com sucesso!");
        }
        else
        {
            Console.WriteLine("Cliente não encontrado!");
        }
    }

    static void RealizarVenda()
    {
        Console.Clear();
        Console.WriteLine("Realizar venda:");

        // Seleciona um cliente existente ou cadastra um novo
        Cliente cliente = SelecionarCliente();

        // Cria uma nova venda
        Venda venda = new Venda();
        venda.Cliente = cliente;
        venda.Id = proximoIdVenda;
        proximoIdVenda++;

        bool continuar = true;
        do
        {
            Console.Clear();
            Console.WriteLine($"Venda nº {venda.Id} - Cliente: {venda.Cliente.Nome}");
            Console.WriteLine();
            ListarProdutos();

            Console.WriteLine();
            Console.WriteLine("Digite o ID do produto que deseja comprar (0 para finalizar):");
            int idProduto = int.Parse(Console.ReadLine());

            if (idProduto == 0)
            {
                // Finaliza a venda
                venda.Total = venda.Itens.Sum(i => i.Subtotal);
                vendas.Add(venda);
                Console.WriteLine($"Venda finalizada. Total: R${venda.Total}");
                continuar = false;
            }
            else
            {
                // Seleciona o produto a ser comprado
                Produto produto = produtos.Find(p => p.Id == idProduto);
                if (produto == null)
                {
                    Console.WriteLine("Produto não encontrado!");
                }
                else
                {
                    // Pede a quantidade desejada
                    Console.WriteLine($"Digite a quantidade de {produto.Nome} que deseja comprar:");
                    int quantidade = int.Parse(Console.ReadLine());



                    // Adiciona o item à venda
                    ItemVenda item = new ItemVenda();
                    item.Id = venda.Itens.Count + 1;
                    item.Produto = produto;
                    item.Quantidade = quantidade;
                    item.PrecoUnitario = produto.Preco;
                    venda.Itens.Add(item);

                    Console.WriteLine($"{quantidade} {produto.Nome} adicionado(s) à venda!");

                }
            }

            Console.WriteLine();
            Console.WriteLine("Pressione qualquer tecla para continuar...");
            Console.ReadKey();
        } while (continuar);
    }

    static Cliente SelecionarCliente()
    {
        Console.Clear();
        Console.WriteLine("Selecione o cliente:");
        foreach (var cliente in clientes)
        {
            Console.WriteLine($"ID: {cliente.Id} | Nome: {cliente.Nome} | Endereço: {cliente.Endereco}");
        }
        Console.Write("Digite o ID do cliente ou 0 para voltar: ");
        int idCliente;
        while (!int.TryParse(Console.ReadLine(), out idCliente) || (idCliente != 0 && !clientes.Exists(c => c.Id == idCliente)))
        {
            Console.WriteLine("ID inválido! Digite novamente...");
            Console.Write("Digite o ID do cliente ou 0 para voltar: ");
        }
        if (idCliente == 0)
        {
            return null;
        }
        else
        {
            return clientes.Find(c => c.Id == idCliente);
        }
    }
    static void MostrarRelatorioVendas()
    {
        Console.Clear();
        Console.WriteLine("Relatório de Vendas:");

        if (vendas.Count == 0)
        {
            Console.WriteLine("Não há vendas registradas.");
            return;
        }

        double totalVendas = 0;

        foreach (var venda in vendas)
        {
            Console.WriteLine($"ID da venda: {venda.Id} | Data: {venda.Data} | Cliente: {venda.Cliente.Nome}");

            foreach (var itemVenda in venda.Itens)
            {
                Console.WriteLine($"   - Produto: {itemVenda.Produto.Nome} | Quantidade: {itemVenda.Quantidade} | Preço unitário: {itemVenda.PrecoUnitario:C2} | Subtotal: {itemVenda.Subtotal:C2}");
            }

            Console.WriteLine($"   Total da venda: {venda.Total:C2}");
            Console.WriteLine();

            totalVendas += venda.Total;
        }

        Console.WriteLine($"Total de vendas: {vendas.Count} | Valor total das vendas: {totalVendas:C2}");

    }
}