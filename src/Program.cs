using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp4_Exceptions
{
    class Program
    {
        static void Main(string[] args)
        {
            // TestaCapturaDeExcecao();

            Console.ReadLine();
        }

        static void TesteContaCorrente()
        {
            var cliente = new Cliente();
            cliente.Nome = "Igor";
            cliente.Profissao = "Motorista";
            cliente.CPF = "628.746.332-12";

            // var conta = new ContaCorrente(424, 37299, null);
            // var conta = new ContaCorrente(424, -1, cliente);
            var conta = new ContaCorrente(424, 37299, cliente);

            conta.Depositar(100);
            conta.Sacar(200); 
        }

        static void TestaCapturaDeExcecao()
        {
            try
            {
                Metodo1();
            }
            catch(DivideByZeroException e)
            {
                Console.WriteLine("Captura de DivideByZeroException!");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            catch(Exception e)
            {
                Console.WriteLine("Captura de Exception!");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
        }

        static void Metodo1()
        {
            Metodo2();
        }

        static void Metodo2()
        {
            try
            {
                DividePorZero();
            }
            catch (DivideByZeroException e)
            {
                Console.WriteLine("Captura de DivideByZeroException!");
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                // DividePorZero: não aparece no StackTrace
                // throw e;

                // DividePorZero: aparece no StackTrace
                throw;
            }
            LancaExcecao();
        }

        static void LancaExcecao()
        {
            throw new Exception();
        }

        static void DividePorZero()
        {
            int divisor = 0;
            int numero = 4 / divisor;
        }
    }
}
