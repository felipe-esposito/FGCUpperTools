// See https://aka.ms/new-console-template for more information
using System.Globalization;

Console.WriteLine("Hello, World!");

var count = 0;
string line;

string filepath = "../../../Test/TesteFGC.csv"; //local do arquivo a ser lido

using (var fs = File.OpenRead(filepath))
using (var reader = new StreamReader(fs))
    while ((line = reader.ReadLine()) != null) // Lendo linhas uma por uma para não precisar carregar tudo na memória
    {
        var parts = line.Split(';'); //Divide a linha em partes

        int id = int.Parse(parts[0]); //ID da conta

        var dateParts = parts[1].Split('/'); //Subdivide a data, para obter ano, mês e dia separadamente

        DateTime expireDate = new(int.Parse(dateParts[2]), int.Parse(dateParts[1]), int.Parse(dateParts[0])); // Instancia a data

        double value = double.Parse(parts[2]); //Valor a ser pago

        Console.WriteLine("Conta Nº: " + id + "  Vencimento: " + expireDate.ToShortDateString() + "  Valor: R$: " + String.Format("{0:0.00}", value));
        
        count++;
    }
Console.WriteLine("\n" + count + " contas processadas");