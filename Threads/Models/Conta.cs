using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Threads.Models
{
    public class Conta
    {
        private int Numero { get; set; }
        private string Titular { get; set; }
        private decimal Saldo { get; set; }

        public Conta()
        {

        }

        public Conta(int numero, string titular, decimal saldo)
        {
            this.Numero = numero;
            this.Titular = titular;
            this.Saldo = saldo;
        }

        public int GetNumero() => this.Numero;
        public string GetTitular() => this.Titular;
        public decimal GetSaldo() => this.Saldo;
        public void SetNumero(int numero)
        {
            if (numero > 0)
                this.Numero = numero;
            else
                Console.WriteLine("Numero de conta inválida !!");
        }
        public void SetTitular(string titular) => this.Titular = titular;
        public void SetSaldo(decimal saldo) => this.Saldo = saldo;

        public override string ToString() => $@"Conta: Numero = {this.Numero}, Titular = {this.Titular}, Saldo = {this.Saldo}";

        public void Deposito(decimal saldo = 1000) => this.Saldo += saldo;
        public void Saque(decimal saldo) => this.Saldo -= saldo;

    }
}
