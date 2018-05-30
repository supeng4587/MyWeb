using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CZBK.ItcastProject.demo
{
    public delegate int SumAdd(int a, int b);
    class Program
    {
        static void Main(string[] args)
        {
            //Func<>;
            //Action<>;

            Program p = new Program();
            SumAdd sumAdd = new SumAdd(p.AddSum);
            int sum=sumAdd(3, 6);
            Console.WriteLine(sum);
            Console.ReadKey();
        }

        public int AddSum(int a,int b)
        {
            return a + b;
        }
    }
}
