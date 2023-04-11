// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Generic;

namespace JRJ.Classes{
public class Produto
{
    public string Descricao { get; set; }
    public string Nome { get; set; }
    public double Preco { get; set; }
    public Categoria Categoria { get; set; }
}

public class Categoria
{
    public string Descricao { get; set; }
    public string Nome { get; set; }
}

public class Cliente
{
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
}

