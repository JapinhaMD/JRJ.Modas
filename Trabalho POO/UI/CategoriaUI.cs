using System;
using System.Collections.Generic;

namespace JRJ.Categoria{

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

}


