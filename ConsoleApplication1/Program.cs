using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            Polynomial p1 = new Polynomial(2, 0, 1);
            Polynomial p2 = new Polynomial(1, 4);
            Polynomial pPlus = new Polynomial(3, 4, 1);
            Console.WriteLine(p1.ToString());
            Console.WriteLine((p1 + p2)==(pPlus));
            Console.WriteLine(p1 - p2);
            Console.WriteLine(p1 != p2);
            Console.WriteLine(p1 * p2);
            Console.WriteLine((p1 * p2).Degree);
            Console.WriteLine(p2.CalculateByValue(2));
            //Console.WriteLine(p1.coefficientArray[1]);
            //Console.WriteLine(p1.Equals(p2));
            //p.Change();
            //Console.WriteLine(p.ToString());
        }
    }
}
