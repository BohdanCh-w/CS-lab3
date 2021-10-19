using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Threading;

namespace CS_lab3 {
    class Program {
        public static int max = 50;

        static void Main(string[] args) {
            int num = 1_000_000;
            int[] data = generateArr(1, max, num);
            ParalellTaskTest(data);
            ParalellPLINQTest(data);
        }

        static void ParalellTaskTest(int[] data) {
            Stopwatch stopwatch = new Stopwatch();

            int[] threadCount = new int[] { 1, 2, 4, 8, 10, 100 };
            Console.WriteLine("Paralell Task");
            
            foreach( int c in threadCount ) {
                stopwatch.Restart();
                var res = Calculator.CalculateParalelTask(data, c);
                stopwatch.Stop();
                Console.Write(res.Result);
                Console.WriteLine("\t time consumed {0} in {1} threads", stopwatch.ElapsedTicks, c);
            }
            Console.WriteLine("\n");
        }

        static void ParalellPLINQTest(int[] data) {
            Stopwatch stopwatch = new Stopwatch();

            int[] threadCount = new int[] { 1, 2, 4, 8, 10, 100 };
            Console.WriteLine("Paralell LINQ");
            
            foreach( int c in threadCount ) {
                stopwatch.Restart();
                var res = Calculator.CalculatePLINQ(data, c);
                stopwatch.Stop();
                Console.Write(res);
                Console.WriteLine("\t time consumed {0} in {1} threads", stopwatch.ElapsedTicks, c);
            }
            Console.WriteLine("\n");
        }

        static int[] generateArr(int min, int max, int count) {
            Random randNum = new Random();
            int[] arr = Enumerable.Repeat(0, count)
                .Select(i => randNum.Next(min, max)).ToArray();
            return arr;
        }
    }
}
