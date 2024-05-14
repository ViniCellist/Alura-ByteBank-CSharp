using System;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

//TestaBuscarPalavra();
//TestaMediana(amostra);
TestaArrayDeContasCorrentes();

void TestaArrayInt ()
{
    int[] idades = new int[5];
    idades[0] = 30;
    idades[1] = 40;
    idades[2] = 50;
    idades[3] = 42;
    idades[4] = 18;

    Console.WriteLine($"Tamanho do Array {idades.Length}");
    int acumulador = 0;

    for ( int i = 0; i < idades.Length; i++ )
    {
        int idade = idades[i];
        Console.WriteLine($"Índice [{i}] = {idade}");
        acumulador += idade;
    }

    int media = acumulador / idades.Length;
    Console.WriteLine($"Media de idades = {media}");
}

void TestaBuscarPalavra ()
{
    string[] arrayDePalavras = new string[5];

    for (int i = 0;i < arrayDePalavras.Length;i++ )
    {
        Console.WriteLine($"Digite {i + 1}° Paralavras:");
        arrayDePalavras[i] = Console.ReadLine();
    }

    Console.WriteLine("Digite a palavra a ser encontrada: ");
    var busca = Console.ReadLine();

    foreach (string palavra in arrayDePalavras)
    {
        if (palavra.Equals(busca))
        {
            Console.WriteLine($"Palavra encontrada = {busca}.");
            break;
        }
    }
}

Array amostra = Array.CreateInstance(typeof(double), 5);
amostra.SetValue(7, 0);
amostra.SetValue(8, 1);
amostra.SetValue(6, 2);
amostra.SetValue(3, 3);
amostra.SetValue(10, 4);

void TestaMediana(Array array)
{
    if (array == null || array.Length == 0)
    {
        Console.WriteLine("Array para cáculo da media está vazio ou nulo");
    }

    double[] numerosOrdenados = (double [])array.Clone();
    Array.Sort(numerosOrdenados);

    int tamanho = numerosOrdenados.Length;
    int meio = tamanho / 2;
    double mediana = (tamanho % 2 != 0) ?
        numerosOrdenados[meio] : numerosOrdenados[meio] + (numerosOrdenados[meio - 1]) / 2;

    Console.WriteLine($"Com base na amostra a mediana = {mediana}");
}

void TestaArrayDeContasCorrentes()
{
    ListaDeContasCorrentes listaDeContas = new ListaDeContasCorrentes[]
    {
        new ContaCorrente(874, "5679787-A"),
        new ContaCorrente(874, "4456668-B"),
        new ContaCorrente(874, "7781438-C")
    };

    
}
