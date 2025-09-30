using System;

namespace API.models;

public class Produto
{
    //Construtor
    public Produto()
    {
        Id = Guid.NewGuid().ToString();
        CriadoEm = DateTime.Now;
        Nome = string.Empty;
    }

    //Atributos|Propriedades|Caracteristicas C#
    public string Id { get; set; }
    public string Nome { get; set; } 
    public int Quantidade { get; set; }

    public double Preco { get; set; }

    public DateTime CriadoEm { get; set; }


    //Atributos|Propriedades|Caracteristicas  Java

    //private string nome;
    //public string getNome()
    // {
    //     return nome;
    //}

    //public void setNome(string nome)
    //{
    //    this.nome = nome;
    //}



}
