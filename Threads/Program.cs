using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Threads.Models;

namespace Threads
{
    class Program
    {
        static Conta conta;
        static decimal saqueAGastadora = 0;
        static decimal saqueAEsperta = 0;
        static decimal saqueAEconomica = 0;
        static void Main(string[] args)
        {
            Thread[] Threads = new Thread[3];

            conta = new Conta();

            conta.Deposito();
            Console.WriteLine($@"Saldo Inicial => {conta.GetSaldo()}");

            //A Gastadora
            Threads[0] = new Thread(new ThreadStart(AGastadora));
            Threads[0].Name = "thread " + 1;

            //A Esperta
            Threads[1] = new Thread(new ThreadStart(AEsperta));
            Threads[1].Name = "thread " + 2;

            //A Economica
            Threads[2] = new Thread(new ThreadStart(AEconomica));
            Threads[2].Name = "thread " + 3;

            //A Patrocinadora
            //Threads[3] = new Thread(new ThreadStart(APatrocinadora));
            //Threads[3].Name = "thread " + 4;

            foreach (Thread t in Threads)
                t.Start();
        }

        static void AGastadora()
        {
            while (conta.GetSaldo() >= 10)
            {
                conta.Saque(10);
                saqueAGastadora += 10;

                Console.WriteLine($@"AGastadora: Saldo => {conta.GetSaldo()}");
                Thread.Sleep(3000);
            }
            Console.ReadLine();
        }

        static void AEsperta()
        {
            while (conta.GetSaldo() >= 50)
            {
                conta.Saque(50);
                saqueAEsperta += 50;

                Console.WriteLine($@"AEsperta: Saldo => {conta.GetSaldo()}");
                Thread.Sleep(6000);
            }
            Console.ReadLine();
        }

        static void AEconomica()
        {
            while (conta.GetSaldo() >= 5)
            {
                conta.Saque(5);
                saqueAEconomica += 5;

                Console.WriteLine($@"AEconomica: Saldo => {conta.GetSaldo()}");
                Thread.Sleep(12000);
            }
            Console.ReadLine();
        }

        static void APatrocinadora()
        {
            while (true)
            {
                var saldo = conta.GetSaldo();
                Console.WriteLine($@"AGastadora: Saque total => {saqueAGastadora}");
                Console.WriteLine($@"AEsperta: Saque total => {saqueAEsperta}");
                Console.WriteLine($@"AEconomica: Saque total => {saqueAEconomica}");

                if (saldo == 0)
                    conta.Deposito(100);

                Console.WriteLine($@"APatrocinadora: Saldo => {conta.GetSaldo()}");
                Thread.Sleep(500);
            }
        }
    }
}
