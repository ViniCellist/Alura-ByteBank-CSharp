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
    new ContaCorrente(95, "123456-x") {Saldo = 100, Titular = new Cliente{Cpf = "111111", Nome = "Henrique"}},
    new ContaCorrente(95, "159753-x") {Saldo = 200, Titular = new Cliente{Cpf = "222222", Nome = "Pedro"},
    new ContaCorrente(94, "987654-x") {Saldo = 60, Titular = new Cliente{Cpf = "333333", Nome = "Marisa"}}
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
                    ListarContas();
                    break;
                case '3':
                    RemoverContas();
                    break;
                case '4';
                    OrdenarContas();
                    break;
                case '5':
                    PesquisarContas();
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
void RemoverContas()
{
    Console.Clear();
    Console.WriteLine("======================================");
    Console.WriteLine("=========   REMOVER CONTAS   =========");
    Console.WriteLine("======================================");
    Console.WriteLine("\n");
    Console.Write("Informe o número da Conta: ");
    string numeroConta = Console.ReadLine();
    ContaCorrente conta = null;
    foreach (var item in _listaDeContas)
    {
        if (item.Conta.Equals(numeroConta)
            {
            conta = item;
        }
    }
    if ( conta != null) 
    {
        _listaDeContas.Remove(conta);
        Console.WriteLine("... Conta removida da lista! ...");
    }
    else
    {
        Console.WriteLine("... Conta para remoção não encontrada ...");
    }
    Console.ReadKey();
}
void OrdenarContas()
{
    _listaDeContas.Sort();
    Console.WriteLine("... Lista de contas ordenada ...");
    Console.ReadKey();
}
void PesquisarContas()
{
    Console.Clear();
    Console.WriteLine("======================================");
    Console.WriteLine("========   PESQUISAR CONTAS   ========");
    Console.WriteLine("======================================");
    Console.WriteLine("\n");
    Console.Write("Deseja pesquisar por (1) NUMERO DA CONTA ou (2) CPF TITULAR?");
    switch (int.Parse(Console.ReadLine()))
    {
        case 1:
            {
                Console.WriteLine("Informe o número da Conta ");
                string _numeroConta = Console.ReadLine();
                ContaCorrente consultaConta = ConsultaPorNumeroConta(_numeroConta);
                Console.WriteLine(consultaConta.ToString());
                Console.ReadKey();
                break;
            }
        case 2: 
            {
                Console.WriteLine("Informe o CPF do titular: ");
                string _cpf = Console.ReadLine();
                ContaCorrente consultaCpf = ConsultaPorCPFTiular(_cpf);
                Console.WriteLine(consultaCpf.ToString());
                Console.ReadKey();
                break;
            }
        default:
            Console.WriteLine("Opção não implementada");
            break;
            
    }
}
ContaCorrente ConsultaPorCPFTiular(string? cpf)
{
    ContaCorrente conta = null;
    for (int i = 0; i < _listaDeContas.Count; i++)
    {
        if (_listaDeContas[i].Titular.Cpf.Equals(cpf))
        {
            conta = _listaDeContas[i];
        }

        return conta;
    }
}
ContaCorrente ConsultaPorNumeroConta(string? numeroConta)
{
    ContaCorrente conta = null;
    for (int i = 0; i < _listaDeContas.Count; i++)
    {
        if (_listaDeContas[i].Conta.Equals(numeroConta))
        {
            conta = _listaDeContas[i];
        }
    }

    return conta;
}
public override string ToString()
{
    return $" === DADOS DA CONTA ===\n" +
           $"Número da Conta : {this.Conta} \n" +
           $"Saldo da Conta : {this.Saldo} \n" +
           $"Titular da Conta : {this.Titular.Nome} \n" +
           $"CPF do Titular : {this.Titular.Cpf} \n" +
           $"Profissão do Titular: {this.Titular.Profissao}";
}