using System;

namespace SapiensBank
{
    class Program
    {
        static Banco banco = new Banco();

        static void Main(string[] args)
        {
            int opcao;

            do
            {
                MostrarMenu();
                opcao = int.Parse(Console.ReadLine());
                Console.WriteLine();

                switch (opcao)
                {
                    case 1: InserirConta(); break;
                    case 2: ListarContas(); break;
                    case 3: Sacar(); break;
                    case 4: Depositar(); break;
                    case 5: AumentarLimite(); break;
                    case 6: DiminuirLimite(); break;
                    case 0: Console.WriteLine("Saindo..."); break;
                    default: Console.WriteLine("Opção inválida!"); break;
                }

            } while (opcao != 0);
        }

        // Menu em função separada
        static void MostrarMenu()
        {
            Console.WriteLine("\n=== MENU DO BANCO ===");
            Console.WriteLine("1 - Inserir Conta");
            Console.WriteLine("2 - Listar Contas");
            Console.WriteLine("3 - Sacar");
            Console.WriteLine("4 - Depositar");
            Console.WriteLine("5 - Aumentar Limite");
            Console.WriteLine("6 - Diminuir Limite");
            Console.WriteLine("0 - Sair");
            Console.Write("Escolha uma opção: ");
        }

        // Função auxiliar para evitar repetir código
        static Conta ObterConta()
        {
            Console.Write("Número da conta: ");
            int numero = int.Parse(Console.ReadLine());

            Conta conta = banco.BuscarConta(numero);

            if (conta == null)
                Console.WriteLine("Conta não encontrada!");

            return conta;
        }

        static void InserirConta()
        {
            Console.Write("Número da conta: ");
            int numero = int.Parse(Console.ReadLine());

            Console.Write("Nome do cliente: ");
            string nome = Console.ReadLine();

            banco.Inserir(new Conta(numero, nome));

            Console.WriteLine("Conta criada com sucesso!");
        }

        static void ListarContas()
        {
            banco.ListarContas();
        }

        static void Sacar()
        {
            Conta conta = ObterConta();
            if (conta == null) return;

            Console.Write("Valor do saque: ");
            double valor = double.Parse(Console.ReadLine());

            conta.Sacar(valor);
            Console.WriteLine("Saque realizado!");
        }

        static void Depositar()
        {
            Conta conta = ObterConta();
            if (conta == null) return;

            Console.Write("Valor do depósito: ");
            double valor = double.Parse(Console.ReadLine());

            conta.Depositar(valor);
            Console.WriteLine("Depósito realizado!");
        }

        static void AumentarLimite()
        {
            Conta conta = ObterConta();
            if (conta == null) return;

            Console.Write("Valor para aumentar: ");
            double valor = double.Parse(Console.ReadLine());

            conta.AumentarLimite(valor);
            Console.WriteLine("Limite aumentado!");
        }

        static void DiminuirLimite()
        {
            Conta conta = ObterConta();
            if (conta == null) return;

            Console.Write("Valor para diminuir: ");
            double valor = double.Parse(Console.ReadLine());

            conta.DiminuirLimite(valor);
            Console.WriteLine("Limite diminuído!");
        }
    }
}
