using bytebank.Modelos.Conta;
using System;
using System.Collections;
using System.Security.Cryptography.X509Certificates;

Console.WriteLine("Boas Vindas ao ByteBank, Atendimento.");

#region Exemplos Arrays em C#
//TestaBuscarPalavra();
//TestaMediana(amostra);

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
    ListaDeContasCorrentes listaDeContas = new ListaDeContasCorrentes()
    listaDeContas.Adicionar(new ContaCorrente(874, "5679787-A"));
    listaDeContas.Adicionar(new ContaCorrente(874, "4456668-B"));
    listaDeContas.Adicionar(new ContaCorrente(874, "7781438-C"));
    listaDeContas.Adicionar(new ContaCorrente(874, "8894562-D"));
    listaDeContas.Adicionar(new ContaCorrente(874, "1534589-F"));

    //var contaDoVinicius = new ContaCorrente(963, "123456789-G");
    //listaDeContas.Adicionar(contaDoVinicius);
    //listaDeContas.ExibeLista();

    for (int i = 0; i < listaDeContdas.Length; i++)
    {
        ContaCorrente conta = listaDeContas[i];
        Console.WriteLine($"Indice [{i}] = {conta.Conta}/{conta.Nome_Agencia}");
    }
}

//TestaArrayDeContasCorrentes();
#endregion
List<ContaCorrente> _listaDeContas = new List<ContaCorrente>()
{
    new ContaCorrente(95, "123456-x") {Saldo = 100},
    new ContaCorrente(95, "159753-x") {Saldo = 200},
    new ContaCorrente(94, "987654-x") {Saldo = 60}
};

AtendimentoCliente();
void AtendimentoCliente()
{
    try
    {
        char opcao = '0';
        while (opcao != '6')
        {
            Console.Clear();
            Console.WriteLine("====================================");
            Console.WriteLine("========     Atendimento    ========");
            Console.WriteLine("========1 - Cadastrar Conta ========");
            Console.WriteLine("========2 - Listar Contas   ========");
            Console.WriteLine("========3 - Remover Conta   ========");
            Console.WriteLine("========4 - Ordenar Contas  ========");
            Console.WriteLine("========5 - Pesquisar Conta ========");
            Console.WriteLine("========6 - Sair do Sistema ========");
            Console.WriteLine("====================================");
            Console.WriteLine("\n\n");
            Console.WriteLine("Digite a opção desejada: ");
            try
            {
                opcao = Console.ReadLine()[0];
            }
            catch (Exception excecao)
            {

                throw new ByteBankException(excecao.Message);
            }
            
            switch (opcao)
            {
                case '1':
                    CadastrarConta();
                    break;
                case '2':
                    ListarConta();
                    break;

                default:
                    Console.WriteLine("Opção não implentada.");
                    break;
            }
        }
    }
    catch (ByteBankException excecao)
    {

        Console.WriteLine($"{excecao.Message}");
    }
    
}

void ListarContas()
{
    Console.Clear();
    Console.WriteLine("==============================");
    Console.WriteLine("===    LISTA DE CONTAS     ===");
    Console.WriteLine("==============================");
    Console.WriteLine("\n");
    if (_listaDeContas.Count <= 0)
    {
        Console.WriteLine("... Não há contas cadastradas! ...");
        Console.ReadKey();
        return;
    }
    foreach (ContaCorrente item in _listaDeContas)
    {
        Console.WriteLine("===  Dados da Conta  ===");
        Console.WriteLine("Número da Conta: " + item.Conta);
        Console.WriteLine("Saldo: " + item.Saldo);
        Console.WriteLine("Titular da Conta: " + item.Titular.Nome);
        Console.WriteLine("CPF do Titular: " + item.Titular.Cpf);
        Console.WriteLine("Profissão do Titular: " + item.Titular.Profissão);
        Console.WriteLine(">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>");
        Console.ReadKey();
    }
}

void CadastrarConta()
{
    Console.Clear();
    Console.WriteLine("======================================");
    Console.WriteLine("=======   CADASTRO DE CONTAS   =======");
    Console.WriteLine("======================================");
    Console.WriteLine("\n");
    Console.WriteLine("=== Informe dados da conta ===");
    Console.WriteLine("Número da conta: ");
    string numeroConta = Console.ReadLine();

    Console.WriteLine("Número da Agência: ");
    int numeroAgencia = int.Parse(Console.ReadLine());

    ContaCorrente conta = new ContaCorrente(numeroAgencia, numeroConta);

    Console.WriteLine("Informe o saldo inicial: ");
    conta.Saldo = double.Parse(Console.ReadLine());

    Console.WriteLine("Informe nome do Titular: ");
    conta.Titular.Nome = Console.ReadLine();

    Console.WriteLine("Informe o CPF do Titular: ");
    conta.Titular.Cpf = Console.ReadLine();

    Console.WriteLine("Informe a profissão do Titular: ");
    conta.Titular.Profissao = Console.ReadLine();

    _listaDeContas.Add(conta);
  
    Console.WriteLine("... Conta cadastrada com sucesso! ...");
    Console.ReadKey();
}

Generica<int> teste1 = new Generica<int>();
teste1.MostrarMensagem(10);

Generica<string> teste2 = new Generica<string>();
teste2.MostrarMensagem("Olá mundo!");

#regio Exemplo de uso do List
//public class Generica<T>
//{
//    public void MostrarMensagem(T t)
//    {
//        Console.WriteLine($"Exibindo {t}");
//    }
//}

//List<ContaCorrente> _listadeContas2 = new List<ContaCorrente>()
//{
//    new ContaCorrente(874,"5679797-A"),
//    new ContaCorrente(874, "4456668-B"),
//    new ContaCorrente(874, "7781438-C")
//};

//List<ContaCorrente> _listaDeContas3 = new List<ContaCorrente>()
//{
//    new ContaCorrente(951, "5679787-E"),
//    new ContaCorrente(321, "4456668-F"),
//    new ContaCorrente(719, "7781438-G")
//};

//_listadeContas2.AddRange(_listaDeContas3);
//_listadeContas2.Reverse();

//Console.WriteLine("\n\n");

//var range = _listadeContas3.GetRange(0, 1);
//for (int i = 0; i < _listadeContas2.Count; i++)
//{
//    Console.WriteLine($"Indice[{i}] = Conta [{range[i].Conta}]");
//}

//Console.WriteLine("\n\n");

//_listaDeContas3.Clear();
//for (int i = 0; i < _listaDeContas3.Count; i++)
//{
//    Console.WriteLine($"Indice[{i}] = Conta [{range[i].Conta}]");
//}
#endregion




