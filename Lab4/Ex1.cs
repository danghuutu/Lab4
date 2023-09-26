using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4
{
    public delegate void  SampleDelegate(int a, int b);
    class MathOperations
    {
        public void Add(int a, int b)
        {
            Console.WriteLine("Add Result: {0}", a + b);
        }
        public void Subtract(int a, int b)
        {
            Console.WriteLine("Subtract Result: {0}", a - b);
        }
        public void Multiply(int a, int b)
        {
            Console.WriteLine("Multiply Result: {0}", a * b);
        }
        public void Division(int a, int b)
        {


            try {
                if (b.Equals(0))
                {
                    throw new DivideByZeroException("Division by zero is not allowed.");
                }
                else
                {
                    Console.WriteLine("Division Result: {0}", a / b);
                }
            }
            catch (DivideByZeroException ex) 
            {
                Console.WriteLine($"Division Result: {ex.Message}");
            }
            
        }
    }

    class Program_Ex1
    {
        static void Main(string[] args)
        {
            Console.WriteLine("****Delegate Example****");
            MathOperations m = new MathOperations();
            SampleDelegate dlgt = m.Add;
            dlgt += m.Subtract;
            dlgt += m.Multiply;
            dlgt += m.Division;
            dlgt(90, 0);
            Console.ReadLine();
        }
    }
}
