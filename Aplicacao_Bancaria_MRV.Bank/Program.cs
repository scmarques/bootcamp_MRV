using System;
using System.Collections.Generic;

namespace MRV.Bank
{
    class Program
    {
        static List<Conta> listContas = new List<Conta> ();

        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper () != "X"){

                switch(opcaoUsuario)
                {
                    case "1":
                        ListarContas ();
                        break;
                    case "2":
                        InserirConta ();
                        break;
                    case "3":
                        Transferir ();
                        break;
                    case "4":
                        Sacar ();
                        break;
                    case "5":
                        Depositar ();
                        break;
                    case "C":
                        Console.Clear();
                        break;
                    
                    default:
                        throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
            Console.WriteLine("Obrigada por utilizar nossos serviços!");
            Console.ReadLine();
            
        }

        private static void Transferir()
        {
            Console.WriteLine("Transferência de valores");

            Console.Write("Digite o número da conta de origem:");
            int indiceContaOrigem = int.Parse(Console.ReadLine());
            Console.Write("Digite o número da conta de destino:");
            int indiceContaDestino = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor a ser transferido:");
            double valorTransferencia = double.Parse(Console.ReadLine());

            listContas[indiceContaOrigem].Transferir(valorTransferencia, listContas[indiceContaDestino]);

        }

        private static void Sacar()
        {
            Console.WriteLine("Saque");
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor que deseja sacar: ");
            double valorSaque = double.Parse(Console.ReadLine());

            listContas[indiceConta].Sacar(valorSaque);
        }
        private static void Depositar()
        {
            Console.WriteLine("Depósito");
            Console.Write("Digite o número da conta: ");
            int indiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor que deseja depositar: ");
            double valorDeposito = double.Parse(Console.ReadLine());

            listContas[indiceConta].Depositar(valorDeposito);
        }
        private static void ListarContas()
        {
            Console.WriteLine("Listagem de Contas");
            
            if(listContas.Count == 0){
                Console.WriteLine("Nenhuma conta cadastrada. Retornando ao menu inicial.");
                Console.ReadLine();
                return;
            }

            for (int i = 0; i < listContas.Count; i++)
            {
                Conta conta = listContas[i];
                Console.Write("#{0} - ", i);
                Console.WriteLine(conta);
            }
        }

        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");
            Console.Write("Digite 1 para inserir uma conta de Pessoa Física ou 2 para Pessoa Jurídica: ");
            int entradaTipoConta = int.Parse(Console.ReadLine());
            
            Console.Write("Digite o nome do cliente: ");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o saldo inicial: ");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o crédito: ");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, saldo: entradaSaldo, 
                                        credito: entradaCredito, nome: entradaNome);
            
            listContas.Add(novaConta);
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine(":.:.:.:.:MRV.Bank:.:.:.:.:");
            Console.WriteLine("Digite a opção desejada: ");
            Console.WriteLine("(1) - Listas Contas ");
            Console.WriteLine("(2) - Inserir nova Conta ");
            Console.WriteLine("(3) - Transferir ");
            Console.WriteLine("(4) - Sacar ");
            Console.WriteLine("(5) - Depositar ");
            Console.WriteLine("(C) - Limpar Tela ");
            Console.WriteLine("(X) - Sair ");

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            
            return opcaoUsuario;
            



        }
    }
}
