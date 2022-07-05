using System;
using ProjetoBancoPoo.Models;

namespace ProjetoBancoPoo
{
    class Program
    {
        static void Main(string[] args)
        {
            //Ler dados do usuario
            Console.WriteLine("Digite o seu CPF: ");
            string cpf = Console.ReadLine();

            Console.WriteLine("Digite o seu Nome: ");
            string nome = Console.ReadLine();

            Console.WriteLine("Digite o seu Telefone: ");
            string telefone = Console.ReadLine();


            //Ler dados da Conta

            Console.WriteLine("Digite o número da conta:");
            double numeroConta = Convert.ToDouble(Console.ReadLine());

            Console.WriteLine("Conta Especial:");
            bool contaEspecial = Convert.ToBoolean(Console.ReadLine());

            double limite = 0, juros = 0;

            if (contaEspecial)
            {

                Console.WriteLine("Digite o limite da conta: ");
                limite = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Digite o Juros conta: ");
                juros = Convert.ToDouble(Console.ReadLine());

            }

            // Ler dados ContaPoupança
            Console.WriteLine("Digite o número da conta Poupanca:");
            double numeroContaPoupanca = Convert.ToDouble(Console.ReadLine());

            //Alimentando Construtores
            //Objeto com Construtor Cliente
            Cliente cliente = new Cliente(cpf, nome, telefone);

            /* cliente.Cpf = cpf;
             cliente.Nome = nome;
             cliente.Telefone = telefone;*/

            //Objetos com Construtores ContaCorrente e Poupança
            ContaPoupanca cp = new ContaPoupanca(numeroContaPoupanca);
            ContaCorrente cc = new ContaCorrente(numeroConta, contaEspecial, limite, cliente, juros, cp);

            /* cp.Numero = numeroContaPoupanca;
             cc.Numero = numeroConta;
             cc.Especial = contaEspecial;
             cc.Limite = limite;
             cc.Cliente = cliente;
             cc.Juros = juros;
             cc.ContaPoupanca = cp;*/



            do
            {
                bool controleDW = true;
                Console.WriteLine("Escolha uma opçãp: \n 1-Depositar \n2-Retirar \n3-Transferir" +
                    "\n4-Calcular \n5-Sair");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:

                        controleDW = false;
                        Console.WriteLine("Digite o valor para deposito: ");

                        try
                        {
                            cc.Depositar(Convert.ToDouble(Console.ReadLine()));
                            Console.WriteLine("O Saldo da conta é: " + cc.Saldo + "e o saldo com limite: " + cc.RetornarSaldo()); // verificar ultima var
                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                            throw;
                        }

                        break;

                    case 2:

                        controleDW = false;

                        Console.WriteLine("Digite o valor para retirar: ");

                        try
                        {
                            cc.Retirar(Convert.ToDouble(Console.ReadLine()));

                            Console.WriteLine("O Saldo da conta é: " + cc.Saldo + "e o saldo com limite: " + cc.RetornarSaldo());

                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                            throw;
                        }


                        break;

                    case 3:
                        controleDW = false;
                        Console.WriteLine("Digite o valor para transferir: ");

                        try
                        {
                            cc.TransferirParaPoupanca(Convert.ToDouble(Console.ReadLine()));
                            Console.WriteLine("O Saldo da conta é: " + cc.Saldo + "e o saldo com limite: " + cc.RetornarSaldo());
                            Console.WriteLine("O Saldo da conta Poupança é: " + cp.Saldo);

                        }
                        catch (ArgumentException e)
                        {
                            Console.WriteLine(e.Message);
                            throw;
                        }

                        break;

                    case 4:
                        controleDW = false;

                        if (cc.Saldo >= 0)
                        {

                            Console.WriteLine("Voce não está devendo");
                        }
                        else
                        {
                            Console.WriteLine("Digite a quantidade de dias: ");

                            try
                            {
                                Console.WriteLine(cc.CalcularValorTaxaJuro(Convert.ToInt32(Console.ReadLine())));

                            }
                            catch (ArgumentException e)
                            {
                                Console.WriteLine(e.Message);
                                throw;
                            }
                        }

                        break;

                    case 5:
                        controleDW = false;
                        Console.WriteLine("Saindo....");


                        break;
                    default:
                        Console.WriteLine("Opção Invalida");
                        return;

                }


            } while (true);

        }
    }
}
