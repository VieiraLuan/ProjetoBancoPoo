using System;
using System.Collections.Generic;
using System.Text;
using ProjetoBancoPoo.Exceptions;

namespace ProjetoBancoPoo.Models
{
    class ContaCorrente : Conta // ContaCorrente é igual Conta + alguma coisa
    {


        public Cliente Cliente { get; set; }//Esse é o + alguma coisa (Propriedade de acesso a propriedades da classe pai)
        public bool Especial { get; set; }
        public double Limite { get; set; }
        public double Juros { get; set; }

        public ContaPoupanca ContaPoupanca { get; set; }


        //Construtor
        public ContaCorrente(double numero, bool especial, double limite,
            Cliente cliente, double juros, ContaPoupanca contaPoupanca)
        {
            Numero = numero;
            Especial = especial;
            Limite = limite;
            Juros = juros;
            Cliente = cliente;
            ContaPoupanca = contaPoupanca;
        }

        public void Retirar(double valor)
        {
            if (Especial)
            {
                if (valor <= Saldo + Limite)
                {
                    Saldo -= valor;
                }
                else if(valor <= Saldo)
                {
                    Saldo -= valor;

                }
                else
                {
                    Console.WriteLine("Não foi Possivel completar a transação");
                    throw new SaldoInsuficienteException("Saldo Insuficiente");
                }
            }
        }


        public double RetornarSaldo()
        {
            if (Especial)
            {
                return Saldo + Limite;
            }
            return Saldo;

        }

        public void TransferirParaPoupanca(double valor)
        {
            Retirar(valor);// Metodo propria classe
            ContaPoupanca.Depositar(valor);

        }

        public double CalcularValorTaxaJuro(int dias)
        {
            if(Saldo < 0)
            {
                return Convert.ToDouble(Juros) * dias * Saldo;
            }
            return 0;
        }

    }
}
