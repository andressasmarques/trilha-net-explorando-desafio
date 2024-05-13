using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        // Cria os modelos de hóspedes e cadastra na lista de hóspedes
        List<Pessoa> hospedes = new List<Pessoa>();

        Pessoa p1 = new Pessoa(nome: "Hóspede 1");
        Pessoa p2 = new Pessoa(nome: "Hóspede 2");

        hospedes.Add(p1);
        hospedes.Add(p2);

        // Cria a suíte
        Suite suite = new Suite(tipoSuite: "Premium", capacidade: 2, valorDiaria: 30);

        try
        {
            // Cria uma nova reserva, passando a suíte e os hóspedes
            Reserva reserva = new Reserva(diasReservados: 5);
            reserva.CadastrarSuite(suite);
            reserva.CadastrarHospedes(hospedes);

            // Exibe a quantidade de hóspedes e o valor da diária
            Console.WriteLine($"Hóspedes: {reserva.ObterQuantidadeHospedes()}");
            Console.WriteLine($"Valor diária: {reserva.CalcularValorDiaria()}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Erro ao fazer reserva: {ex.Message}");
        }
    }
}

class Pessoa
{
    public string Nome { get; }

    public Pessoa(string nome)
    {
        Nome = nome;
    }
}

class Suite
{
    public string TipoSuite { get; }
    public int Capacidade { get; }
    public decimal ValorDiaria { get; }

    public Suite(string tipoSuite, int capacidade, decimal valorDiaria)
    {
        TipoSuite = tipoSuite;
        Capacidade = capacidade;
        ValorDiaria = valorDiaria;
    }
}

class Reserva
{
    private Suite suite;
    private List<Pessoa> hospedes;
    public int DiasReservados { get; }

    public Reserva(int diasReservados)
    {
        DiasReservados = diasReservados;
    }

    public void CadastrarSuite(Suite suite)
    {
        this.suite = suite;
    }

    public void CadastrarHospedes(List<Pessoa> hospedes)
    {
        if (hospedes.Count > suite.Capacidade)
            throw new Exception("A quantidade de hóspedes é maior do que a capacidade da suíte.");

        this.hospedes = hospedes;
    }

    public int ObterQuantidadeHospedes()
    {
        return hospedes.Count;
    }

    public decimal CalcularValorDiaria()
{
    decimal valorTotal = DiasReservados * suite.ValorDiaria;

    // Aplica desconto de 10% se a reserva for para 10 dias ou mais
    if (DiasReservados >= 10)
        valorTotal *= 0.9m; // Aplica o desconto de 10%

    return valorTotal;
}}
